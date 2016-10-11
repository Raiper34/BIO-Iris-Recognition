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
    public class TemplateAndEvaluationDatabaseSubsetCreator <TRecord> : DatabaseSubsetCreator<TRecord> where TRecord : BIO.Framework.Core.Database.IRecord {
        public const string TemplateSubset = "template";
        public const string EvaluationSubset = "evaluation";

        int maxTemplatesCount = 1;

        public TemplateAndEvaluationDatabaseSubsetCreator(BIO.Framework.Core.Database.Database<TRecord> fullDatabase)
            : base(fullDatabase) {
        }

        public TemplateAndEvaluationDatabaseSubsetCreator(BIO.Framework.Core.Database.Database<TRecord> fullDatabase, int maxTemplatesCount) : base(fullDatabase) {
            this.maxTemplatesCount = maxTemplatesCount;
        }

        protected override Dictionary<string, Core.Database.Database<TRecord>> createSubsets() {

            Dictionary<string, Core.Database.Database<TRecord>> db = new Dictionary<string, Core.Database.Database<TRecord>>();
            db.Add(TemplateSubset, new Core.Database.Database<TRecord>());
            db.Add(EvaluationSubset, new Core.Database.Database<TRecord>());
            
            foreach (BiometricID bid in this.FullDatabase.getCollections().getBiometricIDs()) { 
                int act = 0;
                int size = this.FullDatabase.getCollections().getRecordsByBiometricID(bid).Count();
                foreach (TRecord r in this.FullDatabase.getCollections().getRecordsByBiometricID(bid)){
                    if (act < maxTemplatesCount) {
                        db[TemplateSubset].addRecord(r);
                    } else {
                        db[EvaluationSubset].addRecord(r);
                    }
                    act++;
                }
            }

            return db;
        }
    }
}
