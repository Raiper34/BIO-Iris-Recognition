using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Project.Example1.FaceBiometricSystem;

namespace BIO.Project.Example1 {
    class FaceEvaluationSettings : 
        BIO.Framework.Extensions.Standard.Evaluation.Block.BlockEvaluationSettings<
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
