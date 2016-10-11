using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.BiometricSystem {
    public interface IBiometricSystemSettings<
        TInputData>
        where TInputData : InputData.IInputData
    {
        
        string Name { get; set; }

        /// <summary>
        /// get biometric system processing block
        /// </summary>
        /// <returns></returns>
        Block.IInputDataProcessingBlock<TInputData> getProcessingBlock();
        /// <summary>
        /// get biometric system decision maker
        /// </summary>
        /// <returns></returns>
        IDecisionMaker getDecisionMaker();

        /// <summary>
        /// get persistent template creator
        /// </summary>
        /// <returns></returns>
        Template.Persistence.IPersistentTemplateCreator getPersistentTemplateCreator();
    }
}
