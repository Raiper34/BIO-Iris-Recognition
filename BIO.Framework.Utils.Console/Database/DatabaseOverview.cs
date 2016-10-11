using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Utils.Console.Database {
    public class DatabaseOverview  {
        //BIO.Framework.Core.Database.IRecordEnumerable db = null;
        /*public DatabaseOverview(BIO.Framework.Core.Database.IRecordEnumerable db) {
            this.db = db;
        }*/

        public static void showGlobalOverview(BIO.Framework.Core.Database.IRecordEnumerable dbIterator) {
            System.Console.WriteLine("Database size: " + dbIterator.getIRecords().Count().ToString());
            System.Console.WriteLine("Unique biometrics count: " + dbIterator.getBiometricIDs().Count().ToString());
        }

    }
}
