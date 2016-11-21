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

namespace BIO.Project.IrisRecognition
{
    class IrisFeatureVectorExtractor : IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> {

        public EmguGrayImageFeatureVector extractFeatureVector(EmguGrayImageInputData input) {
            
            //TODO
            //detect eye
            //detect pupil
            //delete all outer eye circle
            //delete all inside pupil
            //convert polar cords to cartesian cords = cvLogPolar

            Image<Gray, byte> smaller = input.Image.Resize(0.15, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

           
            EmguGrayImageFeatureVector fv = new EmguGrayImageFeatureVector(new System.Drawing.Size(smaller.Width, smaller.Height));

            fv.FeatureVector = smaller.Copy();

            /////////////////////////

            var test = input.Image.Clone();
            //var newimage = test.Resize(0.25, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC).SmoothGaussian(3);
            Gray cannyThreshold = new Gray(180);
            Gray cannyAccumulatorThreshold = new Gray(180);



            /*CircleF[] circles = test.HoughCircles(
                                         cannyThreshold,
                                         cannyAccumulatorThreshold,
                                         50,         //resoution of accumulator
                                         150,       //min distance between centers
                                         5,         //min radius
                                         300)[0];    //max radius*/



            //Create mask image with black backgound and white color and then bitwise_and
            /*Image<Gray, Byte> mask = new Image<Gray, Byte>(input.Image.Width, input.Image.Height);

            foreach (CircleF circle in circles)
            {
                mask.Draw(circle, new Gray(255), -1);


            }
            var result = test & mask;*/
            //result.LogPolar(128, 128);
            //result.Save(@"d:\db\face\2D\JAFFE\test1.jpg");

            ////////////////////////

            string[] parts = input.FileName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            String name = parts[parts.Length - 1];

            test._EqualizeHist();

            test.Save(@"d:\db\face\2D\JAFFE\processing00_" + name + ".jpg");

            Image<Gray, Byte> img2 = test.Not();

            StructuringElementEx element = new StructuringElementEx(3, 3, 1, 1, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_CROSS);
            CvInvoke.cvMorphologyEx(img2, img2, IntPtr.Zero, element, Emgu.CV.CvEnum.CV_MORPH_OP.CV_MOP_OPEN, 1);

            img2.Save(@"d:\db\face\2D\JAFFE\processing0_" + name + ".jpg");

            img2 = img2.Not();
            Emgu.CV.CvInvoke.cvThreshold(img2, img2, 150, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY); 

            img2.Save(@"d:\db\face\2D\JAFFE\processing1_" + name + ".jpg");

            CircleF[] circles = img2.HoughCircles(
                                         cannyThreshold,
                                         cannyAccumulatorThreshold,
                                         6,         //resoution of accumulator
                                         500,       //min distance between centers
                                         100,         //min radius
                                         130)[0];    //max radius
            Image<Gray, Byte> mask = new Image<Gray, Byte>(input.Image.Width, input.Image.Height);
            foreach (CircleF circle in circles)
            {
                mask.Draw(circle, new Gray(255), -1);


            }
            var result = test & mask;

            /*int x = 0;
            int y = 0;
            int h = 0;
            if (i > 0)
            {
                fil2.Apply(aq);
                x = fil2.BlobPosition.X;
                y = fil2.BlobPosition.Y;

                h = fil2.Apply(aq).Height;
            }*/

            result.Save(@"d:\db\face\2D\JAFFE\processing2_" + name + ".jpg");

            Image<Gray, Byte> polar = result.LogPolar(new System.Drawing.PointF(160, 140), 60, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, Emgu.CV.CvEnum.WARP.CV_WARP_DEFAULT);

            polar.Save(@"d:\db\face\2D\JAFFE\processing3_" + name + ".jpg");


            return fv;
        }

    }
}
