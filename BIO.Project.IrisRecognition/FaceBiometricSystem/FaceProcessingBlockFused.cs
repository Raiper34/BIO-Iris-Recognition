using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Core;
using BIO.Framework.Extensions.Standard.Block;
using BIO.Framework.Core.Block;

namespace BIO.Project.IrisRecognition.FaceBiometricSystem {
    class FaceProcessingBlockFused : MultipleInputDataProcessingBlock<EmguGrayImageInputData> {
        

        public FaceProcessingBlockFused() : base("fusion") {
            {
                FaceProcessingBlockComponents fbc = new FaceProcessingBlockComponents1();
                this.addInternalBlock(fbc.createBlock());
            }
            {
                FaceProcessingBlockComponents fbc = new FaceProcessingBlockComponents2();
                this.addInternalBlock(fbc.createBlock());
            }
            {
                FaceProcessingBlockComponents fbc = new FaceProcessingBlockComponents3();
                this.addInternalBlock(fbc.createBlock());
            }
        }

        class ScoreResolver : IScoreFusionBlock {

            public Framework.Core.Comparator.MatchingScore resolve(Framework.Core.Comparator.MatchingScore matchingSubscores) {
                double val = 0.0;
                foreach (string subscoreName in matchingSubscores.getSubscoreNames()) { 
                    val += matchingSubscores.getSubscore(subscoreName).Score;
                }
                return matchingSubscores.cloneWithDifferentScore(val);
            }

        }

        protected override IScoreFusionBlock createMatchingScoreFusionBlock() {
            return new ScoreResolver();
        }
    }
}
