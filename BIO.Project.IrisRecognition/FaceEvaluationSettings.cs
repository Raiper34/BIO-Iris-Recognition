using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Extensions.Standard.Evaluation.Block;

namespace BIO.Project.IrisRecognition
{
    class FaceEvaluationSettings : 
        BlockEvaluationSettings<
        StandardRecord<StandardRecordData>, //standard database record
        EmguGrayImageInputData
    > {

        public FaceEvaluationSettings() {
            
            {
                var value = new FaceBiometricSystem.FaceProcessingBlockComponents1();
                this.addBlockToEvaluation(value.createBlock());
            }
            {
                var value = new FaceBiometricSystem.FaceProcessingBlockComponents2();
                this.addBlockToEvaluation(value.createBlock());
            }
            {
                var value = new FaceBiometricSystem.FaceProcessingBlockComponents3();
                this.addBlockToEvaluation(value.createBlock());
            }
            {
                this.addBlockToEvaluation(new FaceBiometricSystem.FaceProcessingBlockFused());
            }
            
        }

        protected override Framework.Core.InputData.IInputDataCreator<StandardRecord<StandardRecordData>, EmguGrayImageInputData> createInputDataCreator() {
            return new FaceInputDataCreator();
        }
    }
}
