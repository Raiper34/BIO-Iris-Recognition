using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Comparator {
    public interface IComparator<TEvaluatedFeatureVector, TTemplate, TTemplatedFeatureVector> 
        where TEvaluatedFeatureVector : FeatureVector.IFeatureVector
        where TTemplate : Template.ITemplate<TTemplatedFeatureVector>
        where TTemplatedFeatureVector : FeatureVector.IFeatureVector
    {
        /// <summary>
        /// compute matching score between two feature vectors
        /// </summary>
        /// <param name="extracted">extracted fv from current input data</param>
        /// <param name="templated">fv loadded from template</param>
        /// <returns>matching score</returns>
        MatchingScore computeMatchingScore(TEvaluatedFeatureVector extracted, TTemplate template);
    }
}
