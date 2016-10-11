using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.Comparator {
    public class SquareErrorDoubleArrayFeatureVectorComparator : DoubleArrayFeatureVectorComaprator {

        protected override double internalComputeMatchingScore(FeatureVector.DoubleArrayFeatureVector extracted, FeatureVector.DoubleArrayFeatureVector templated) {
            double sum = 0;
            for (int i = 0; i < extracted.FeatureVector.Length; i++) { 
                double diff = extracted.FeatureVector[i] - templated.FeatureVector[i];
                sum += diff * diff;
            }
            return sum;
        }
    }
}
