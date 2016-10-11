using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;

namespace BIO.Project.Example2 {
    class FaceEvaluationSettings : 
        BIO.Framework.Extensions.Standard.Evaluation.Block.BlockEvaluationSettings<
        StandardRecord<StandardRecordData>, //standard database record
        EmguGrayImageInputData
    > {

        public FaceEvaluationSettings() {
            {
                var value = new Simple.FaceProcessingBlockComponents("Simple");
                this.addBlockToEvaluation(value.createBlock());
            }
            {
                var value = new PCA.FaceProcessingBlockComponents("PCA", this.PcaExtractor);
                this.addBlockToEvaluation(value.createBlock());
            }
            
        }

        protected override Framework.Core.InputData.IInputDataCreator<StandardRecord<StandardRecordData>, EmguGrayImageInputData> createInputDataCreator() {
            return new FaceInputDataCreator();
        }

        Statistical.DoubleArrayExtractorStatisticalWrapper<EmguGrayImageInputData> pcaExtractor = null;

        internal Statistical.DoubleArrayExtractorStatisticalWrapper<EmguGrayImageInputData> PcaExtractor {
            get {
                if (pcaExtractor == null) {
                    pcaExtractor = new Statistical.DoubleArrayExtractorStatisticalWrapper<EmguGrayImageInputData>(new Simple.FaceFeatureVectorExtractor(), new Statistical.PCA());
                }
                return pcaExtractor;
            }

        }
    }
}
