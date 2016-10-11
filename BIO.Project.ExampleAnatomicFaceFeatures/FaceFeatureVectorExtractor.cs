using System;
using System.Drawing;
using BIO.Framework.Core;
using BIO.Framework.Extensions.Emgu.FeatureVector;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Core.FeatureVector;

namespace BIO.Project.Example3DFaceRecognition
{
    class FaceFeatureVectorExtractor : IFeatureVectorExtractor<EmguGrayImageInputData, EmguMatrixFeatureVector>
    {
        public EmguMatrixFeatureVector extractFeatureVector(EmguGrayImageInputData input)
        {
            if (input.Image.Width != 100 ||
                input.Image.Height != 100)
                throw new InvalidOperationException("Image size has to be 100x100 pixels");

            var processedImage = input.Image.SmoothGaussian(3);

            var featureVector = new EmguMatrixFeatureVector(new Size(1, 100));
            featureVector.FeatureVector.SetZero();

            var minInStripe = new double[10];
            var maxInStripe = new double[10];
            for (var i = 0; i < 10; i++)
            {
                minInStripe[i] = double.MaxValue;
                maxInStripe[i] = -double.MaxValue;
            }

            for (var y = 0; y < 100; y++)
            {
                for (var x = 0; x < 100; x++)
                {
                    var stripe = y/10;
                    var value = processedImage[y, x].Intensity;

                    if (value < minInStripe[stripe])
                        minInStripe[stripe] = value;
                    if (value > maxInStripe[stripe])
                        maxInStripe[stripe] = value;
                }
            }

            for (var y = 0; y < 100; y++)
            {
                for (var x = 0; x < 100; x++)
                {
                    var stripe = y / 10;
                    var value = processedImage[y, x].Intensity;

                    var normalizedValue = ((double) (value - minInStripe[stripe]))/
                                          (maxInStripe[stripe] - minInStripe[stripe]);
                    var bin = (int) (normalizedValue*10);
                    if (bin >= 10) bin = 9;

                    var row = 10*stripe + bin;
                    featureVector.FeatureVector[row, 0] += 1;
                }
            }

            return featureVector;
        }
    }
}
