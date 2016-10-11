using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIO.Framework.Utils.UI.Evaluation.Results {
    public partial class ResultsViewer : UserControl {

        string method;

        BIO.Framework.Core.Evaluation.Results.Results results;

        BIO.Framework.Core.Evaluation.Results.Statistics statistics;

        public BIO.Framework.Core.Evaluation.Results.Statistics getStatistics() {
            return statistics;
        }
        public string getMethod() {
            return method;
        }

        public ResultsViewer() {
            InitializeComponent();
        }
        public void init(string method_, BIO.Framework.Core.Evaluation.Results.Results r/*, BIO.Framework.Core.Database.Database<BIO.Framework.Core.Database.Record> d*/) {
            this.results = r;
            this.method = method_;
            //this.evaluationStatisticsControl1

            statistics = new BIO.Framework.Core.Evaluation.Results.Statistics(method, results);

            statistics.autocomputeThresh();

            this.evaluationStatisticsControl1.init(this.method, this.statistics, this.results);
            this.evaluationStatisticsControl1.setAsNeeded();

            this.evaluatorGenuineImpostorResultGraph1.init(this.method, this.statistics, this.results);
            this.evaluatorGenuineImpostorResultGraph1.setAsNeeded();

            this.evaluatorDetailResultGraph1.init(this.method, this.statistics, this.results);
            this.evaluatorDetailResultGraph1.setAsNeeded();
        }
    }
}
