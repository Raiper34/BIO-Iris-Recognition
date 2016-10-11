using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Comparator;

namespace BIO.Framework.Extensions.Standard.Comparator {
    public class MaxScoreSelector : ScoreSelector {

        protected override BIO.Framework.Core.Comparator.MatchingScore selectScoreInternally(IEnumerable<MatchingScore> scores) {
            return scores.Max();
        }
    }
}
