using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BIO.Framework.Core.Block {
    public interface IMultipleInputDataProcessingBlock<TInputData> : IInputDataProcessingBlock<TInputData> 
        where TInputData : InputData.IInputData {
        /// <summary>
        /// add internal block
        /// </summary>
        /// <param name="block"></param>
        void addInternalBlock(IInputDataProcessingBlock<TInputData> block);

        /// <summary>
        /// get inetrnal blocks iterator
        /// </summary>
        /// <returns></returns>
        //IEnumerable<IInputDataProcessingBlock<TInputData>> getInternalBlockIterator();

        IScoreFusionBlock getScoreFusionBlock();

    }
}
