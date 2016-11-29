using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Extensions.Emgu.FeatureVector;
using BIO.Framework.Extensions.Standard.Template;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Core.FeatureVector;

namespace BIO.Project.IrisRecognition {
    abstract class IrisProcessingBlockComponents : BIO.Framework.Extensions.Standard.Block.InputDataProcessingBlockSettings<
          EmguGrayImageInputData,
          EmguGrayImageFeatureVector,
          Template<EmguGrayImageFeatureVector>,
          EmguGrayImageFeatureVector
    > {

        public IrisProcessingBlockComponents(string name) : base(name) { 
        }

        protected abstract IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> createFeatureVectorExtractor();

        //Extractor
        protected override IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> createTemplatedFeatureVectorExtractor() {
            return this.createFeatureVectorExtractor();
        }

        //Extractor
        protected override IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> createEvaluationFeatureVectorExtractor() {
            return this.createFeatureVectorExtractor();
        }
        
        //Comparator
        protected override Framework.Core.Comparator.IComparator<EmguGrayImageFeatureVector, Template<EmguGrayImageFeatureVector>, EmguGrayImageFeatureVector> createComparator() {
            return new BIO.Framework.Extensions.Standard.Comparator.Comparator<EmguGrayImageFeatureVector, Template<EmguGrayImageFeatureVector>, EmguGrayImageFeatureVector>(
                this.createFeatureVectorComparator(),
                this.createScoreSelector()
            );
        }

        //Comparator
        private IFeatureVectorComparator<EmguGrayImageFeatureVector, EmguGrayImageFeatureVector> createFeatureVectorComparator() {
            return new IrisFeatureVectorComparator();
        }

        //Selector
        private Framework.Extensions.Standard.Comparator.IScoreSelector createScoreSelector() {
            return new BIO.Framework.Extensions.Standard.Comparator.MinScoreSelector();
        }
    }

    class IrisProcessingBlockComponents1 : IrisProcessingBlockComponents {

        public IrisProcessingBlockComponents1() 
            : base("Iris Recognition 1") { 
        }

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, EmguGrayImageFeatureVector> createFeatureVectorExtractor() {
            return new IrisFeatureVectorExtractor();
        }
    }
}
