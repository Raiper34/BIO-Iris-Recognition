using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputDataData;
using BIO.Framework.Extensions.Emgu.FeatureVector;
using BIO.Framework.Extensions.Standard.Template;
using BIO.Framework.Extensions.Standard.Template.Persistence;

namespace BIO.Project.Example1.FaceBiometricSystem {
    class FaceBiometricSystemFactory : BIO.Framework.Core.BiometricSystemFactory <
        StandardRecord<StandardRecordData>, //standard database record
        EmguGrayImageInputData             //input data
    > {

        protected override BIO.Framework.Core.Evaluation.IEvaluatorSettings createEvaluationSettings() {
            return new BIO.Framework.Extensions.Standard.Evaluation.EvaluationSettings();
        }

        
        protected override Framework.Core.Database.IDatabaseCreator<StandardRecord<StandardRecordData>> createInputDatabaseCreator() {
            return new FaceDatabaseCreator(@"d:\db\face\2D\JAFFE");
        }

        protected override Framework.Core.IBiometricSystemSettings<StandardRecord<StandardRecordData>, EmguGrayImageInputData> createBiometricSettings() {
            return new BiometricAlgorithmSettings();
        }
    }
}
