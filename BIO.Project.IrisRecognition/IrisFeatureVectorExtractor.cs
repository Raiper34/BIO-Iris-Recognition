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

            var test = input.Image.Clone();

            Gray cannyThreshold = new Gray(180);
            Gray cannyAccumulatorThreshold = new Gray(180);

            string[] parts = input.FileName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            String name = parts[parts.Length - 1];

            //Equalize Hist
            test._EqualizeHist();

            test.Save(@"d:\db\face\2D\JAFFE\processing00_" + name + ".jpg");

            //Morfology transformation
            Image<Gray, Byte> img2 = test.Copy();
            /*Image<Gray, Byte> img2 = test.Not();

            StructuringElementEx element = new StructuringElementEx(3, 3, 1, 1, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_CROSS);
            CvInvoke.cvMorphologyEx(img2, img2, IntPtr.Zero, element, Emgu.CV.CvEnum.CV_MORPH_OP.CV_MOP_OPEN, 1);

            img2.Save(@"d:\db\face\2D\JAFFE\processing0_" + name + ".jpg");*/

            //Contours
            /*Image<Gray, Byte> canny = new Image<Gray, byte>(test.Size);
             using (MemStorage storage = new MemStorage())
                 for (Contour<System.Drawing.Point> contours = test.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, storage); contours != null; contours = contours.HNext)
                 {
                     //Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);
                     CvInvoke.cvDrawContours(canny, contours, new MCvScalar(255), new MCvScalar(255), -1, 1, Emgu.CV.CvEnum.LINE_TYPE.EIGHT_CONNECTED, new System.Drawing.Point(0, 0));
                 }
             using (MemStorage store = new MemStorage())
                 for (Contour<System.Drawing.Point> contours1 = test.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, store); contours1 != null; contours1 = contours1.HNext)
                 {
                     System.Drawing.Rectangle r = CvInvoke.cvBoundingRect(contours1, 1);
                     canny.Draw(r, new Gray(255), 1);
                 }
             canny.Save(@"d:\db\face\2D\JAFFE\processing9_" + name + ".jpg");*/

            //Invert colors
            //img2 = img2.Not();
            Emgu.CV.CvInvoke.cvThreshold(img2, img2, 150, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY); 

            img2.Save(@"d:\db\face\2D\JAFFE\processing1_" + name + ".jpg");

            //Find circle 
            CircleF[] circles = img2.HoughCircles(
                                         cannyThreshold,
                                         cannyAccumulatorThreshold,
                                         6,         //resoution of accumulator
                                         500,       //min distance between centers
                                         100,         //min radius
                                         130)[0];    //max radius

            //Draw mask
            Image<Gray, Byte> mask = new Image<Gray, Byte>(input.Image.Width, input.Image.Height);
            foreach (CircleF circle in circles)
            {
                CircleF modifiedCircle = circle;
                modifiedCircle.Radius = modifiedCircle.Radius * 0.9f;
                mask.Draw(modifiedCircle, new Gray(255), -1);
            }

            //Use mask
            var result = test & mask;

            result.Save(@"d:\db\face\2D\JAFFE\processing2_" + name + ".jpg");


            //Move matrix
            Matrix<int> matrix = new Matrix<int>(2, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = 50;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = 0;

            //Emgu.CV.CvInvoke.cvWarpAffine(test, test, matrix, 10, new Emgu.CV.Structure.MCvScalar(0,0,0));
            result.Save(@"d:\db\face\2D\JAFFE\processing22_" + name + ".jpg");

            //Polar mapping
            Image<Gray, Byte> polar = result.LogPolar(new System.Drawing.PointF(175, 140), 60, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, Emgu.CV.CvEnum.WARP.CV_WARP_DEFAULT);

            polar.Save(@"d:\db\face\2D\JAFFE\processing3_" + name + ".jpg");


            return fv;
        }

    }
}
