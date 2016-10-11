using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using BIO.Framework.Core.Database;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;


namespace BIO.Project.Example2 {
    class FaceDatabaseCreator : Framework.Core.Database.IDatabaseCreator<StandardRecord<StandardRecordData>> {

        string databasePath;

        public FaceDatabaseCreator(string databasePath) {
            this.databasePath = databasePath;
        }
        
        #region IDatabaseCreator<StandardRecord<StandardRecordData>> Members

        public Framework.Core.Database.Database<StandardRecord<StandardRecordData>> createDatabase() {
            Framework.Core.Database.Database<StandardRecord<StandardRecordData>> database = new Framework.Core.Database.Database<StandardRecord<StandardRecordData>>();

            DirectoryInfo di = new DirectoryInfo(this.databasePath);
            FileInfo[] files = di.GetFiles("*.tiff");
            foreach (FileInfo f in files) {

                string [] parts = f.Name.Split(new char [] {'.'},  StringSplitOptions.RemoveEmptyEntries);

                BiometricID bioID = new BiometricID(parts[0], "face");
                StandardRecordData data = new StandardRecordData(f.FullName);
                StandardRecord<StandardRecordData> record = new StandardRecord<StandardRecordData>(f.Name, bioID, data);

                database.addRecord(record);
            }
            return database;

        }

        #endregion
    }
}
