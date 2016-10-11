using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Extensions.Standard.FeatureVector;

namespace BIO.Framework.Extensions.Standard.Comparator {
    public abstract class DoubleArrayFeatureVectorComaprator : 
        IFeatureVectorComparator <
            DoubleArrayFeatureVector, 
            DoubleArrayFeatureVector
        > {
        #region IFeatureVectorComparator<DoubleArrayFeatureVector,DoubleArrayFeatureVector> Members

        public MatchingScore computeMatchingScore(DoubleArrayFeatureVector extracted, DoubleArrayFeatureVector templated) {
            return new MatchingScore(this.internalComputeMatchingScore(extracted, templated));    
        }

        protected abstract double internalComputeMatchingScore(DoubleArrayFeatureVector extracted, DoubleArrayFeatureVector templated);

        #endregion
    }
}
