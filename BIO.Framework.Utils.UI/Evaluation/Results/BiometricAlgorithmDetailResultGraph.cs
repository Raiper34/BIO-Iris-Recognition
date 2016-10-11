using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using BIO.Framework.Core.Comparator;

namespace BIO.Framework.Utils.UI.Evaluation.Results {
    public partial class BiometricAlgorithmDetailResultGraph : SingleBiometricAlgorithmDataVisualizer {

        private PointPairList threshPoints = new PointPairList();

        public override void specificInit() {
            this.getStatistics().ThreshChanged += new Core.Evaluation.Results.Statistics.SettingsChangedEventHandler(BiometricAlgorithmDetailResultGraph_ThreshChanged);   // ThreshChanged += new BIO.Framework.Core.Evaluation.Results.Statistics.ChangedThreshEventHandler(EvaluatorDetailResultGraph_ThreshChanged);
            this.createGraph();
        }

        void BiometricAlgorithmDetailResultGraph_ThreshChanged(Core.Evaluation.Results.Statistics.StatisticsSettings statisticsSettings) {
            threshPoints[0].Y = statisticsSettings.newThresh;
            threshPoints[1].Y = statisticsSettings.newThresh;
            this.zgc.Refresh();
        }




        public BiometricAlgorithmDetailResultGraph() {
            InitializeComponent();
            //zgc = new ZedGraphControl();

            //this.Controls.Add(zgc);

            //zgc.Dock = DockStyle.Fill;
            zgc.IsShowPointValues = true;
            zgc.PointValueEvent += new ZedGraphControl.PointValueHandler(myPointValueHandler);
            zgc.MouseDownEvent += new ZedGraphControl.ZedMouseEventHandler(zgc_MouseDownEvent);


        }

        bool zgc_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e) {
            GraphPane myPane = sender.GraphPane;
            CurveItem c;
            int index;
            if (myPane.FindNearestPoint(new PointF(e.X, e.Y), out c, out index)) {
                BIO.Framework.Core.Evaluation.Results.Result r = c[index].Tag as BIO.Framework.Core.Evaluation.Results.Result;
                if (r != null) {
                    /*
                    TBS.Database.Forms.RecordMatchDetailForm form = new TBS.Database.Forms.RecordMatchDetailForm(r.TemplateRecord, r.CurrentRecord);
                    form.Size = new Size(1100, 670);
                    //TBS.Database.Forms.RecordDetailForm form = new TBS.Database.Forms.RecordDetailForm(r.CurrentRecord);
                    form.ShowDialog();*/
                    return true;
                }

            }
            return false;

        }
        private string myPointValueHandler(object sender, GraphPane pane, CurveItem curve, int iPt) {
            PointPair pt = curve[iPt];
            BIO.Framework.Core.Evaluation.Results.Result r = pt.Tag as BIO.Framework.Core.Evaluation.Results.Result;
            if (r != null) {
                return r.getMatchingScore(this.getMethod()) + " " + r.TemplateRecord.BiometricID.PersonID + " x " + r.TestedRecord.BiometricID.PersonID;
            }
            return "???";
        }


        LineItem myCurveG = null;
        LineItem myCurveI = null;

        int maxTemplateNumber = 0;
        private Dictionary<string, int> templateNumbers = new Dictionary<string, int>();

        private void fillDistances(List<BIO.Framework.Core.Evaluation.Results.Result> results, ref PointPairList data, bool genuine) {


            data.Clear();
            //int templateNumber = 0;
            foreach (BIO.Framework.Core.Evaluation.Results.Result r in results) {

                bool isGenuine = r.isGenuine();
                if ((genuine && isGenuine) || (!genuine && !isGenuine)) {
                    MatchingScore ms = r.getMatchingScore(this.getMethod());
                   
                    //distances.Add(value.Value.getValue(evaluator));
                    if (!ms.IsValid) {
                        continue;
                    }
                    int tn = 0;
                    string key = r.TemplateRecord.BiometricID.PersonID;
                    if (templateNumbers.ContainsKey(key)) {
                        tn = templateNumbers[key];
                    } else {
                        templateNumbers.Add(key, this.maxTemplateNumber++);
                        tn = templateNumbers[key];
                    }

                    PointPair p = new PointPair(tn, ms.Score);
                    p.Tag = r;
                    data.Add(p);
                }
            }
           
        }


        public void updatePanes() {

            PointPairList listG = new PointPairList();
            PointPairList listI = new PointPairList();

            this.fillDistances(this.getResults().getResultsList(), ref listG, true);
            this.fillDistances(this.getResults().getResultsList(), ref listI, false);

            PointPairList listG_IE = new PointPairList();
            PointPairList listG_O = new PointPairList();

            PointPairList listI_IE = new PointPairList();
            PointPairList listI_O = new PointPairList();

            listG_IE = listG;
            listI_IE = listI;

            myCurveG.Clear();
            myCurveG.Points = listG_IE;

            myCurveI.Clear();
            myCurveI.Points = listI_IE;

            
        }

        public void createGraph() {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = this.getMethod() + " results";
            myPane.XAxis.Title.Text = "template #";
            myPane.YAxis.Title.Text = "distance";

            myCurveG = myPane.AddCurve("Genuine", new PointPairList(), Color.Black, SymbolType.Diamond);
            myCurveG.Line.IsVisible = false;
            myCurveG.Symbol.Border.IsVisible = false;
            myCurveG.Symbol.Fill = new Fill(Color.Green);
            myCurveG.Symbol.Size = 6;

            myCurveI = myPane.AddCurve("Impostor", new PointPairList(), Color.Black, SymbolType.Diamond);
            myCurveI.Line.IsVisible = false;
            myCurveI.Symbol.Border.IsVisible = false;
            myCurveI.Symbol.Fill = new Fill(Color.Red);
            myCurveI.Symbol.Size = 5;

            this.updatePanes();

            threshPoints.Clear();
            threshPoints.Add(new PointPair(-1, this.getStatistics().Thresh));
            int max = 0;
            if (myCurveG.Points.Count > 0) {
                max = (int)myCurveG.Points[myCurveG.Points.Count - 1].X;
            }
            if (myCurveI.Points.Count > 0 && myCurveI.Points[myCurveI.Points.Count - 1].X > max) {
                max = (int)myCurveI.Points[myCurveI.Points.Count - 1].X;
            }
            threshPoints.Add(new PointPair(max + 1, this.getStatistics().Thresh));

            LineItem myCurveThresh = myPane.AddCurve("Thresh", threshPoints, Color.Black, SymbolType.None);
            myCurveThresh.Line.Style = System.Drawing.Drawing2D.DashStyle.Dot;

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
        }

    }
}
