using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Core.Block;

namespace BIO.Framework.Extensions.Training.Block {
    public interface ITrainableScoreFusionBlock : IScoreFusionBlock {

        /// <summary>
        /// TODO
        /// </summary>
        void train();

        
    }
}
