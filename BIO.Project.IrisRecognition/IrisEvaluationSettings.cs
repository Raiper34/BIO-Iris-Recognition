using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Extensions.Standard.Evaluation.Block;

namespace BIO.Project.IrisRecognition
{
    class IrisEvaluationSettings : 
        BlockEvaluationSettings<
        StandardRecord<StandardRecordData>, //standard database record
        EmguGrayImageInputData
    > {

        public IrisEvaluationSettings() {
            
            {
                var value = new IrisProcessingBlockComponents1();
                this.addBlockToEvaluation(value.createBlock());
            }
            
        }

        protected override Framework.Core.InputData.IInputDataCreator<StandardRecord<StandardRecordData>, EmguGrayImageInputData> createInputDataCreator() {
            return new IrisInputDataCreator();
        }
    }
}
