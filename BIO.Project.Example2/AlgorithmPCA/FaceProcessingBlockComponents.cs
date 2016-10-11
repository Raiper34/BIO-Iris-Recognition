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

namespace BIO.Project.Example2.PCA  {
    class FaceProcessingBlockComponents : Simple.FaceProcessingBlockComponents {

        IFeatureVectorExtractor<EmguGrayImageInputData, DoubleArrayFeatureVector> extractor;

        public FaceProcessingBlockComponents(string name, IFeatureVectorExtractor<EmguGrayImageInputData, DoubleArrayFeatureVector> extractor) : base(name) {
            this.extractor = extractor;
        }

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, DoubleArrayFeatureVector> createTemplatedFeatureVectorExtractor() {
            return extractor;
        }

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, DoubleArrayFeatureVector> createEvaluationFeatureVectorExtractor() {
            return extractor;
        }

        
    }
}
