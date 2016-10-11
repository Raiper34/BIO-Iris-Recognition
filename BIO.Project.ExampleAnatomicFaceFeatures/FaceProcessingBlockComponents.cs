using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Extensions.Emgu.FeatureVector;
using BIO.Framework.Extensions.Standard.Template;
using BIO.Framework.Extensions.Standard.Block;
using BIO.Framework.Extensions.Standard.Comparator;
using BIO.Framework.Core.Comparator;

namespace BIO.Project.Example3DFaceRecognition {
    class FaceProcessingBlockComponents : InputDataProcessingBlockSettings<
        EmguGrayImageInputData,
        EmguMatrixFeatureVector,
        Template<EmguMatrixFeatureVector>,
        EmguMatrixFeatureVector
        > {

        public FaceProcessingBlockComponents() : base("3dface") { 
        
        }

        protected override Framework.Core.FeatureVector.IFeatureVectorExtractor<EmguGrayImageInputData, EmguMatrixFeatureVector> createTemplatedFeatureVectorExtractor() {
            return new FaceFeatureVectorExtractor();
        }

        protected override Framework.Core.FeatureVector.IFeatureVectorExtractor<EmguGrayImageInputData, EmguMatrixFeatureVector> createEvaluationFeatureVectorExtractor() {
            return new FaceFeatureVectorExtractor();
        }

        protected override Framework.Core.Comparator.IComparator<EmguMatrixFeatureVector, Template<EmguMatrixFeatureVector>, EmguMatrixFeatureVector> createComparator() {
            return
               new Comparator<EmguMatrixFeatureVector, Template<EmguMatrixFeatureVector>, EmguMatrixFeatureVector>(
                   CreateFeatureVectorComparator(), CreateScoreSelector());
        }

        private static IFeatureVectorComparator<EmguMatrixFeatureVector, EmguMatrixFeatureVector> CreateFeatureVectorComparator() {
            return new FaceComparator();
        }

        private static IScoreSelector CreateScoreSelector() {
            return new MinScoreSelector();
        }

    }
}
