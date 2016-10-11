using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIO.Framework.Utils.UI.Evaluation.Results {
    public partial class EvaluationStatisticsControl : SingleBiometricAlgorithmDataVisualizer {


        public EvaluationStatisticsControl() {
            InitializeComponent();
        }

        public override void specificInit() {
            this.getStatistics().ThreshChanged += new Core.Evaluation.Results.Statistics.SettingsChangedEventHandler(EvaluationStatisticsControl_ThreshChanged);
            this.getStatistics().OrientationChanged += new Core.Evaluation.Results.Statistics.SettingsChangedEventHandler(EvaluationStatisticsControl_OrientationChanged);
            this.myRefresh();
        }

        void EvaluationStatisticsControl_OrientationChanged(Core.Evaluation.Results.Statistics.StatisticsSettings statisticsSettings) {
            this.myRefresh();
        }

        void EvaluationStatisticsControl_ThreshChanged(Core.Evaluation.Results.Statistics.StatisticsSettings statisticsSettings) {
            this.myRefresh();
        }

        

        bool notRefresh = false;

        public override void myRefresh() {

            if (this.notRefresh) return;

            this.labelE.Text = this.getStatistics().GlobalExtremes.ToString();
            this.labelGE.Text = this.getStatistics().GenuineExtremes.ToString();
            this.labelIE.Text = this.getStatistics().ImpostorExtremes.ToString();

            double oneStep = (this.getStatistics().GlobalExtremes.max - this.getStatistics().GlobalExtremes.min) / 1000.0;

            int trackBarValue = 0;
            if (this.getStatistics().Thresh > this.getStatistics().GlobalExtremes.min && oneStep > 0) {
                trackBarValue = (int)((this.getStatistics().Thresh - this.getStatistics().GlobalExtremes.min) / oneStep);
                if (trackBarValue > 1000) trackBarValue = 1000;
            }
            notRefresh = true;
            this.trackBar1.Value = trackBarValue;
            this.textBox1.Text = this.getStatistics().Thresh.ToString();
            if (this.getStatistics().UnderThreshAccepted) {
                this.radioButtonLower.Select();
            } else {
                this.radioButtonHigher.Select();
            }
            notRefresh = false;

            this.labelFA.Text = this.getStatistics().FalseAcceptance.ToString();
            this.labelFR.Text = this.getStatistics().FalseRejection.ToString();
            this.labelTA.Text = this.getStatistics().TrueAcceptance.ToString();
            this.labelTR.Text = this.getStatistics().TrueRejection.ToString();

            this.labelFAR.Text = String.Format("{0:0.0}", this.getStatistics().FAR * 100.0) + "%";
            this.labelFRR.Text = String.Format("{0:0.0}", this.getStatistics().FRR * 100.0) + "%";

            //this.parentRefresh();
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            double oneStep = (this.getStatistics().GlobalExtremes.max - this.getStatistics().GlobalExtremes.min) / 1000.0;

            this.getStatistics().Thresh = (this.getStatistics().GlobalExtremes.min + trackBar1.Value * oneStep);
        }

        private void radioButtonLower_CheckedChanged(object sender, EventArgs e) {
            this.getStatistics().UnderThreshAccepted = true;
        }

        private void radioButtonHigher_CheckedChanged(object sender, EventArgs e) {
            this.getStatistics().UnderThreshAccepted = false;
        }
    }
}
