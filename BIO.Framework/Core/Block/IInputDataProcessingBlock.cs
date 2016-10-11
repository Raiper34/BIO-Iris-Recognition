using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BIO.Framework.Core.Block {
    public interface IInputDataProcessingBlock <TInputData> : IMatchingBlock <TInputData> where TInputData : InputData.IInputData {
        
    }
}
