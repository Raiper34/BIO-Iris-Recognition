using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.Database.Subsets {
    public abstract class DatabaseSubsetCreator<TRecord> : BIO.Framework.Core.Database.Subsets.IDatabaseSubsetCreator<TRecord> where TRecord : BIO.Framework.Core.Database.IRecord {

        Dictionary<string, BIO.Framework.Core.Database.Database<TRecord>> subsets = null;

        public Dictionary<string, BIO.Framework.Core.Database.Database<TRecord>> Subsets {
            get {
                if (subsets == null) {
                    subsets = this.createSubsets();
                }
                return subsets; 
            }
            
        }

        protected abstract Dictionary<string, Core.Database.Database<TRecord>> createSubsets();


        BIO.Framework.Core.Database.Database<TRecord> fullDatabase = null;

        protected BIO.Framework.Core.Database.Database<TRecord> FullDatabase {
            get { return fullDatabase; }
        }

        public DatabaseSubsetCreator(BIO.Framework.Core.Database.Database<TRecord> fullDatabase) { 
            this.fullDatabase = fullDatabase;
        }

        #region IDatabaseSubsetCreator<TRecord> Members

        public Core.Database.Database<TRecord> getDatabaseSubset(string subsetName) {
            try {
                return this.Subsets[subsetName];
            } catch (Exception e) {
                throw new ArgumentException("Database subset " + subsetName + " is not available", e);
            }
        }

        #endregion
    }
}
