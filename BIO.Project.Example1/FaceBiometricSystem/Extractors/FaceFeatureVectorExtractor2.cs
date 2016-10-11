using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Extensions.Emgu.FeatureVector;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using BIO.Framework.Core.FeatureVector;

namespace BIO.Project.Example1 {
    class FaceFeatureVectorExtractor2 : IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> {
        #region IFeatureVectorExtractor<EmguGrayImageInputData,EmguGrayImageFeatureVector> Members

        public EmguGrayImageFeatureVector extractFeatureVector(EmguGrayImageInputData input) {
            
            Image<Gray, byte> smaller = input.Image.Resize(0.15, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            smaller._EqualizeHist();

            EmguGrayImageFeatureVector fv = new EmguGrayImageFeatureVector(new System.Drawing.Size(smaller.Width, smaller.Height));

            fv.FeatureVector = smaller.Copy();

            
            return fv;
        }

        #endregion
    }
}
