using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core;
using BIO.Framework.Core.Comparator;

namespace BIO.Framework.Core.Block {
    public interface IScoreFusionBlock {
        /// <summary>
        /// compute final matching score from structure containing matchings subscores 
        /// </summary>
        /// <param name="matchingSubscores"></param>
        /// <returns></returns>
        MatchingScore resolve(MatchingScore matchingSubscores);

    }
}
