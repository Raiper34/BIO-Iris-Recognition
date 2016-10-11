using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Database;

namespace BIO.Framework.Extensions.Standard.Database.Subsets {
    /// <summary>
    /// Divide database to two subsets
    /// Template subset 
    /// Evaluation subset
    /// From tempaltes records the biometric template are created. Then is is compared against evaluation set
    /// </summary>
    /// <typeparam name="TRecord"></typeparam>
    public class TrainTestAndValidationDatabaseSubsetCreator <TRecord> : DatabaseSubsetCreator<TRecord> where TRecord : BIO.Framework.Core.Database.IRecord {
        public const string TrainSubset = "train";
        public const string TestSubset = "test";
        public const string ValidationSubset = "validation";

        /// <summary>
        /// (train + test) to validation ratio -> should be between 0 and 1
        /// </summary>
        double trainAndTestToValidationRatio = 0.75;
        private double TrainAndTestToValidationRatio {
            get { return trainAndTestToValidationRatio; }
            set { 
                if (value < 0.0) throw new ArgumentOutOfRangeException("TrainAndTestToValidationRatio", value, "should be between 0 and 1");
                if (value > 1.0) throw new ArgumentOutOfRangeException("TrainAndTestToValidationRatio", value, "should be between 0 and 1");
                trainAndTestToValidationRatio = value;
            }
        }
        /// <summary>
        /// train to test ratio -> should be between 0 and 1
        /// </summary>
        double trainToTestRatio = 0.75;
        private double TrainToTestRatio {
            get { return trainToTestRatio; }
            set {
                if (value < 0.0) throw new ArgumentOutOfRangeException("TrainToTestRatio", value, "should be between 0 and 1");
                if (value > 1.0) throw new ArgumentOutOfRangeException("TrainToTestRatio", value, "should be between 0 and 1");
                trainToTestRatio = value;
            }
        }

        public TrainTestAndValidationDatabaseSubsetCreator(BIO.Framework.Core.Database.Database<TRecord> fullDatabase)
            : base(fullDatabase) {
        }

        public TrainTestAndValidationDatabaseSubsetCreator(BIO.Framework.Core.Database.Database<TRecord> fullDatabase, double trainAndTestToValidationRatio, double trainToTestRatio)
            : base(fullDatabase) {
                this.TrainAndTestToValidationRatio = trainAndTestToValidationRatio;
                this.TrainToTestRatio = trainToTestRatio;
        }

        protected override Dictionary<string, Core.Database.Database<TRecord>> createSubsets() {

            Dictionary<string, Core.Database.Database<TRecord>> db = new Dictionary<string, Core.Database.Database<TRecord>>();
            db.Add(TrainSubset, new Core.Database.Database<TRecord>());
            db.Add(TestSubset, new Core.Database.Database<TRecord>());
            db.Add(ValidationSubset, new Core.Database.Database<TRecord>());
            
            foreach (BiometricID bid in this.FullDatabase.getCollections().getBiometricIDs()) { 
                int act = 0;
                int size = this.FullDatabase.getCollections().getRecordsByBiometricID(bid).Count();

                //int fromTrainIndex = 0;
                int fromTestIndex = (int)((trainAndTestToValidationRatio * size * trainToTestRatio));
                int fromValidationIndex = (int)(trainAndTestToValidationRatio * size);

                //int maxTemplatesCount = (int)(trainDbRatio * size);
                foreach (TRecord r in this.FullDatabase.getCollections().getRecordsByBiometricID(bid)){
                    if (act >= fromValidationIndex) {
                        db[ValidationSubset].addRecord(r);
                    } else if (act >= fromTestIndex) {
                        db[TestSubset].addRecord(r);
                    } else {
                        db[TrainSubset].addRecord(r);
                    }
                    act++;
                }
            }

            return db;
        }
    }
}
