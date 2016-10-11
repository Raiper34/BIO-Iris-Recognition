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

using BIO.Framework.Extensions.Standard.FeatureVector;
using BIO.Framework.Core.FeatureVector;

namespace BIO.Project.Example2.Simple {
    class FaceFeatureVectorExtractor : IFeatureVectorExtractor<EmguGrayImageInputData, DoubleArrayFeatureVector> {


        #region IFeatureVectorExtractor<EmguGrayImageInputData,DoubleArrayFeatureVector> Members

        public DoubleArrayFeatureVector extractFeatureVector(EmguGrayImageInputData input) {
           
            //same as in example 1
            
            Image<Gray, byte> smaller = input.Image.Resize(0.15, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            smaller._SmoothGaussian(3);
            smaller._EqualizeHist();

            DoubleArrayFeatureVector fv = new DoubleArrayFeatureVector(smaller.Width * smaller.Height);

            for (int y = 0; y < smaller.Height; y++) {
                for (int x = 0; x < smaller.Width; x++) {
                    int index = y * smaller.Width + x;
                    fv.FeatureVector[index] = smaller[y, x].Intensity;
                }
            }

            return fv;
        }

        #endregion
    }
}
