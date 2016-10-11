using System;
using System.Collections;
using System.Collections.Generic;
using BIO.Framework.Core.Template;
using BIO.Framework.Extensions.Emgu.FeatureVector;

namespace BIO.Project.Example3DFaceRecognition
{
    class FaceTemplate : ITemplate<EmguMatrixFeatureVector>
    {
        public EmguMatrixFeatureVector FeatureVector { private set; get; }

        public void addFeatureVector(EmguMatrixFeatureVector featureVector)
        {
            FeatureVector = featureVector;
        }

        public IEnumerator<EmguMatrixFeatureVector> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}
