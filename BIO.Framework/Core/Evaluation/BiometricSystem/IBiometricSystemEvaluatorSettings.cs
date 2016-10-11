using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Block;

namespace BIO.Framework.Core.Evaluation {
    public interface IBiometricSystemEvaluatorSettings  <
        TInputRecord,
        TInputData
    > : IEvaluatorSettings <
        TInputRecord,
        TInputData
    >
        where TInputRecord : Database.IRecord
        where TInputData : InputData.IInputData {

        /// <summary>
        /// add biometric system to evaluation
        /// </summary>
        /// <param name="evaluatedBiometricSystem"></param>
        void addBlockToEvaluation(IInputDataProcessingBlock<TInputData> evaluatedBiometricSystem);

        /// <summary>
        /// evaluated biometric system interator
        /// </summary>
        /// <returns></returns>
        IEnumerable<BiometricSystem.IBiometricSystem<TInputData>> getEvaluatedBiometricSystems();

    }
}
