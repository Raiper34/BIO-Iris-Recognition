using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIO.Framework.Utils.UI.Evaluation.Results {
    public partial class MultipleEvaluatorDataVisualizer : UserControl {

        public class Method {
            public string method;
            public BIO.Framework.Core.Evaluation.Results.Statistics statistics;
        }

        private void checkInited() {
            if (results == null || allMethods == null) {
                throw new InvalidOperationException("Evaluation data visulaizer not initialized");
            }
        }

        protected Method getEvaluator(string evaluator) {
            foreach (Method e in this.allMethods) {
                if (e.method == evaluator) {
                    return e;
                }
            }
            return null;
        }

        private List<Method> allMethods = null;
        protected List<Method> getAllMethods() {
            return this.allMethods;
        }

        private BIO.Framework.Core.Evaluation.Results.Results results = null;
        protected BIO.Framework.Core.Evaluation.Results.Results getResults() {
            this.checkInited();
            return results;
        }


        public MultipleEvaluatorDataVisualizer() {
            InitializeComponent();
        }

        public void init(List<SingleBiometricAlgorithmDataVisualizer> allMethods_, BIO.Framework.Core.Evaluation.Results.Results r_) {
            this.results = r_;
            this.allMethods = new List<Method>();
            foreach (SingleBiometricAlgorithmDataVisualizer eg in allMethods_) {
                Method e = new Method();
                e.method = eg.getMethod();
                e.statistics = eg.getStatistics();
                this.allMethods.Add(e);
            }
            this.initComponents();

        }

        protected virtual void computeData(BackgroundWorker bw) {
            throw new NotImplementedException();
        }
        protected virtual void initComponents() {
            throw new NotImplementedException();
        }
        protected virtual void drawData() {
            throw new NotImplementedException();
        }

        public void startComputing() {
            this.backgroundWorkerCOMPUTE.RunWorkerAsync();
        }

        private void backgroundWorkerCOMPUTE_DoWork(object sender, DoWorkEventArgs e) {
            this.tick = 0;
            this.computeData(this.backgroundWorkerCOMPUTE);

        }
        private int tick = 0;
        protected int tickTotal = 0;
        protected void reportTick() {
            int percent = ++tick * 100 / tickTotal;
            this.backgroundWorkerCOMPUTE.ReportProgress(percent <= 100 ? percent : 100);
        }



        private void backgroundWorkerCOMPUTE_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.drawData();
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.startComputing();
        }

        private void backgroundWorkerCOMPUTE_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            this.progressBar1.Value = e.ProgressPercentage;
        }
    }
}
