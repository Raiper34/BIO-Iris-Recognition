using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.InputData {
    public interface IMultiInputData : IInputData {
        
        TInputData getInputData<TInputData>(string name) where TInputData : IInputData;
    }
}
