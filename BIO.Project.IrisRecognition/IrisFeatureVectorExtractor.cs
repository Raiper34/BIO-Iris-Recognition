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
            var test = input.Image.Clone();
            var test2 = input.Image.Clone();
            var original = input.Image.Clone();
            
            Image<Gray, Byte> mask = new Image<Gray, Byte>(input.Image.Width, input.Image.Height);

            //Iris
            Image<Gray, Byte> smooth = this.getIrisForContours(test);
            CvInvoke.cvInRangeS(smooth, new MCvScalar(0, 0, 0), new MCvScalar(70, 70, 70), test2);

            //Contours
            CircleF modifiedCircle = contourDetectionOfPupill(test2, original);
            mask.Draw(modifiedCircle, new Gray(255), -1);
            test2 = original & mask;

            //Polar mapping
            Image<Gray, Byte> polar = test2.LogPolar(new System.Drawing.PointF(modifiedCircle.Center.X, modifiedCircle.Center.Y), 65, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, Emgu.CV.CvEnum.WARP.CV_WARP_DEFAULT);
            Image<Gray, Byte> rotatedPolar = polar.Rotate(270, new Gray(255), false);
            var rotatedPolarOriginal = rotatedPolar.Clone();

            //Normalization
            byte[,,] originalData = rotatedPolarOriginal.Data;
            int widthOfNormalizedIris = rotatedPolar.Cols;
            int heigthOfNormalizedIris = 32;
            Image<Gray, Byte> normalizedIris = new Image<Gray, byte>(widthOfNormalizedIris, heigthOfNormalizedIris);
            byte[,,] data = normalizedIris.Data;
            rotatedPolar.Data = this.Normalization(rotatedPolar, data, originalData, heigthOfNormalizedIris, widthOfNormalizedIris);
            
            rotatedPolar._EqualizeHist();
            Image<Gray, Byte> smooth2 = rotatedPolar.Copy();
            smooth2._SmoothGaussian(3, 9, 10, 10);
            originalData = smooth2.Clone().Data;
            data = smooth2.Data;

            //LBP
            data = this.getLBP(smooth2, originalData, data);
            Gray avg = smooth2.GetAverage();
            smooth2._ThresholdBinary(smooth2.GetAverage(), new Gray(255));

            //Feature vector
            EmguGrayImageFeatureVector fv = new EmguGrayImageFeatureVector(new System.Drawing.Size(polar.Width, polar.Height));
            fv.FeatureVector = smooth2.Copy();
            return fv;
        }

        public Image<Gray, Byte> getIrisForContours(Image<Gray, Byte> img)
        {
            img._EqualizeHist();
            Emgu.CV.CvInvoke.cvThreshold(img, img, 30, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(img, img, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvThreshold(img, img, 30, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(img, img, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvThreshold(img, img, 30, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(img, img, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvThreshold(img, img, 30, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(img, img, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvThreshold(img, img, 30, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(img, img, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvThreshold(img, img, 230, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY);
            Emgu.CV.CvInvoke.cvSmooth(img, img, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            Emgu.CV.CvInvoke.cvSmooth(img, img, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_GAUSSIAN, 9, 9, 2, 2);
            return img.Not();
        }

        public CircleF contourDetectionOfPupill(Image<Gray, Byte> img, Image<Gray, Byte> originalImg)
        {
            MCvMoments momets;
            PointF center = new PointF();
            CircleF centerCircle = new CircleF();
            int pupilMinArea = 2000;
            int pupilMaxArea = 10000;
            img = img.Not();
            Contour<Point> conturs = img.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE);
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
                    centerCircle = new CircleF(center, (float)(conturs.Perimeter * 0.17));
                    break;
                }
                conturs = conturs.HNext;
            }
            originalImg.Draw(centerCircle, new Gray(0), -1);
            CircleF modifiedCircle = new CircleF(center, 100);
            return modifiedCircle;
        }

        public byte[,,] Normalization(Image<Gray, Byte> rotatedPolar, byte[,,] data, byte[,,] originalData, int heigthOfNormalizedIris, int widthOfNormalizedIris)
        {
            int rows = rotatedPolar.Rows - 1;
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
                    if (bottomLine != rows && i >= (bottomLine - heigthOfNormalizedIris))
                        data[normalizedIrisX, normalizedIrisY++, 0] = originalData[i, j, 0];
                }
                if (bottomLine != rows)
                    normalizedIrisX++;
                normalizedIrisY = 0;
                if (countOfDataInRow >= widthOfNormalizedIris)
                    bottomLine = i;
            }
            return data;
        }

        public byte[,,] getLBP(Image<Gray, Byte> img, byte[,,] originalData, byte[,,] data)
        {
            //Inspired by:http://www.bytefish.de/blog/local_binary_patterns/
            for (int i = 1; i < img.Rows - 1; i++)
            {
                for (int j = 1; j < img.Cols - 1; j++)
                {
                    Byte centerByte = originalData[i, j, 0];
                    Byte code = 0;
                    code |= (Byte)(Convert.ToByte(originalData[i - 1, j - 1, 0] > centerByte) << 7);
                    code |= (Byte)(Convert.ToByte(originalData[i - 1, j, 0] > centerByte) << 6);
                    code |= (Byte)(Convert.ToByte(originalData[i - 1, j + 1, 0] > centerByte) << 5);
                    code |= (Byte)(Convert.ToByte(originalData[i, j + 1, 0] > centerByte) << 4);
                    code |= (Byte)(Convert.ToByte(originalData[i + 1, j + 1, 0] > centerByte) << 3);
                    code |= (Byte)(Convert.ToByte(originalData[i + 1, j, 0] > centerByte) << 2);
                    code |= (Byte)(Convert.ToByte(originalData[i + 1, j - 1, 0] > centerByte) << 1);
                    code |= (Byte)(Convert.ToByte(originalData[i, j - 1, 0] > centerByte) << 0);
                    data[i, j, 0] = code;
                }
            }
            return data;
        }


    }
}
