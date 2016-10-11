using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Comparator {
    public class MatchingScore : IComparable<MatchingScore> {

        double score = Double.NaN;

        /// <summary>
        /// get mathcing score
        /// </summary>
        public double Score {
            get { return score; }
        }
        /// <summary>
        /// get if score is invalid
        /// </summary>
        public bool IsValid {
            get {
                return !Double.IsNaN(score);
            }
        }

        /// <summary>
        /// construct invalid score
        /// </summary>
        /// <param name="score"></param>
        private MatchingScore() {
        }

        public static MatchingScore invalid() {
            return new MatchingScore();
        }

        /// <summary>
        /// construct with one param
        /// </summary>
        /// <param name="score"></param>
        public MatchingScore(double score) {
            this.score = score;
        }

        public MatchingScore clone() {
            return (MatchingScore)this.MemberwiseClone();
        }

        public MatchingScore cloneWithDifferentScore(double value) {
            MatchingScore ms = this.clone();
            ms.score = value;
            return ms;
        }

        #region Subscores

        /// <summary>
        /// matching subscores -> use if you really need it
        /// </summary>
        Dictionary<string, MatchingScore> matchingSubscores = new Dictionary<string, MatchingScore>();

        public IEnumerable<string> getSubscoreNames() {
            return this.matchingSubscores.Keys;
        }

        public MatchingScore getSubscore(string name) {
            return matchingSubscores[name];
        }

        public void addSubscore(string name, MatchingScore subscore) {
            this.matchingSubscores.Add(name, subscore);
        }

        #endregion

        #region IComparable<MatchingScore> Members

        public int CompareTo(MatchingScore other) {
            return this.score.CompareTo(other.score);
        }

        #endregion

        
    }
}
