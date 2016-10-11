using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Database.Subsets {
    public  interface IDatabaseSubsetCreator<TRecord> where TRecord : IRecord {
        /// <summary>
        /// get database subset (training, testing, ...)
        /// </summary>
        /// <param name="subsetName">name of subset</param>
        /// <returns>database subset</returns>
        Database<TRecord> getDatabaseSubset(string subsetName);
    }
}
