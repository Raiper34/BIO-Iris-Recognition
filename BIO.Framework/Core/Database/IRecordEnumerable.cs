using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Database {
    /// <summary>
    /// general interface
    /// </summary>
    public interface IRecordEnumerable {
        /// <summary>
        /// Iterate throught records of same biometric (all left irises of John Doe)
        /// </summary>
        /// <param name="biometricID"></param>
        /// <returns></returns>
        IEnumerable<IRecord> getIRecordsByBiometricID(BiometricID biometricID);

        /// <summary>
        /// Iterate throught all records
        /// </summary>
        /// <returns></returns>
        IEnumerable<IRecord> getIRecords();
        /// <summary>
        /// Iterate throught all personIDs
        /// </summary>
        /// <returns></returns>
        IEnumerable<BiometricID> getBiometricIDs();
    }
    /// <summary>
    /// type safe interace
    /// </summary>
    /// <typeparam name="TRecord"></typeparam>
    public interface IRecordEnumerable<TRecord> : IRecordEnumerable where TRecord : IRecord {
        /// <summary>
        /// Iterate throught records of same biometric (all left irises of John Doe)
        /// </summary>
        /// <param name="biometricID"></param>
        /// <returns></returns>
        IEnumerable<TRecord> getRecordsByBiometricID(BiometricID biometricID);

        /// <summary>
        /// Iterate throught all records
        /// </summary>
        /// <returns></returns>
        IEnumerable<TRecord> getRecords();
        
    }

    
}
