using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.BiometricSystem;

namespace BIO.Framework.Extensions.Standard.BiometricSystem {
    public class BiometricSystemCreator<TInputData> where TInputData : Core.InputData.IInputData {




        public IBiometricSystem<TInputData> createFromBlockType<InputBlockType>() where InputBlockType : Core.Block.IInputDataProcessingBlock<TInputData>, new() {
            InputBlockType block = new InputBlockType();
            BiometricSystemSettings<TInputData> settings = new  BiometricSystemSettings<TInputData>(block);
            return new BiometricSystem<TInputData>(settings);
        }

        public IBiometricSystem<TInputData> createFromBlockInstance(Core.Block.IInputDataProcessingBlock<TInputData> block) {
            BiometricSystemSettings<TInputData> settings = new BiometricSystemSettings<TInputData>(block);
            return new BiometricSystem<TInputData>(settings);
        }

    }
}
