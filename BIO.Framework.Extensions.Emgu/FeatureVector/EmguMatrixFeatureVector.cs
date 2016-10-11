using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using Emgu.CV.CvEnum;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace BIO.Framework.Extensions.Emgu.FeatureVector {
    [Serializable]
    public class EmguMatrixFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector {
        private Matrix<Double> featureVector;
        public Matrix<Double> FeatureVector {
            get { return featureVector; }
        }

        public EmguMatrixFeatureVector(Size featureVectorSize) {
            featureVector = new Matrix<double>(featureVectorSize);
        }
    }
}
