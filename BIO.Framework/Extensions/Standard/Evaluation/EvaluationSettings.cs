using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Evaluation;
using BIO.Framework.Extensions.Standard.BiometricSystem;
using BIO.Framework.Core;
using BIO.Framework.Core.BiometricSystem;

namespace BIO.Framework.Extensions.Standard.Evaluation {
    public abstract class EvaluationSettings <
        TInputRecord,
        TInputData
    >  : IEvaluatorSettings <
        TInputRecord,
        TInputData
    >
        where TInputRecord : BIO.Framework.Core.Database.IRecord
        where TInputData : BIO.Framework.Core.InputData.IInputData {

        /// <summary>
        /// TODO will be removed
        /// </summary>
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

        List<Core.BiometricSystem.IBiometricSystem<TInputData>> biometricSystems = new List<Core.BiometricSystem.IBiometricSystem<TInputData>>();

        /// <summary>
        /// add biometric system
        /// </summary>
        /// <param name="evaluatedBiometricSystem"></param>
        public void addBiometricSystemToEvaluation(Core.BiometricSystem.IBiometricSystem<TInputData> evaluatedBiometricSystem) {
            biometricSystems.Add(evaluatedBiometricSystem);
        }

        /// <summary>
        /// biometric systems iterator
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Core.BiometricSystem.IBiometricSystem<TInputData>> getEvaluatedBiometricSystemsIterator() {
            return this.biometricSystems;
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

        string name = "evaluation";

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
