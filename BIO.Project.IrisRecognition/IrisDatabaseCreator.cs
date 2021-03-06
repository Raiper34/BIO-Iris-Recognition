﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using BIO.Framework.Core.Database;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;


namespace BIO.Project.IrisRecognition
{
    class IrisDatabaseCreator : Framework.Core.Database.IDatabaseCreator<StandardRecord<StandardRecordData>> {

        string databasePath;

        public IrisDatabaseCreator(string databasePath) {
            this.databasePath = databasePath;
        }
        
        public Framework.Core.Database.Database<StandardRecord<StandardRecordData>> createDatabase() {
            Framework.Core.Database.Database<StandardRecord<StandardRecordData>> database = new Framework.Core.Database.Database<StandardRecord<StandardRecordData>>();

            DirectoryInfo di = new DirectoryInfo(this.databasePath);
            FileInfo[] files = di.GetFiles("*.bmp", SearchOption.AllDirectories);
            foreach (FileInfo f in files) {

                string [] parts = f.Name.Split(new char [] {'_'},  StringSplitOptions.RemoveEmptyEntries);

                BiometricID bioID = new BiometricID(parts[0], "iris");
                StandardRecordData data = new StandardRecordData(f.FullName); // !!!!!!!!!!!!! OWN RECORD MAYBE !!!!!!!!!!!!!!!!!!!!!
                StandardRecord<StandardRecordData> record = new StandardRecord<StandardRecordData>(f.Name, bioID, data);

                database.addRecord(record);
            }
            return database;

        }
    }
}
