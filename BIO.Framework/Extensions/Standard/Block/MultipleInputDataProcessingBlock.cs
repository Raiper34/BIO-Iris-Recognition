using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BIO.Framework.Core;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Core.Block;

namespace BIO.Framework.Extensions.Standard.Block {
    public abstract class MultipleInputDataProcessingBlock <TInputData> 
        : BIO.Framework.Core.Block.IMultipleInputDataProcessingBlock<TInputData>
         where TInputData : BIO.Framework.Core.InputData.IInputData {


        public MultipleInputDataProcessingBlock(string name) {
            this.Name = name;
        }

        

        Dictionary<string, Core.Block.IInputDataProcessingBlock<TInputData>> internalBlock = new Dictionary<string,Core.Block.IInputDataProcessingBlock<TInputData>>();

        private IEnumerable<Core.Block.IInputDataProcessingBlock<TInputData>> iterator() {
            return internalBlock.Values;
        }

        #region IMultipleInputDataProcessingBlock<TInputData> Members

        public void addInternalBlock(Core.Block.IInputDataProcessingBlock<TInputData> block) {
            this.internalBlock.Add(block.Name, block);
        }

        #endregion



        #region IMatchingBlock<TInputData> Members

        List<Dictionary<string, int>> templateNumbers = new List<Dictionary<string,int>>();

        IScoreFusionBlock matchingScoreFusionBlock;

        public IScoreFusionBlock getScoreFusionBlock() {
            if (matchingScoreFusionBlock == null) {
                matchingScoreFusionBlock = this.createMatchingScoreFusionBlock();
            }
            return matchingScoreFusionBlock;
        }

        protected abstract IScoreFusionBlock createMatchingScoreFusionBlock();

        public void resetTemplates() {
            templateNumbers.Clear();
            foreach (Core.Block.IInputDataProcessingBlock<TInputData> block in iterator()) {
                block.resetTemplates();
            }
        }

        public int pushTemplate(Core.Template.Persistence.IPersistentTemplate template) {
            int index = templateNumbers.Count();
            templateNumbers.Add(new Dictionary<string, int>());
            foreach (Core.Block.IInputDataProcessingBlock<TInputData> block in iterator()) {
                int subindex = block.pushTemplate(template.getSubtemplate(block.Name));
                templateNumbers[index].Add(block.Name, subindex);
            }
            return index;
        }

        public void setInputData(TInputData inputData) {
            foreach (Core.Block.IInputDataProcessingBlock<TInputData> block in iterator()) {
                block.setInputData(inputData);
            }
        }

        public virtual MatchingScore computeMatchingScore(int templateIndex) {
            MatchingScore matchingScoreToBeResolved = MatchingScore.invalid();
            
            foreach (Core.Block.IInputDataProcessingBlock<TInputData> block in iterator()) {
                MatchingScore ms = block.computeMatchingScore(templateNumbers[templateIndex][block.Name]);
                matchingScoreToBeResolved.addSubscore(block.Name, ms);
            }

            return this.getScoreFusionBlock().resolve(matchingScoreToBeResolved);
        }
        #endregion




        #region ITemplateExtractingBlock<TInputData> Members

        public void extractAndAddToNewTemplate(TInputData input, Core.Template.Persistence.IPersistentTemplate newTemplateToStore) {
            foreach (Core.Block.IInputDataProcessingBlock<TInputData> block in iterator()) {
                Core.Template.Persistence.IPersistentTemplate subtemplate = newTemplateToStore.createSubtemplate(block.Name);
                block.extractAndAddToNewTemplate(input, subtemplate);
            }
        }

        #endregion

        private string name;

        #region IBlock Members

        public string Name {
            get {
                return name;
            }
            set {
                this.name = value;
            }
        }

        #endregion

        #region IProgressReporter Members

        public event ProgressChangedEventHandler ProgressChangedEvent;

        public void onProgressChanged(ProgressReport e) {
            if (ProgressChangedEvent != null)
                ProgressChangedEvent(e);
        }

        #endregion

        
    }
        
    
}
