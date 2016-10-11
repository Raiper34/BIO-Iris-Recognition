using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIO.Framework.Utils.UI.Evaluation.Results {
    public partial class ResultsForm : Form {
        public ResultsForm(BIO.Framework.Core.Evaluation.Results.Results r /*, BIO.Framework.Core.Database.Database<BIO.Framework.Core.Database.Record> d*/) {
            InitializeComponent();
            List<string> methods = r.Methods;
            

            List<SingleBiometricAlgorithmDataVisualizer> allMethods = new List<SingleBiometricAlgorithmDataVisualizer>();

            foreach (string m in methods) {
                TabPage page = new TabPage(m);
                ResultsViewer v = new ResultsViewer();
                v.Dock = DockStyle.Fill;
                v.init(m, r/*, d*/);
                page.Controls.Add(v);
                tabControlMethods.TabPages.Add(page);

                allMethods.Add(v.evaluatorGenuineImpostorResultGraph1);
            }

            evaluatorsDETGraph1.init(allMethods, r);
            evaluatorsROCGraph1.init(allMethods, r);



            //this.resultsViewer1.init(method_, r, d);
            //ResultsViewerOLD v = new ResultsViewerOLD();
            //v.init(method_, r, d);
            //this.Controls.Add(v);
        }

       
    }
}
