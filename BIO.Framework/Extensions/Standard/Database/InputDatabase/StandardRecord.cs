using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.Database.InputDatabase {
    public class StandardRecord<TStandardRecordData> : Core.Database.Record, Core.Database.IRecord where TStandardRecordData : IStandardRecordData {
       
        /// <summary>
        /// data stored in biometric record
        /// </summary>
        public TStandardRecordData BiometricData { get; private set; }
       
        /// <summary>
        /// construct with bio ID
        /// </summary>
        /// <param name="bioID"></param>
        private StandardRecord(string uid, Core.Database.BiometricID bioID) {
            BiometricID = bioID;
            SampleID = uid;
            //BiometricData = default(TRecord);
        }
        /// <summary>
        /// construct with bioID and data
        /// </summary>
        /// <param name="bioID"></param>
        /// <param name="data"></param>
        public StandardRecord(string uid, Core.Database.BiometricID bioID, TStandardRecordData data)
            : this(uid, bioID){
                BiometricData = data;
        }
    }

}
