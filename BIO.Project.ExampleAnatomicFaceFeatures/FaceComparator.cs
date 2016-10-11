using System;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Extensions.Emgu.FeatureVector;

namespace BIO.Project.Example3DFaceRecognition
{
    class FaceComparator : IFeatureVectorComparator<EmguMatrixFeatureVector, EmguMatrixFeatureVector>
    {
        public MatchingScore computeMatchingScore(EmguMatrixFeatureVector extracted, EmguMatrixFeatureVector templated)
        {
            double sum = 0;

            if (extracted.FeatureVector.Size != templated.FeatureVector.Size ||
                extracted.FeatureVector.Cols != 1 || templated.FeatureVector.Cols != 1)
                throw new ArgumentException("Feature vector and template mismatch.");

            var n = extracted.FeatureVector.Rows;
            for (var i = 0; i < n; i++)
            {
                sum += Math.Abs(extracted.FeatureVector[i, 0] - templated.FeatureVector[i, 0]);
            }

            return new MatchingScore(sum);
        }
    }
}
