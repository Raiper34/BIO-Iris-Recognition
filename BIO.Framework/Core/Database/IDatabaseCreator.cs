using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Database {
    public interface IDatabaseCreator<TRecord>
    where TRecord : IRecord {
        Database<TRecord> createDatabase();
    }
}
