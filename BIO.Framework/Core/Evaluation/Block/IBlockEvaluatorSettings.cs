using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Block;

namespace BIO.Framework.Core.Evaluation.Block {
    public interface IBlockEvaluatorSettings  <
        TInputRecord,
        TInputData
    > : IEvaluatorSettings <
        TInputRecord,
        TInputData
    >
        where TInputRecord : Database.IRecord
        where TInputData : InputData.IInputData {

       

        /// <summary>
        /// add block to evaluation
        /// </summary>
        /// <param name="evaluatedBiometricSystem"></param>
        void addBlockToEvaluation(IInputDataProcessingBlock<TInputData> evaluatedBlock);

        /// <summary>
        /// evaluated biometric blocks iterator
        /// </summary>
        /// <returns></returns>
        IEnumerable<IInputDataProcessingBlock<TInputData>> getEvaluatedBlockIterator();

        /// <summary>
        /// get persistent template creator     
        /// </summary>
        /// <returns></returns>
        Template.Persistence.IPersistentTemplateCreator getPersistentTemplateCreator();
    }
}
