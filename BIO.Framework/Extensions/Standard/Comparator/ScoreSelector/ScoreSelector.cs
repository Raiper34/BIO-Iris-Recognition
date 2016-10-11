using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Comparator;

namespace BIO.Framework.Extensions.Standard.Comparator {
    public abstract class ScoreSelector : IScoreSelector {

        #region IScoreSelector Members

        protected abstract MatchingScore selectScoreInternally(IEnumerable<MatchingScore> scores);

        public MatchingScore selectScore(IEnumerable<MatchingScore> scores) {
            if (scores.Count() == 0) {
                throw new ArgumentException("ScoreSelector: No score within matching scores list");
            }
            return this.selectScoreInternally(scores);
        }

        #endregion
    }
}
