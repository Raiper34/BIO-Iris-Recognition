using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Evaluation {
    public interface IBiometricSystemEvaluator<TInputRecord> : IProgressReporter where TInputRecord : Database.IRecord {
        /// <summary>
        /// extract tempaltes
        /// get list of database records and create templates from each of them
        /// </summary>
        /// <param name="inputDatabase">input database</param>
        /// <param name="templateDatabase">output database</param>
        void extractTemplates(Database.IRecordEnumerable<TInputRecord> inputDatabase, Database.TemplateDatabase.TemplateDatabase templateDatabase);

        /// <summary>
        /// evaluate records - compare each template against each input and save results
        /// </summary>
        /// <param name="inputDatabase"></param>
        /// <param name="templateDatabase"></param>
        /// <param name="results"></param>
        void evaluateRecords(Database.IRecordEnumerable<TInputRecord> inputDatabase, Database.TemplateDatabase.TemplateDatabase templateDatabase, Results.Results results);

    }
}
