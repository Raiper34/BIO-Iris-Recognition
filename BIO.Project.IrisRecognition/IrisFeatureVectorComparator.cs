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

        /**
         * Method to compute matching score from extracted image feature vector and template image feature vector 
         */
        public MatchingScore computeMatchingScore(EmguGrayImageFeatureVector extracted, EmguGrayImageFeatureVector templated) {
            Image<Gray, byte> m1 = extracted.FeatureVector.Clone();
            Image<Gray, byte> m2 = templated.FeatureVector.Clone();
            double maxSum = this.hammingDistance(m1, m2);
            return new MatchingScore(maxSum);
        }


        /*
         * Method that count how much bits are set to 1
         * Source: http://stackoverflow.com/questions/5063178/counting-bits-set-in-a-net-bitarray-class
         */ 
        private static Int32 countOfBitsSet(BitArray bitArray)
        {

            Int32[] ints = new Int32[(bitArray.Count >> 5) + 1];
            bitArray.CopyTo(ints, 0);
            Int32 count = 0;

            // fix for not truncated bits in last integer that may have been set to true with SetAll()
            ints[ints.Length - 1] &= ~(-1 << (bitArray.Count % 32));

            for (Int32 i = 0; i < ints.Length; i++)
            {
                Int32 c = ints[i];
                // magic (http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel)
                unchecked
                {
                    c = c - ((c >> 1) & 0x55555555);
                    c = (c & 0x33333333) + ((c >> 2) & 0x33333333);
                    c = ((c + (c >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
                }
                count += c;
            }
            return count;
        }

        /**
         * Method thah count hamming distance from two images m1 and m2
         **/
        private double hammingDistance(Image<Gray, byte> img1, Image<Gray, byte> img2)
        {
            double sum = 0;
            byte[,,] data = img1.Rotate(90, new Gray(255), false).Data;

            //Matrix<byte> transaltionMatrix = new Matrix<byte>(1,1);
            //transaltionMatrix.SetZero();


            BitArray bitsExtracted = new BitArray(img1.Bytes);
            BitArray bitsXored = new BitArray(img1.Bytes);
            BitArray bitsTemplated = new BitArray(img2.Bytes);

            bitsXored.Xor(bitsTemplated);
            double maxSum = countOfBitsSet(bitsXored);
            sum = maxSum;
            for (int i = 1; i < img1.Cols; i++)
            {
                Array.Copy(img1.Data, 0, img1.Data, 1, img1.Cols * img1.Rows - 1);
                Array.Copy(img1.Data, img1.Cols * img1.Rows - 1, img1.Data, 0, 1);

                bitsXored = new BitArray(img1.Bytes);
                bitsXored.Xor(bitsTemplated);
                sum = countOfBitsSet(bitsXored);

                if (sum < maxSum)
                    maxSum = sum;
            }
            return maxSum;
        }
        
    }

    

       
}
