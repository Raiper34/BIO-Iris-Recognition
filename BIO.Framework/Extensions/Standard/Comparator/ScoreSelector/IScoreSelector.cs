using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core;
using BIO.Framework.Core.Comparator;

namespace BIO.Framework.Extensions.Standard.Comparator {
    public interface IScoreSelector {
        /// <summary>
        /// select score from buffer
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        MatchingScore selectScore(IEnumerable<MatchingScore> scores);
    }
}
