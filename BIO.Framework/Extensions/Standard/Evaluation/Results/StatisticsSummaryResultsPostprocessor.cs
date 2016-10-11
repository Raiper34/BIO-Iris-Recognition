using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BIO.Framework.Core.Evaluation.Results;
using BIO.Framework.Core.Evaluation.Results.Visualization;
using BIO.Framework.Core;

namespace BIO.Framework.Extensions.Standard.Evaluation.Results.Visualization {
    public class StatisticsSummaryResultsPostprocessor : IResultsVisualizer {

        public string FileName { get; set; }

        public StatisticsSummaryResultsPostprocessor() {
            FileName = "summary.txt";
        }
        public StatisticsSummaryResultsPostprocessor(string filename) {
            FileName = filename;
        }

        #region IProgressReporter Members

        public event Core.ProgressChangedEventHandler ProgressChangedEvent;

        public void onProgressChanged(Core.ProgressReport e) {
            if (this.ProgressChangedEvent != null) {
                this.ProgressChangedEvent(e);
            }
        }

        #endregion
    
        #region IResultsPostprocessor Members

        public void  postprocessResults(Core.Evaluation.Results.Results results){
            string summary = "";

            foreach (string method in results.Methods) {
                this.onProgressChanged(new ProgressReport("StatisticsSummary: " + method)); 
                Statistics s = new Statistics(method, results);
                summary += method + ";" + s.FAR.ToString() + ";" + s.FRR.ToString() + "\n";
            }

            File.WriteAllText(FileName, summary);
            this.onProgressChanged(new ProgressReport("StatisticsSummary: done")); 
        }

        #endregion
}
}
