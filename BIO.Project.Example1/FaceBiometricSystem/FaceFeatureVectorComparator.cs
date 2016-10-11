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
using BIO.Framework.Core;


namespace BIO.Project.Example1.FaceBiometricSystem {
    
    class FaceFeatureVectorComparator : IFeatureVectorComparator<EmguGrayImageFeatureVector, EmguGrayImageFeatureVector> {

        #region IFeatureVectorComparator<EmguGrayImageFeatureVector,EmguGrayImageFeatureVector> Members

        public MatchingScore computeMatchingScore(EmguGrayImageFeatureVector extracted, EmguGrayImageFeatureVector templated) {
            Image<Gray, byte> m1 = extracted.FeatureVector.Clone();
            Image<Gray, byte> m2 = templated.FeatureVector.Clone();
            
            //Image<Gray, byte> m1c = m1.Resize(4.0, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //Image<Gray, byte> m2c = m2.Resize(4.0, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //Image<Gray, byte> draw = new Image<Gray, byte>(500, 500);

            //draw.ROI = new System.Drawing.Rectangle(0, 0, m1c.Width, m2c.Height);
            //m1c.CopyTo(draw);

            //draw.ROI = new System.Drawing.Rectangle(m1c.Width, 0, m1c.Width, m2c.Height);
            //m2c.CopyTo(draw);
            

            m1 = m1.AbsDiff(m2);
            
            //draw.ROI = new System.Drawing.Rectangle(0, m1c.Height, m1c.Width, m2c.Height);
            //m1.Resize(4.0, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC).CopyTo(draw);
            

            double sum = 0;
            byte[,,] data = m1.Data;

           
            for (int i = m1.Rows - 1; i >= 0; i--){
            for (int j = m1.Cols - 1; j >= 0; j--){
                sum += data[i,j,0];
            }
            }
            
            //draw.ROI = new System.Drawing.Rectangle();
            //ImageViewer.Show(draw, sum.ToString());
            
            return new MatchingScore(sum);
        }

        #endregion
    }

       
}
