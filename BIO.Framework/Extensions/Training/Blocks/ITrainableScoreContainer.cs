using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BIO.Framework.Core.InputData;
using BIO.Framework.Core.Block;

namespace BIO.Framework.Extensions.Training.Block {
    public interface ITrainableScoreContainer  {
        
        /// <summary>
        /// get trainable score fusion block
        /// </summary>
        /// <returns></returns>
        ITrainableScoreFusionBlock getTrainableScoreFusionBlock();

    }
}
