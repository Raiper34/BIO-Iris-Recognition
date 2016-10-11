using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BIO.Framework.Core;
using BIO.Framework.Core.Comparator;

namespace BIO.Framework.Extensions.Standard.Block {
    public class InputDataProcessingBlock <
        TInputData,
        TEvaluatedFeatureVector,
        TTemplate,
        TTemplatedFeatureVector
    > : BIO.Framework.Core.Block.IInputDataProcessingBlock<TInputData>

        where TInputData : BIO.Framework.Core.InputData.IInputData
        where TTemplatedFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector
        where TEvaluatedFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector
        where TTemplate : BIO.Framework.Core.Template.ITemplate<TTemplatedFeatureVector>
       
    {

        Core.Template.TemplateSerializer<TTemplate, TTemplatedFeatureVector> serializer = new Core.Template.TemplateSerializer<TTemplate, TTemplatedFeatureVector>();
        
        IInputDataProcessingBlockComponents<TInputData, TEvaluatedFeatureVector, TTemplate, TTemplatedFeatureVector> components = null;

        public InputDataProcessingBlock(IInputDataProcessingBlockComponents<TInputData, TEvaluatedFeatureVector, TTemplate, TTemplatedFeatureVector> components, string name) {
            this.components = components;
            this.Name = name;
        }


        #region ITemplateExtractingBlock<TInputData> Members

        public void extractAndAddToNewTemplate(TInputData input, Core.Template.Persistence.IPersistentTemplate newTemplateToStore) {
           
            string message = "Template extraction:";

            message += ".";
            onProgressChanged(new ProgressReport(message));
            
            //create feature vector
            TTemplatedFeatureVector featureVector = this.components.getTemplatedFeatureVectorExtractor().extractFeatureVector(input);

            message += ".";
            onProgressChanged(new ProgressReport(message));

            //create template
            TTemplate template = this.components.getTemplateCreator().createTemplate(featureVector);

            message += ".";
            onProgressChanged(new ProgressReport(message));

            //convert to binary form
            serializer.writeToStream(newTemplateToStore.getStream(), template);

            message += ".";
            onProgressChanged(new ProgressReport(message));

            //store template
            //templateDatabase.addRecord(new Database.BiometricDatabase.BiometricRecord(r.SampleID, r.BiometricID, persistentTemplate));

            //onProgressChanged(new ProgressReport("Template extraction: persistent template", act, total));

        }

        public void extractAndAddToExistingTemplate(TInputData input, Core.Template.Persistence.IPersistentTemplate existingTemplate, Core.Template.Persistence.IPersistentTemplate newTemplateToStore) {
            throw new NotImplementedException();
        }

        #endregion
       

        #region IProgressReporter Members

        public event ProgressChangedEventHandler ProgressChangedEvent;

        public void onProgressChanged(ProgressReport e) {
            if (ProgressChangedEvent != null)
                ProgressChangedEvent(e);
        }

        #endregion

        private string name = "unknown_block";

        #region IBlock Members

        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        #endregion


        

        #region IMatchingBlock<TInputData> Members

        List<TTemplate> templateBuffer = new List<TTemplate>();
        TEvaluatedFeatureVector currentFeatureVector;

        public void resetTemplates() {
            templateBuffer.Clear();
        }

        public int pushTemplate(Core.Template.Persistence.IPersistentTemplate template) {

            TTemplate bufferedTemplate;// = this.biometricAlgorithmSettings.getTemplateCreator().createEmptyTemplate();
            serializer.initFromStream(template.getStream(), out bufferedTemplate);
            templateBuffer.Add(bufferedTemplate);

            return templateBuffer.Count() - 1;
        }

        public void setInputData(TInputData inputData) {
            currentFeatureVector = this.components.getEvaluationFeatureVectorExtractor().extractFeatureVector(inputData);
        }

        public MatchingScore computeMatchingScore(int templateIndex) {
            if (templateIndex < 0 || templateIndex >= templateBuffer.Count()) throw new IndexOutOfRangeException("Template index not in buffer");
            return this.components.getComparator().computeMatchingScore(currentFeatureVector, templateBuffer[templateIndex]);
        }

        #endregion
    }
        
    
}
