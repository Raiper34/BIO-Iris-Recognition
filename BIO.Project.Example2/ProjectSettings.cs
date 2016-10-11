using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;

namespace BIO.Project.Example2 {
    class ProjectSettings :
        BIO.Project.ProjectSettings<StandardRecord<StandardRecordData>, EmguGrayImageInputData>,
        ITrainableProjectSettings<StandardRecord<StandardRecordData>> {

        #region IStandardProjectSettings<StandardRecord<StandardRecordData>> Members

        public int TemplateSamples {
            get {
                return 2;
            }
        }

        #endregion

        public override Framework.Core.Database.IDatabaseCreator<StandardRecord<StandardRecordData>> getDatabaseCreator() {
            return new FaceDatabaseCreator(@"d:\db\face\2D\JAFFE");
        }

        FaceEvaluationSettings settings = new FaceEvaluationSettings();

        internal FaceEvaluationSettings BlockEvaluationSettings {
            get { return settings; }
           
        }

        protected override Framework.Core.Evaluation.Block.IBlockEvaluatorSettings<StandardRecord<StandardRecordData>, EmguGrayImageInputData> getEvaluatorSettings() {
            return BlockEvaluationSettings;
        }

        #region ITrainableProjectSettings<StandardRecord<StandardRecordData>> Members

        public double ValidatorSamplesRatio {
            get {
                return 0.3;
            }
        }

        public double TrainTestSamplesRatio {
            get {
                return 0.9; 
            }
        }

        #endregion
    }
}
