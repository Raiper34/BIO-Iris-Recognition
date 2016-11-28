using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;

namespace BIO.Project.IrisRecognition
{
    class ProjectSettings :
        ProjectSettings<StandardRecord<StandardRecordData>, EmguGrayImageInputData>,
        IStandardProjectSettings<StandardRecord<StandardRecordData>> {

        public int TemplateSamples {
            get {
                return 1;
            }
        }

        public override Framework.Core.Database.IDatabaseCreator<StandardRecord<StandardRecordData>> getDatabaseCreator() {
            return new IrisDatabaseCreator(@"C:\Users\archie\Desktop\CASIA-IrisV1"); // !!!!!!!!!!!!! PATH TO PICTURES FOLDER !!!!!!!!!!!!!!!!!!!!!
        }

        protected override Framework.Core.Evaluation.Block.IBlockEvaluatorSettings<StandardRecord<StandardRecordData>, EmguGrayImageInputData> getEvaluatorSettings() {
            return new IrisEvaluationSettings();
        }
    }
}
