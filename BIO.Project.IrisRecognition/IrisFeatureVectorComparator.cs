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
using System.Collections;


namespace BIO.Project.IrisRecognition {
    
    class IrisFeatureVectorComparator : IFeatureVectorComparator<EmguGrayImageFeatureVector, EmguGrayImageFeatureVector> {

        public MatchingScore computeMatchingScore(EmguGrayImageFeatureVector extracted, EmguGrayImageFeatureVector templated) {
            Image<Gray, byte> m1 = extracted.FeatureVector.Clone();
            Image<Gray, byte> m2 = templated.FeatureVector.Clone();

            BitArray m1FvBits = this.createFeatureVectorBits(m1);
            BitArray m2FvBits = this.createFeatureVectorBits(m2);

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

            /************************************************************/
            String extractedIrisCode = "1100011101";
            String templatedIrisCode = "1011011101";
            int minimalHamming = 1000000;
            int actualHamming = 0;
            int suma = 0;
            for(int i = 0; i <= extractedIrisCode.Length; i++)
            {
                actualHamming = 0;
                suma = 0;
                for(int j = 0; j < templatedIrisCode.Length; j++)
                {
                    //XOR
                    if((extractedIrisCode[j] == '1' && extractedIrisCode[j] == '0') || (extractedIrisCode[j] == '0' && extractedIrisCode[j] == '1'))
                    {
                        suma++;
                    }
                }
                actualHamming = suma / templatedIrisCode.Length;
                if(actualHamming < minimalHamming)
                {
                    minimalHamming = actualHamming;
                }
                extractedIrisCode = extractedIrisCode.Substring(1, extractedIrisCode.Length - 1) + extractedIrisCode.Substring(0, 1);
            }
            //return new MatchingScore(minimalHamming);

            /***********************************************************/

            //draw.ROI = new System.Drawing.Rectangle();
            //ImageViewer.Show(draw, sum.ToString());

            return new MatchingScore(sum);
        }

        private BitArray createFeatureVectorBits(Image<Gray, Byte> m1)
        {
            IntPtr complexImage = CvInvoke.cvCreateImage(m1.Size, Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_32F, 2);
            CvInvoke.cvSetZero(complexImage);
            CvInvoke.cvSetImageCOI(complexImage, 1);
            CvInvoke.cvCopy(m1.Convert<Gray, float>(), complexImage, IntPtr.Zero);
            CvInvoke.cvSetImageCOI(complexImage, 0);
            Matrix<float> dft = new Matrix<float>(m1.Rows, m1.Cols, 2);
            CvInvoke.cvDFT(complexImage, dft, Emgu.CV.CvEnum.CV_DXT.CV_DXT_FORWARD, 0);

            Image<Gray, float> outReal = new Image<Gray, float>(m1.Size);
            Image<Gray, float> outImg = new Image<Gray, float>(m1.Size);

            CvInvoke.cvSplit(dft, outReal, outImg, IntPtr.Zero, IntPtr.Zero);

            //FOr cely obrazok, zistit znamienko img a real podla toho urob 1,2,3,4
            BitArray fVector = new BitArray(m1.Rows * m1.Cols * 2);

            float[,,] dataImg = outReal.Data;
            float[,,] dataReal = outImg.Data;

            for (int i = 0; i < m1.Rows; i++)
            {

                for (int j = 0; j < m1.Cols; j++)
                {
                    if (dataImg[i, j, 0] < 0)
                        fVector.Set(2 * (i * m1.Rows + j), false);
                    else
                        fVector.Set(2 * (i * m1.Rows + j), true);
                    if (dataReal[i, j, 0] < 0)
                        fVector.Set(2 * (i * m1.Rows + j) + 1, false);
                    else
                        fVector.Set(2 * (i * m1.Rows + j) + 1, true);
                }
            }
            return fVector;
        }
    }

    

       
}
