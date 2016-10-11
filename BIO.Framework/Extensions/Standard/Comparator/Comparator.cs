using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Core.FeatureVector;
using BIO.Framework.Core.Template;
using BIO.Framework.Core;
using BIO.Framework.Extensions.Standard.Template;

namespace BIO.Framework.Extensions.Standard.Comparator {
    public class Comparator<TEvaluatedFeatureVector, TTemplate, TTemplatedFeatureVector> :
        IComparator<TEvaluatedFeatureVector, TTemplate, TTemplatedFeatureVector>
        where TEvaluatedFeatureVector : IFeatureVector
        where TTemplate : ITemplate<TTemplatedFeatureVector>
        where TTemplatedFeatureVector : IFeatureVector
    {

        IFeatureVectorComparator<TEvaluatedFeatureVector, TTemplatedFeatureVector> featureComparator = null;
        IScoreSelector scoreSelector = null;

        /// <summary>
        /// create tempalte feature comparator
        /// </summary>
        /// <param name="featureComparator"></param>
        /// <param name="scoreSelector"></param>
        public Comparator(IFeatureVectorComparator<TEvaluatedFeatureVector, TTemplatedFeatureVector> featureComparator, IScoreSelector scoreSelector){
            this.featureComparator = featureComparator;
            this.scoreSelector = scoreSelector;
        }

        /// <summary>
        /// create tempalte feature comparator
        /// </summary>
        /// <param name="featureComparator"></param>
        /// <param name="scoreSelector"></param>
        public Comparator(IFeatureVectorComparator<TEvaluatedFeatureVector, TTemplatedFeatureVector> featureComparator) {
            this.featureComparator = featureComparator;
            this.scoreSelector = new MinScoreSelector();
        }

        #region IComparator<TEvaluatedFeatureVector,TTemplatedFeatureVector,TTemplate> Members

        public MatchingScore computeMatchingScore(TEvaluatedFeatureVector extracted, TTemplate template) {
            List<MatchingScore> matchingScores = new List<MatchingScore>();
            foreach (TTemplatedFeatureVector t in template) {
                matchingScores.Add(this.featureComparator.computeMatchingScore(extracted, t));
            }
            return scoreSelector.selectScore(matchingScores);
        }

        #endregion
    }

    public class Comparator<
            TEvaluatedFeatureVector,
            TTemplatedFeatureVector> :
        Comparator<
            TEvaluatedFeatureVector,
            Template<TTemplatedFeatureVector>,
            TTemplatedFeatureVector
        >
        where TEvaluatedFeatureVector : IFeatureVector
        where TTemplatedFeatureVector : IFeatureVector {

        /// <summary>
        /// create tempalte feature comparator
        /// </summary>
        /// <param name="featureComparator"></param>
        /// <param name="scoreSelector"></param>
        public Comparator(IFeatureVectorComparator<TEvaluatedFeatureVector, TTemplatedFeatureVector> featureComparator, IScoreSelector scoreSelector)
            : base(featureComparator, scoreSelector) {
        }

        /// <summary>
        /// create tempalte feature comparator
        /// </summary>
        /// <param name="featureComparator"></param>
        /// <param name="scoreSelector"></param>
        public Comparator(IFeatureVectorComparator<TEvaluatedFeatureVector, TTemplatedFeatureVector> featureComparator)
            : base(featureComparator) {
        }


    }
    
}
