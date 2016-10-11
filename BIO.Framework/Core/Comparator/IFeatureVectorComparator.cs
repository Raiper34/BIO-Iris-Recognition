using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Comparator {
    public interface IFeatureVectorComparator<TEvaluatedFeatureVector, TTemplatedFeatureVector> 
        where TEvaluatedFeatureVector : FeatureVector.IFeatureVector
        where TTemplatedFeatureVector : FeatureVector.IFeatureVector
    {
        /// <summary>
        /// compute matching score between two feature vectors
        /// </summary>
        /// <param name="extracted">extracted fv from current input data</param>
        /// <param name="templated">template</param>
        /// <returns>matching score</returns>
        MatchingScore computeMatchingScore(TEvaluatedFeatureVector extracted, TTemplatedFeatureVector templated);
    }
}
