using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIO.Framework.Utils.UI.Evaluation.Results {
    public partial class SingleBiometricAlgorithmDataVisualizer : UserControl {

        public virtual void init(string method_, BIO.Framework.Core.Evaluation.Results.Statistics statistics_, BIO.Framework.Core.Evaluation.Results.Results results_) {
            this.method = method_;
            this.statistics = statistics_;
            this.results = results_;
            this.specificInit();
        }
        public SingleBiometricAlgorithmDataVisualizer(){
            InitializeComponent();
        }

        private void checkInited() {
            if (results == null || statistics == null) {
                throw new InvalidOperationException("Method data visulaizer not initialized");
            }
        }

        private bool isNeededVar = false;
        protected bool isNeeded() {
            return isNeededVar;
        }
        public void setAsNeeded() {
            if (this.isNeededVar == false) {
                this.isNeededVar = true;
                this.myRefresh();
            }
        }

        private string method = "";
        public string getMethod() {
            this.checkInited();
            return method;
        }
        private BIO.Framework.Core.Evaluation.Results.Results results = null;
        protected BIO.Framework.Core.Evaluation.Results.Results getResults() {
            this.checkInited();
            return results;
        }
        private BIO.Framework.Core.Evaluation.Results.Statistics statistics = null;
        public BIO.Framework.Core.Evaluation.Results.Statistics getStatistics() {
            this.checkInited();
            return statistics;
        }

        public virtual void specificInit() {

        }
        public virtual void myRefresh() {

        }


    }
}
