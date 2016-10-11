using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Comparator;

namespace BIO.Framework.Extensions.Standard.Comparator {
    public class MinScoreSelector : ScoreSelector {

        protected override MatchingScore selectScoreInternally(IEnumerable<MatchingScore> scores) {
            return scores.Min();
        }
    }
}
