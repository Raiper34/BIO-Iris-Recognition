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
using System.Drawing;

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

            var test = input.Image.Clone();
            var test2 = input.Image.Clone();
            var original = input.Image.Clone();

            //Gray cannyThreshold = new Gray(180);
            //Gray cannyAccumulatorThreshold = new Gray(180);

            string[] parts = input.FileName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            String name = parts[parts.Length - 1];

            //Equalize Hist
            //test._EqualizeHist();

            //var test2 = test.Copy();

            //test.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1processing00_" + name + ".jpg");

            //Morfology transformation
            //Image<Gray, Byte> img2 = test.Copy();
            /*Image<Gray, Byte> img2 = test.Not();

            StructuringElementEx element = new StructuringElementEx(3, 3, 1, 1, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_CROSS);
            CvInvoke.cvMorphologyEx(img2, img2, IntPtr.Zero, element, Emgu.CV.CvEnum.CV_MORPH_OP.CV_MOP_OPEN, 1);

            img2.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1processing0_" + name + ".jpg");*/

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
             canny.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1processing9_" + name + ".jpg");*/

            //Invert colors
            //img2 = img2.Not();
            //Emgu.CV.CvInvoke.cvThreshold(img2, img2, 150, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY); 

            //img2.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1processing1_" + name + ".jpg");

            //Find circle 
            /*CircleF[] circles = img2.HoughCircles(
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

            result.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1processing2_" + name + ".jpg");*/


            //Move matrix
            /*Matrix<int> matrix = new Matrix<int>(2, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = 50;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = 0;*/

            //Emgu.CV.CvInvoke.cvWarpAffine(test, test, matrix, 10, new Emgu.CV.Structure.MCvScalar(0,0,0));
            //result.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1/processing22_" + name + ".jpg");

            //Pupill center
            /*********************************************************************/
            //result = result.Not();
            test._EqualizeHist();  
            //test.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1processing1_" + name + ".jpg");
            Emgu.CV.CvInvoke.cvThreshold(test, test, 30, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(test, test, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvThreshold(test, test, 30, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(test, test, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvThreshold(test, test, 30, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(test, test, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvThreshold(test, test, 30, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(test, test, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvThreshold(test, test, 30, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(test, test, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvThreshold(test, test, 230, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(test, test, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvSmooth(test, test, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            
            /*Gray cannyThreshold2 = new Gray(200);
            Gray cannyAccumulatorThreshold2 = new Gray(100);
            CircleF[] circles2 = test.HoughCircles(
                                         cannyThreshold2,
                                         cannyAccumulatorThreshold2,
                                         1.7,         //resoution of accumulator
                                         test.Rows/4,       //min distance between centers
                                         0,         //min radius
                                         0)[0];    //max radius

            //Draw mask
            Image<Gray, Byte> mask = new Image<Gray, Byte>(input.Image.Width, input.Image.Height);
            CircleF modifiedCircle = new CircleF();
            foreach (CircleF circle in circles2)
            {
                modifiedCircle = circle;
                //modifiedCircle.Radius = modifiedCircle.Radius * 1.15f;
                modifiedCircle.Radius = modifiedCircle.Radius + 70;
                mask.Draw(modifiedCircle, new Gray(255), -1);
            }*/
            Image<Gray, Byte> mask = new Image<Gray, Byte>(input.Image.Width, input.Image.Height);
            Image<Gray, Byte> smooth = test.Not();

            //Image<Gray, Byte> smooth = test2.Clone();
            //smooth = smooth.SmoothGaussian(9);
            //smooth.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1\smoothGgausa_" + name + ".jpg");
            //test2.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1\original_" + name + ".jpg");
            //smooth.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1\invertedTest" + name + ".jpg");
            MCvScalar lowerBoundary = new MCvScalar(0, 0, 0);

            CvInvoke.cvInRangeS(smooth, lowerBoundary, new MCvScalar(70, 70, 70), test2);
            //smooth.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1\smoothAfterInRange" + name + ".jpg");
            //test2.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1\testAFterInRange" + name + ".jpg");

            MCvMoments momets;
            PointF center = new PointF();
            CircleF centerCircle = new CircleF();
            int pupilMinArea = 2000;
            int pupilMaxArea = 10000;
            test2 = test2.Not();
            Contour<Point> conturs = test2.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE);
            while (conturs != null)
            {
                momets = conturs.GetMoments();

                double conturArea = momets.GetCentralMoment(0, 0);

                if (conturs.Total > 1)
                {
                    if (conturArea > pupilMaxArea || conturArea < pupilMinArea)
                    {
                        conturs = conturs.HNext;
                        continue;
                    }
                }

                if (conturArea > pupilMinArea)
                {
                    double x = momets.GetSpatialMoment(1, 0) / conturArea;
                    double y = momets.GetSpatialMoment(0, 1) / conturArea;
                    center = new PointF((float)x, (float)y);
                    centerCircle = new CircleF(center, (float) (conturs.Perimeter * 0.17));
                    //Emgu.CV.CvInvoke.cvDrawContours(test, conturs, color, color, 10000, 1, Emgu.CV.CvEnum.LINE_TYPE.EIGHT_CONNECTED, offset);
                    //original.Draw(conturs, new Gray(255), 2);
                    //original.Draw(new CircleF(center, 10), new Gray(255), -1);
                    //original.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1\CONTURS" + name + ".jpg");
                    break;
                }
                conturs = conturs.HNext;
            }
            original.Draw(centerCircle, new Gray(0), -1);
            original.Save(@"d:\db\face\2D\JAFFE\out\processing1_" + name + ".jpg");
            CircleF modifiedCircle = new CircleF(center, 100);
            mask.Draw(modifiedCircle, new Gray(255), -1);


            test2 = original & mask;

            //test2.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1\processing987_" + name + ".jpg");

            /*********************************************************************/

            //Polar mapping
            Image<Gray, Byte> polar = test2.LogPolar(new System.Drawing.PointF(modifiedCircle.Center.X, modifiedCircle.Center.Y), 65, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, Emgu.CV.CvEnum.WARP.CV_WARP_DEFAULT);

            //polar.Save(@"C:\Users\archie\Desktop\CASIA-IrisV1\processing3_" + name + ".jpg");
            Image<Gray, Byte> rotatedPolar = polar.Rotate(270, new Gray(255), false);
            rotatedPolar.Save(@"d:\db\face\2D\JAFFE\out\processing2_" + name + ".jpg");
            var rotatedPolarOriginal = rotatedPolar.Clone();

            byte[,,] originalData = rotatedPolarOriginal.Data;

            int widthOfNormalizedIris = rotatedPolar.Cols;
            int heigthOfNormalizedIris = 32;
            Image<Gray, Byte> normalizedIris = new Image<Gray, byte>(widthOfNormalizedIris, heigthOfNormalizedIris);
            byte[,,] data = normalizedIris.Data;


            int rows = rotatedPolar.Rows - 1;
            int bottom = rows;
            int bottomLine = rows;
            int countOfDataInRow = 0;

            
            
            int treshold = 40;
            int normalizedIrisX = 0;
            int normalizedIrisY = 0;

            for (int i = rotatedPolar.Rows - 1; i >= 0; i--)
            {
                countOfDataInRow = 0;
                
                for (int j = rotatedPolar.Cols - 1; j >= 0; j--)
                {
                    if (bottomLine == rows && originalData[i, j, 0] > treshold)
                        countOfDataInRow++;
                    if (bottomLine != rows && i >= (bottomLine - heigthOfNormalizedIris) )
                        data[normalizedIrisX, normalizedIrisY++, 0] = originalData[i, j, 0];
                }
                if (bottomLine != rows)
                    normalizedIrisX++;
                normalizedIrisY = 0;
                if (countOfDataInRow >= widthOfNormalizedIris)
                    bottomLine = i;

            }

            rotatedPolar.Data = data;

            rotatedPolar.Save(@"d:\db\face\2D\JAFFE\out\processing3_" + name + ".jpg");

            rotatedPolar._EqualizeHist();


            //Iris code generation
            String irisCode = "";
            Image<Gray, Byte> area = rotatedPolar.Copy();
            String pixelValue = "0";
            int blackCounter = 0;
            int whiteCounter = 0;
            for (int i = 0; i < 20; i++)
            {
                blackCounter = 0;
                whiteCounter = 0;
                CvInvoke.cvSetImageROI(rotatedPolar, new System.Drawing.Rectangle(new System.Drawing.Point(14 * i, 0), new System.Drawing.Size(14, area.Height)));
                CvInvoke.cvCopy(rotatedPolar, rotatedPolar, new IntPtr(0));
                area = rotatedPolar.Copy();
                for (int x = 0; x < 14; x++)
                {
                    for (int y = 0; y < area.Height; y++)
                    {
                        pixelValue = area.Data[y, x, 0].ToString(); ;
                        if (pixelValue == "0")
                        {
                            blackCounter++;
                        }
                        else if (pixelValue == "255")
                        {
                            whiteCounter++;
                        }
                    }
                }
                if (blackCounter > whiteCounter)
                {
                    irisCode += "0";
                }
                else
                {
                    irisCode += "1";
                }
                CvInvoke.cvResetImageROI(test);
            }
            Console.WriteLine("Iris code: " + irisCode);



            EmguGrayImageFeatureVector fv = new EmguGrayImageFeatureVector(new System.Drawing.Size(polar.Width, polar.Height));
            fv.FeatureVector = normalizedIris.Copy();
            return fv;
        }

    }
}
