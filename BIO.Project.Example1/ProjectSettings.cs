using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;

namespace BIO.Project.Example1 {
    class ProjectSettings :
        BIO.Project.ProjectSettings<StandardRecord<StandardRecordData>, EmguGrayImageInputData>,
        IStandardProjectSettings<StandardRecord<StandardRecordData>> {

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

        protected override Framework.Core.Evaluation.Block.IBlockEvaluatorSettings<StandardRecord<StandardRecordData>, EmguGrayImageInputData> getEvaluatorSettings() {
            return new FaceEvaluationSettings();
        }
    }
}
