using BIO.Framework.Core.Evaluation;
using BIO.Framework.Core.Template.Persistence;
using BIO.Framework.Extensions.Standard.Template.Persistence;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;

namespace BIO.Project.Example3DFaceRecognition
{
    class FaceEvaluationSettings : BIO.Framework.Extensions.Standard.Evaluation.Block.BlockEvaluationSettings<
        StandardRecord<StandardRecordData>, //standard database record
        EmguGrayImageInputData 
    >
    {
        public FaceEvaluationSettings() {
            
            {
                var value = new FaceProcessingBlockComponents();
                this.addBlockToEvaluation(value.createBlock());
            }
           
            
        }

        protected override Framework.Core.InputData.IInputDataCreator<StandardRecord<StandardRecordData>, EmguGrayImageInputData> createInputDataCreator() {
            return new FaceInputDataCreator();
        }
    }
}