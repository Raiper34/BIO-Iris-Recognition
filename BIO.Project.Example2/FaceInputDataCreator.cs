using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIO.Framework.Core;
using BIO.Framework.Core.Database;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Core.InputData;

namespace BIO.Project.Example2 {
    public class FaceInputDataCreator :  IInputDataCreator<StandardRecord<StandardRecordData>, EmguGrayImageInputData> {
        #region IInputDataCreator<StandardRecord<StandardRecordData>,EmguGrayImageInputData> Members

        public EmguGrayImageInputData createInputData(StandardRecord<StandardRecordData> record) {
            return new EmguGrayImageInputData(record.BiometricData.Data);
        }

        #endregion
    }
}
