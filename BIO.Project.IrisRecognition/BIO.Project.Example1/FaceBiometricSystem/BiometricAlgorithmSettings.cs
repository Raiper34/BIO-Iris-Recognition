using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIO.Framework.Core;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;

using BIO.Framework.Extensions.Emgu.InputDataData;
using BIO.Framework.Extensions.Emgu.FeatureVector;

using BIO.Framework.Extensions.Standard.Template;
using BIO.Framework.Extensions.Standard.Template.Persistence;

namespace BIO.Project.Example1.FaceBiometricSystem {
    public class BiometricAlgorithmSettings : BIO.Framework.Extensions.Standard.StandardBlockSettings <
        StandardRecord<StandardRecordData>, //standard database record
        EmguGrayImageInputData              //input data
    >
    {
        public BiometricAlgorithmSettings()
            : base("example1") {
            {
                FaceProcessingBlockComponents fbc = new FaceProcessingBlockComponents1();
                this.addBlock(fbc.createBlock());
            }
            {
                FaceProcessingBlockComponents fbc = new FaceProcessingBlockComponents2();
                this.addBlock(fbc.createBlock());
            }
            {
                FaceProcessingBlockComponents fbc = new FaceProcessingBlockComponents3();
                this.addBlock(fbc.createBlock());
            }
            {
                this.addBlock(new FaceProcessingBlockCombined());
            }

        }

        protected override IInputDataCreator<StandardRecord<StandardRecordData>, EmguGrayImageInputData> createInputDataCreator() {
            return new FaceInputDataCreator();
        }
    }

}
