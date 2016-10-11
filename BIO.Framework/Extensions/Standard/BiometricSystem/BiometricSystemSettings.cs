using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.BiometricSystem {
    public class BiometricSystemSettings <TInputData>
        : Core.BiometricSystem.IBiometricSystemSettings<TInputData> 
        where TInputData : Core.InputData.IInputData {
        #region IBiometricSystemSettings<TInputData> Members

        public BiometricSystemSettings(Core.Block.IInputDataProcessingBlock<TInputData> block, DecisionMaker decisionMaker) {
            this.processingBlock = block;
            this.Name = block.Name;
            this.decisionMaker = decisionMaker;
        }

        public BiometricSystemSettings(Core.Block.IInputDataProcessingBlock<TInputData> block) {
            this.processingBlock = block;
            this.Name = block.Name;
        }

        string name;

        public string Name {
            get {
                return name;
            }
            set {
                this.name = value;
            }
        }

        Core.Block.IInputDataProcessingBlock<TInputData> processingBlock = null;

        public Core.Block.IInputDataProcessingBlock<TInputData> getProcessingBlock() {
            return this.processingBlock;
        }

        #endregion

        #region IBiometricSystemSettings<TInputData> Members

        BiometricSystem.DecisionMaker decisionMaker = new DecisionMaker();

        public Core.BiometricSystem.IDecisionMaker getDecisionMaker() {
            return decisionMaker;
        }

        #endregion

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
    }
}
