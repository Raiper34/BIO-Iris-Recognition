using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Evaluation;
using BIO.Framework.Extensions.Standard.BiometricSystem;
using BIO.Framework.Core;
using BIO.Framework.Core.BiometricSystem;
using BIO.Framework.Core.Evaluation.Block;

namespace BIO.Framework.Extensions.Standard.Evaluation.Block {
    public abstract class BlockEvaluationSettings <
        TInputRecord,
        TInputData
    >  : IBlockEvaluatorSettings <
        TInputRecord,
        TInputData
    >
        where TInputRecord : BIO.Framework.Core.Database.IRecord
        where TInputData : BIO.Framework.Core.InputData.IInputData {

        #region IEvaluatorSettings<TPersistentTemplate> Members

        Core.Template.Persistence.IPersistentTemplateCreator persistentTemplateCreator = null;

        public Core.Template.Persistence.IPersistentTemplateCreator getPersistentTemplateCreator() {
            if (persistentTemplateCreator == null) {
                persistentTemplateCreator = this.createPersistentTemplateCreator();
            }
            return persistentTemplateCreator;
        }
        /// <summary>
        /// default if memory persistent creator
        /// can be overriden
        /// </summary>
        /// <returns></returns>
        protected virtual Core.Template.Persistence.IPersistentTemplateCreator createPersistentTemplateCreator() {
            return new Template.Persistence.PersistentTemplateCreator<Template.Persistence.MemoryPersistentTemplate>();
        }


        #endregion



        #region IEvaluatorSettings<TInputRecord,TInputData> Members

        Dictionary<string, Core.Block.IInputDataProcessingBlock<TInputData>> blocks = new Dictionary<string, Core.Block.IInputDataProcessingBlock<TInputData>>();

        public void addBlockToEvaluation(Core.Block.IInputDataProcessingBlock<TInputData> evaluatedBlock) {
            if (blocks.ContainsKey(evaluatedBlock.Name)) {
                throw new ArgumentException("Block with name " + evaluatedBlock.Name + " already added");
            }
            this.blocks.Add(evaluatedBlock.Name, evaluatedBlock);
        }

        public IEnumerable<Core.Block.IInputDataProcessingBlock<TInputData>> getEvaluatedBlockIterator() {
            return this.blocks.Values;
        }

        /// <summary>
        /// instance
        /// </summary>
        Core.InputData.IInputDataCreator<TInputRecord, TInputData> inputDataCreator = null;

        /// <summary>
        /// IInputDataCreator interface getter
        /// </summary>
        /// <returns></returns>
        public Core.InputData.IInputDataCreator<TInputRecord, TInputData> getInputDataCreator() {
            if (inputDataCreator == null) {
                inputDataCreator = this.createInputDataCreator();
            }
            return inputDataCreator;
        }

        protected abstract Core.InputData.IInputDataCreator<TInputRecord, TInputData> createInputDataCreator();

        #endregion

        #region IEvaluatorSettings<TInputRecord,TInputData> Members

        string name = "blockEvaluation";

        public string Name {
            get {
                return name;
            }
            set {
                this.name = value;
            }
        }

        #endregion

       
    }
}
