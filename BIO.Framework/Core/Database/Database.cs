using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Database {
    public class Database<TRecord> where TRecord : IRecord {

        private RecordSelection<TRecord> storage = new RecordSelection<TRecord>();

        public virtual IRecordEnumerable<TRecord> getCollections() {
            return this.storage;
        }
        

        /// <summary>
        /// Generate unique record id and add item to database
        /// </summary>
        /// <param name="r">record</param>
        public virtual void addRecord(TRecord r) {
            this.storage.addRecord(r);
        }
    }
}
