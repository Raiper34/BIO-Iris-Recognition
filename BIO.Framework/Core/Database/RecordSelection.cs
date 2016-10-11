using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Database {
    class RecordSelection<TRecord> : IRecordEnumerable<TRecord>, IRecordEnumerable where TRecord : IRecord {
       
        /// <summary>
        /// all records associated by biometric ID (same person and same biometric)
        /// </summary>
        private Dictionary<BiometricID, List<TRecord>> dataByBiometricID = new Dictionary<BiometricID, List<TRecord>>(new BiometricIDEqualityComparer());
        /// <summary>
        /// all records collection
        /// </summary>
        private Dictionary<string, TRecord> data = new Dictionary<string, TRecord>();

        /// <summary>
        /// Iterate throught records of same biometric (all left irises of John Doe)
        /// </summary>
        /// <param name="biometricID"></param>
        /// <returns></returns>
        public IEnumerable<TRecord> getRecordsByBiometricID(BiometricID biometricID) {
            foreach (TRecord r in dataByBiometricID[biometricID]) {
                yield return r;
            }
        }
        /// <summary>
        /// Iterate throught all records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TRecord> getRecords() {
            foreach (KeyValuePair<string, TRecord> r in this.data) {
                yield return r.Value;
            }
        }
        
        #region IRecordEnumerable Members

        public IEnumerable<IRecord> getIRecordsByBiometricID(BiometricID biometricID) {
            foreach (TRecord r in dataByBiometricID[biometricID]) {
                yield return r;
            }
        }

        public IEnumerable<IRecord> getIRecords() {
            foreach (KeyValuePair<string, TRecord> r in this.data) {
                yield return r.Value;
            }
        }
        /// <summary>
        /// Iterate throught all personIDs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BiometricID> getBiometricIDs() {
            foreach (BiometricID p in dataByBiometricID.Keys) {
                yield return p;
            }
        }


        /// <summary>
        /// Add item to database
        /// </summary>
        /// <param name="r">record</param>
        public virtual void addRecord(TRecord r) {
            //add to database
            this.data.Add(r.SampleID, r);
             
            bool cv = this.dataByBiometricID.ContainsKey(r.BiometricID);

            //add to assoc by biometric id
            if (!this.dataByBiometricID.ContainsKey(r.BiometricID)) {
                this.dataByBiometricID.Add(r.BiometricID, new List<TRecord>());
            }
            this.dataByBiometricID[r.BiometricID].Add(r);
            
        }

        #endregion
    }
}
