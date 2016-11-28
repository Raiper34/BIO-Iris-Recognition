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

            //Marek
            /*BitArray m1FvBits = this.createFeatureVectorBits(m1);
            BitArray m2FvBits = this.createFeatureVectorBits(m2);*/

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

            //Marek
            /*m1FvBits.Xor(m2FvBits);
            //Treba dorobit for, a shiftovanie / rotovanie tych poli a ziskanie najnizsej hammingovej vzdialenosti
            int hammingDistance = this.countOfBitsSet(m1FvBits);*/

            //Console.WriteLine(hammingDistance);

            for (int i = m1.Rows - 1; i >= 0; i--){
            for (int j = m1.Cols - 1; j >= 0; j--){
                sum += data[i,j,0];
            }
            }

            /************************************************************/
            String extractedIrisCode = this.getIrisCode(extracted);
            String templatedIrisCode = this.getIrisCode(templated);
            //Console.WriteLine(extractedIrisCode + "X" + templatedIrisCode);

            double minimalHamming = 1000.0;
            double actualHamming = 0.0;
            double suma = 0.0;
            for(int i = 0; i <= extractedIrisCode.Length; i++)
            {
                actualHamming = 0.0;
                suma = 0.0;
                for(int j = 0; j < templatedIrisCode.Length; j++)
                {
                    //XOR
                    if((extractedIrisCode[j] == '1' && templatedIrisCode[j] == '0') || (extractedIrisCode[j] == '0' && templatedIrisCode[j] == '1'))
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
            //Console.WriteLine(minimalHamming);
            return new MatchingScore(minimalHamming);

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

        private int countOfBitsSet(BitArray myBitArray)
        {
            int bits = myBitArray.Count,
            size = ((bits - 1) >> 3) + 1,
            counter = 0,
            x,
            c;

            byte[] buffer = new byte[size];
            myBitArray.CopyTo(buffer, 0);

            for (x = 0; x < size; x++)
                for (c = 0; buffer[x] > 0; buffer[x] >>= 1)
                    counter += buffer[x] & 1;

            return counter;
        }

        private String getIrisCode(EmguGrayImageFeatureVector vector)
        {
            Image<Gray, byte> rotatedPolar = vector.FeatureVector.Clone();
            //Iris code generation
            String irisCode = "";
            Image<Gray, Byte> area = rotatedPolar.Copy();
            String pixelValue = "0";
            int blackCounter = 0;
            int whiteCounter = 0;
            for (int i = 0; i < 70; i++)
            {
                blackCounter = 0;
                whiteCounter = 0;
                CvInvoke.cvSetImageROI(rotatedPolar, new System.Drawing.Rectangle(new System.Drawing.Point(4 * i, 0), new System.Drawing.Size(4, area.Height)));
                CvInvoke.cvCopy(rotatedPolar, rotatedPolar, new IntPtr(0));
                area = rotatedPolar.Copy();
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < area.Height; y++)
                    {
                        pixelValue = area.Data[y, x, 0].ToString();
                        if (Int32.Parse(pixelValue) > 170)
                        {
                            blackCounter++;
                        }
                        else
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
                CvInvoke.cvResetImageROI(rotatedPolar);
            }
            return irisCode;
        }
        
    }

    

       
}
