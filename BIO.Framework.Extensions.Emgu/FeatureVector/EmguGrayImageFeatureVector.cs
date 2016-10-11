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
    public class EmguGrayImageFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector {
        private Image<Gray, byte> featureVector = null;
        public Image<Gray, byte> FeatureVector {
            get { return featureVector; }
            set { featureVector = value; }
        }

        public EmguGrayImageFeatureVector(Size featureVectorSize) {
            featureVector = new Image<Gray, byte>(featureVectorSize);
        }
        public EmguGrayImageFeatureVector() {
            featureVector = new Image<Gray, byte>(new Size(1,1));
        }
    }
}
