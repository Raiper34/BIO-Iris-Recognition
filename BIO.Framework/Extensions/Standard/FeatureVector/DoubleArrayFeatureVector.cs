using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.FeatureVector {
    [Serializable]
    public class DoubleArrayFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector {
        private double[] featureVector;

        public double[] FeatureVector {
            get { return featureVector; }
            set { featureVector = value; }
        }

        public DoubleArrayFeatureVector(int featureVectorSize) {
            featureVector = new double[featureVectorSize];
        }
        public DoubleArrayFeatureVector(double[] featureVector) {
            this.featureVector = featureVector;
        }
    }
}
