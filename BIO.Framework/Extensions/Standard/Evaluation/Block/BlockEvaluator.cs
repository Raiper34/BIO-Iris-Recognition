using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Core.Evaluation;
using BIO.Framework.Core;
using BIO.Framework.Core.Evaluation.Results;
using BIO.Framework.Core.Database;
using BIO.Framework.Core.Database.TemplateDatabase;
using BIO.Framework.Core.Evaluation.Block;

namespace BIO.Framework.Extensions.Standard.Evaluation.Block {
    public class BlockEvaluator
        <
            TInputRecord,
            TInputData
        > : IBlockEvaluator<TInputRecord>, IProgressReporter
        where TInputRecord : Core.Database.IRecord
        where TInputData : BIO.Framework.Core.InputData.IInputData
    {

        //private IBiometricSystemSettings<TInputRecord, TInputData> biometricAlgorithmBlockSettings = null;
        private IBlockEvaluatorSettings<TInputRecord, TInputData> evaluationSettings = null;


        public BlockEvaluator(
            /*IBiometricSystemSettings<TInputRecord, TInputData> biometricAlgorithmBlockSettings,*/
            IBlockEvaluatorSettings<TInputRecord, TInputData> evaluationSettings) {
                //this.biometricAlgorithmBlockSettings = biometricAlgorithmBlockSettings;
                this.evaluationSettings = evaluationSettings;
        }

        public void onProgressChanged(ProgressReport e) {
            if (ProgressChangedEvent != null)
                ProgressChangedEvent(e);
        }

        public void extractTemplates(Core.Database.IRecordEnumerable<TInputRecord> inputDatabase, Core.Database.TemplateDatabase.TemplateDatabase templateDatabase) {

            onProgressChanged(new ProgressReport("Template extraction started"));

            int total = inputDatabase.getRecords().Count();
            int act = 0;
            foreach (TInputRecord r in inputDatabase.getRecords()) {
                act++;

                string message = "Template extraction ";
                message += ".";
                onProgressChanged(new ProgressReport(message, act, total));

                //create input data
                TInputData inputData = this.evaluationSettings.getInputDataCreator().createInputData(r);

                message += ".";
                onProgressChanged(new ProgressReport(message, act, total));

                Core.Template.Persistence.IPersistentTemplate mt = this.evaluationSettings.getPersistentTemplateCreator().createPersistentTemplate(this.evaluationSettings.Name,  r.BiometricID);

                foreach (var block in evaluationSettings.getEvaluatedBlockIterator()) {
                    //var block = bioSystem.getBiometricSystemSettings().getProcessingBlock();
                    //persistent template
                    Core.Template.Persistence.IPersistentTemplate persistentTemplate = mt.createSubtemplate(block.Name);
                    block.extractAndAddToNewTemplate(inputData, persistentTemplate);

                    message += ".";
                    onProgressChanged(new ProgressReport(message, act, total));
                }

                //store template
                templateDatabase.addRecord(new Core.Database.TemplateDatabase.TemplateRecord(r.SampleID, r.BiometricID, mt));

                message += ".";
                onProgressChanged(new ProgressReport(message, act, total));

            }
        }
       

        
        public void evaluateRecords(Core.Database.IRecordEnumerable<TInputRecord> inputDatabase, TemplateDatabase templateDatabase, Core.Evaluation.Results.Results results){

            onProgressChanged(new ProgressReport("Records evaluation started"));

            Dictionary<string, Dictionary<int, Core.Database.TemplateDatabase.TemplateRecord>> cache = new Dictionary<string, Dictionary<int, Core.Database.TemplateDatabase.TemplateRecord>>();
            
            //onProgressChanged(new ProgressReport("Create cache"));
            //List<TemplateCacheRecord> cache = new List<TemplateCacheRecord>();

            foreach (var block in evaluationSettings.getEvaluatedBlockIterator()) {
                
                block.resetTemplates();
                cache.Add(block.Name, new Dictionary<int, Core.Database.TemplateDatabase.TemplateRecord>());
                foreach (Core.Database.TemplateDatabase.TemplateRecord templateRecord in templateDatabase.getCollections().getRecords()) {
                    cache[block.Name].Add(
                        block.pushTemplate(
                            templateRecord.PersistentTemplate.getSubtemplate(block.Name)),
                            templateRecord
                    );
                }

            }

            int total = inputDatabase.getRecords().Count() * evaluationSettings.getEvaluatedBlockIterator().Count();
            int act = 0;
            foreach (TInputRecord r in inputDatabase.getRecords()){

                string message = "Records evaluation ";
                message += ".";
                onProgressChanged(new ProgressReport(message, act, total));

                //create input data
                TInputData inputData = this.evaluationSettings.getInputDataCreator().createInputData(r);

                message += ".";
                onProgressChanged(new ProgressReport(message, act, total));

                foreach (var block in evaluationSettings.getEvaluatedBlockIterator()) {
                    act++;

                    block.setInputData(inputData);

                    foreach (KeyValuePair <int, Core.Database.TemplateDatabase.TemplateRecord> pair in cache[block.Name]){
                        //compare
                        MatchingScore matchingScore = block.computeMatchingScore(pair.Key);

                        //store result
                        Result result = new Result(new Record(pair.Value), new Record(r));
                        result.setMatchingScore(block.Name, matchingScore);

                        results.addResult(result);
                    }

                    message += ".";
                    onProgressChanged(new ProgressReport(message, act, total));

                }

                

            }

        }
       

        #region IProgressReporter Members

        public event ProgressChangedEventHandler ProgressChangedEvent;

        #endregion
    }
}
