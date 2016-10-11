using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.FeatureVector;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Extensions.Standard.Template;
using BIO.Framework.Core;
using BIO.Project.Example2.Simple;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Core.FeatureVector;

namespace BIO.Project.Example2.Simple {
    class FaceProcessingBlockComponents : BIO.Framework.Extensions.Standard.Block.InputDataProcessingBlockSettings<
          EmguGrayImageInputData,
          DoubleArrayFeatureVector,
          Template<DoubleArrayFeatureVector>,
          DoubleArrayFeatureVector
    > {


        public FaceProcessingBlockComponents(string name) : base(name) { 
        
        }



        private IFeatureVectorComparator<DoubleArrayFeatureVector, DoubleArrayFeatureVector> createFeatureVectorComparator() {
            return new FaceFeatureVectorComparator();
        }

        private Framework.Extensions.Standard.Comparator.IScoreSelector createScoreSelector() {
            return new BIO.Framework.Extensions.Standard.Comparator.MinScoreSelector();
        }

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, DoubleArrayFeatureVector> createTemplatedFeatureVectorExtractor() {
            return new FaceFeatureVectorExtractor();
        }

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, DoubleArrayFeatureVector> createEvaluationFeatureVectorExtractor() {
            return new FaceFeatureVectorExtractor();
        }

        protected override IComparator<DoubleArrayFeatureVector, Template<DoubleArrayFeatureVector>, DoubleArrayFeatureVector> createComparator() {
            return new BIO.Framework.Extensions.Standard.Comparator.Comparator<DoubleArrayFeatureVector, Template<DoubleArrayFeatureVector>, DoubleArrayFeatureVector>(
                this.createFeatureVectorComparator(),
                this.createScoreSelector()
            );
        }
    }
}
