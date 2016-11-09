using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Extensions.Emgu.FeatureVector;
using BIO.Framework.Extensions.Standard.Template;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Core.FeatureVector;

namespace BIO.Project.Example1.FaceBiometricSystem {
    abstract class FaceProcessingBlockComponents : BIO.Framework.Extensions.Standard.Block.InputDataProcessingBlockSettings<
          EmguGrayImageInputData,
          EmguGrayImageFeatureVector,
          Template<EmguGrayImageFeatureVector>,
          EmguGrayImageFeatureVector
    > {

        public FaceProcessingBlockComponents(string name) : base(name) { 
        }

        protected abstract IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> createFeatureVectorExtractor();

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> createTemplatedFeatureVectorExtractor() {
            return this.createFeatureVectorExtractor();
        }

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> createEvaluationFeatureVectorExtractor() {
            return this.createFeatureVectorExtractor();
        }
        
        protected override Framework.Core.Comparator.IComparator<EmguGrayImageFeatureVector, Template<EmguGrayImageFeatureVector>, EmguGrayImageFeatureVector> createComparator() {
            return new BIO.Framework.Extensions.Standard.Comparator.Comparator<EmguGrayImageFeatureVector, Template<EmguGrayImageFeatureVector>, EmguGrayImageFeatureVector>(
                this.createFeatureVectorComparator(),
                this.createScoreSelector()
            );
        }

        private IFeatureVectorComparator<EmguGrayImageFeatureVector, EmguGrayImageFeatureVector> createFeatureVectorComparator() {
            return new FaceFeatureVectorComparator();
        }

        private Framework.Extensions.Standard.Comparator.IScoreSelector createScoreSelector() {
            return new BIO.Framework.Extensions.Standard.Comparator.MinScoreSelector();
        }
    }

    class FaceProcessingBlockComponents1 : FaceProcessingBlockComponents {

        public FaceProcessingBlockComponents1() 
            : base("alg_1") { 
        }

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> createFeatureVectorExtractor() {
            return new FaceFeatureVectorExtractor1();
        }
    }

    class FaceProcessingBlockComponents2 : FaceProcessingBlockComponents {

        public FaceProcessingBlockComponents2()
            : base("alg_2") {
        }

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> createFeatureVectorExtractor() {
            return new FaceFeatureVectorExtractor2();
        }
    }

    class FaceProcessingBlockComponents3 : FaceProcessingBlockComponents {

        public FaceProcessingBlockComponents3()
            : base("alg_3") {
        }

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> createFeatureVectorExtractor() {
            return new FaceFeatureVectorExtractor3();
        }
    }
}
