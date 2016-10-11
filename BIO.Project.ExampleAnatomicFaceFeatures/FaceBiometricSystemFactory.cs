using BIO.Framework.Core;
using BIO.Framework.Core.BiometricSystem;
using BIO.Framework.Core.Database;
using BIO.Framework.Core.Evaluation;
using BIO.Framework.Extensions.Emgu.FeatureVector;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Standard.Template;
using BIO.Framework.Extensions.Standard.Template.Persistence;

namespace BIO.Project.Example3DFaceRecognition
{
    class FaceBiometricSystemFactory :
        BiometricSystemFactory<
            StandardRecord<StandardRecordData>,
            EmguGrayImageInputData,
            EmguMatrixFeatureVector,
            Template<EmguMatrixFeatureVector>,
            EmguMatrixFeatureVector,
            MemoryPersistentTemplate>
    {
        protected override IEvaluatorSettings<MemoryPersistentTemplate> createEvaluationSettings()
        {
            return new FaceEvaluationSettings();
        }

        protected override IBiometricAlgorithmSettings<StandardRecord<StandardRecordData>, EmguGrayImageInputData, EmguMatrixFeatureVector, Template<EmguMatrixFeatureVector>, EmguMatrixFeatureVector> createBiometricSettings()
        {
            return new FaceRecognitionAlgorithmSetings();
        }

        protected override IDatabaseCreator<StandardRecord<StandardRecordData>> createInputDatabaseCreator()
        {
            return new FaceDatabaseCreator(@"D:\db\face\2D\frgc\");
        }
    }
}
