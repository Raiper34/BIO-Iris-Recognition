using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Extensions.Emgu.FeatureVector;
using BIO.Framework.Extensions.Standard.Template;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.UI;
using BIO.Framework.Extensions.Standard.FeatureVector;
using BIO.Framework.Core;


namespace BIO.Project.Example2 {

    class FaceFeatureVectorComparator : IFeatureVectorComparator<DoubleArrayFeatureVector, DoubleArrayFeatureVector> {


        #region IFeatureVectorComparator<DoubleArrayFeatureVector,DoubleArrayFeatureVector> Members

        public MatchingScore computeMatchingScore(DoubleArrayFeatureVector extracted, DoubleArrayFeatureVector templated) {
            if (extracted.FeatureVector.Length != templated.FeatureVector.Length) {
                throw new ArgumentException("FaceFeatureVectorComparator vector length differs");
            }
            double error = 0;
            for (int i = 0; i < extracted.FeatureVector.Length; i++) {
                double diff = extracted.FeatureVector[i] - templated.FeatureVector[i];
                error += diff * diff;
            }
            return new MatchingScore(error);
        }

        #endregion
    }

       
}
