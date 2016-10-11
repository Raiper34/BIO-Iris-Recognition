using BIO.Framework.Core;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Extensions.Emgu.FeatureVector;
using BIO.Framework.Extensions.Emgu.Input;
using BIO.Framework.Extensions.Standard;
using BIO.Framework.Extensions.Standard.Comparator;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Standard.Processing;
using BIO.Framework.Extensions.Standard.Template;

namespace BIO.Project.Example3DFaceRecognition
{
    class FaceRecognitionAlgorithmSetings :
        StandardSettings<
            StandardRecord<StandardRecordData>,
            EmguGrayImageInputData,
            EmguMatrixFeatureVector,
            Template<EmguMatrixFeatureVector>,
            EmguMatrixFeatureVector>
    {
        public FaceRecognitionAlgorithmSetings() : base("FaceRecognitionExample"){}

        protected override IInputDataCreator<StandardRecord<StandardRecordData>, EmguGrayImageInputData> createInputDataCreator()
        {
            return new FaceInputDataCreator();
        }

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, EmguMatrixFeatureVector> createTemplateFeatureVectorExtractor()
        {
            return new FaceFeatureVectorExtractor();
        }

        protected override IFeatureVectorExtractor<EmguGrayImageInputData, EmguMatrixFeatureVector> createExtractedFeatureVectorExtractor()
        {
            return new FaceFeatureVectorExtractor();
        }

        protected override ITemplateCreator<EmguMatrixFeatureVector, Template<EmguMatrixFeatureVector>> createTemplateCreator()
        {
            return new TemplateCreator<EmguMatrixFeatureVector, Template<EmguMatrixFeatureVector>>();
        }

        protected override IComparator<EmguMatrixFeatureVector, EmguMatrixFeatureVector, Template<EmguMatrixFeatureVector>> createTemplateComparator()
        {
            return
                new Comparator<EmguMatrixFeatureVector, EmguMatrixFeatureVector, Template<EmguMatrixFeatureVector>>(
                    CreateFeatureVectorComparator(), CreateScoreSelector());
        }

        private static IFeatureVectorComparator<EmguMatrixFeatureVector, EmguMatrixFeatureVector> CreateFeatureVectorComparator()
        {
            return new FaceComparator();
        }

        private static IScoreSelector CreateScoreSelector()
        {
            return new MinScoreSelector();
        }
    }
}