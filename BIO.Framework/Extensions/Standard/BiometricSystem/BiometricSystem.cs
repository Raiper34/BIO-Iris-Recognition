using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Core.BiometricSystem;

namespace BIO.Framework.Extensions.Standard.BiometricSystem {
    public class BiometricSystem <TInputData>
        : Core.BiometricSystem.IBiometricSystem<TInputData> 
        where TInputData : Core.InputData.IInputData {

        public BiometricSystem(Core.BiometricSystem.IBiometricSystemSettings<TInputData> settings) {
            this.settings = settings;
        }


        #region IBiometricSystem<TInputData> Members

        Core.BiometricSystem.IBiometricSystemSettings<TInputData> settings = null;

        public Core.BiometricSystem.IBiometricSystemSettings<TInputData> getBiometricSystemSettings() {
            return settings;
        }

        Core.Database.TemplateDatabase.TemplateDatabase templateDb = new Core.Database.TemplateDatabase.TemplateDatabase();

        public Core.Database.TemplateDatabase.TemplateDatabase getTemplateDatabase() {
            return templateDb;
        }

        private int sampleIDIterator = 1;

        public void register(TInputData inputData, Core.Database.BiometricID biometricID) {
            
            sampleIDIterator++;
            //create new template
            Core.Template.Persistence.IPersistentTemplate mt = this.settings.getPersistentTemplateCreator().createPersistentTemplate(this.settings.Name,  biometricID);
            //extract input data to template
            this.settings.getProcessingBlock().extractAndAddToNewTemplate(inputData, mt);
            //add to database
            this.getTemplateDatabase().addRecord(new Core.Database.TemplateDatabase.TemplateRecord(sampleIDIterator.ToString(), biometricID, mt));
        }

        /// <summary>
        /// identification
        /// TODO -> speed up by caching
        /// TODO -> progress reporting
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public Core.BiometricSystem.IIdentificationResult identify(TInputData inputData) {
            this.settings.getProcessingBlock().setInputData(inputData);
            foreach (var record in this.getTemplateDatabase().getCollections().getRecords()) { 
                this.settings.getProcessingBlock().resetTemplates();
                int index = this.settings.getProcessingBlock().pushTemplate(record.PersistentTemplate);
                MatchingScore s =  this.settings.getProcessingBlock().computeMatchingScore(index);
                IDecisionMakerResult result = this.settings.getDecisionMaker().makeDecision(s);
                if (result.Status == ResultStatus.ACCEPTED) {
                    return new IdentificationResult(result, record.BiometricID);
                }
            }
            return new IdentificationResult(ResultStatus.REJECTED);
        }

        /// <summary>
        /// verification
        /// TODO -> speed up by caching
        /// TODO -> progress reporting
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="biometricID"></param>
        /// <returns></returns>
        public Core.BiometricSystem.IVerificationResult verify(TInputData inputData, Core.Database.BiometricID biometricID) {
            this.settings.getProcessingBlock().setInputData(inputData);
            foreach (var record in this.getTemplateDatabase().getCollections().getRecordsByBiometricID(biometricID)) {
                this.settings.getProcessingBlock().resetTemplates();
                int index = this.settings.getProcessingBlock().pushTemplate(record.PersistentTemplate);
                MatchingScore s = this.settings.getProcessingBlock().computeMatchingScore(index);
                IDecisionMakerResult result = this.settings.getDecisionMaker().makeDecision(s);
                if (result.Status == ResultStatus.ACCEPTED) {
                    return new VerificationResult(result, record.BiometricID);
                }
            }
            return new VerificationResult(ResultStatus.REJECTED);
        }

        #endregion

        #region IProgressReporter Members

        public event Core.ProgressChangedEventHandler ProgressChangedEvent;

        public void onProgressChanged(Core.ProgressReport e) {
            if (ProgressChangedEvent != null) {
                ProgressChangedEvent(e);
            }
        }

        #endregion
    }
}
