using System;
using System.IO;
using BIO.Framework.Core.Database;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;

namespace BIO.Project.Example3DFaceRecognition
{
    class FaceDatabaseCreator : IDatabaseCreator<StandardRecord<StandardRecordData>>
    {
        readonly string _databasePath;

        public FaceDatabaseCreator(string databasePath) {
            _databasePath = databasePath;
        }

        public Database<StandardRecord<StandardRecordData>> createDatabase()
        {
            var database = new Database<StandardRecord<StandardRecordData>>();

            var di = new DirectoryInfo(_databasePath);
            var files = di.GetFiles("*-small-range.png");
            foreach (var f in files)
            {
                var parts = f.Name.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                var bioID = new BiometricID(parts[0], "3d_face_range_image");
                var data = new StandardRecordData(f.FullName);
                var record = new StandardRecord<StandardRecordData>(f.Name, bioID, data);

                database.addRecord(record);
            }

            return database;
        }
    }
}
