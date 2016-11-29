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
            double maxSum = this.hammingDistance(m1, m2);
            return new MatchingScore(maxSum);
        }


        //Source: http://stackoverflow.com/questions/5063178/counting-bits-set-in-a-net-bitarray-class
        public static Int32 countOfBitsSet(BitArray bitArray)
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

        public double hammingDistance(Image<Gray, byte> m1, Image<Gray, byte> m2)
        {
            double sum = 0;
            byte[,,] data = m1.Rotate(90, new Gray(255), false).Data;

            //Matrix<byte> transaltionMatrix = new Matrix<byte>(1,1);
            //transaltionMatrix.SetZero();


            BitArray bitsExtracted = new BitArray(m1.Bytes);
            BitArray bitsXored = new BitArray(m1.Bytes);
            BitArray bitsTemplated = new BitArray(m2.Bytes);

            bitsXored.Xor(bitsTemplated);
            double maxSum = countOfBitsSet(bitsXored);
            sum = maxSum;
            for (int i = 1; i < m1.Cols; i++)
            {
                Array.Copy(m1.Data, 0, m1.Data, 1, m1.Cols * m1.Rows - 1);
                Array.Copy(m1.Data, m1.Cols * m1.Rows - 1, m1.Data, 0, 1);

                bitsXored = new BitArray(m1.Bytes);
                bitsXored.Xor(bitsTemplated);
                sum = countOfBitsSet(bitsXored);

                if (sum < maxSum)
                    maxSum = sum;
            }
            return maxSum;
        }
        
    }

    

       
}
