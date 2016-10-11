using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ZedGraph;

namespace BIO.Framework.Utils.UI.Evaluation.Results {
    public partial class EvaluatorsDETGraph : MultipleEvaluatorDataVisualizer {

        List<LineItem> DETCurves = new List<LineItem>();

        public EvaluatorsDETGraph() {
            InitializeComponent();
        }

        protected override void initComponents() {
            foreach (Method e in this.getAllMethods()) {
                //e.statistics.OrientationChanged += new Statistics.ChangedThreshEventHandler(EvaluatorsROCGraph_ThreshChanged);
            }
            this.createGraph();
        }

        protected override void computeData(BackgroundWorker bw) {
            if (this.getResults() == null) return;

            this.tickTotal = this.getAllMethods().Count;

            data = new List<DETData>();
            foreach (Method e in this.getAllMethods()) {
                DETData dd = new DETData(e.statistics);
                dd.initThreshes();
                dd.computeData(this);
                data.Add(dd);
            }
        }

        protected override void drawData() {
            for (int i = 0; i < DETCurves.Count; i++) {
                DETCurves[i].Clear();
                for (int p = 0; p < DETData.STEP; p++) {
                    DETCurves[i].AddPoint(new PointPair(data[i].FalseAcceptance[p], data[i].FalseRejection[p]));
                }
            }
        }

        class DETData {
            BIO.Framework.Core.Evaluation.Results.Statistics stats;
            public DETData(BIO.Framework.Core.Evaluation.Results.Statistics s) {
                stats = s.createCopy();
            }

            public const int STEP = 50;

            double[] threshes = new double[STEP];
            public double[] FalseRejection = new double[STEP];
            public double[] FalseAcceptance = new double[STEP];

            public void initThreshes() {

                threshes[0] = stats.GlobalExtremes.min;
                threshes[STEP - 1] = stats.GlobalExtremes.max;
                double diff = (stats.OverlapAreaExtremes.max - stats.OverlapAreaExtremes.min) / (STEP - 2);
                if (diff < 0.0) {
                    //no detail data - perfect separation
                    for (int i = 0; i < STEP - 2; i++) {
                        threshes[1 + i] = (stats.OverlapAreaExtremes.max + stats.OverlapAreaExtremes.min) / 2;
                    }
                } else {
                    for (int i = 0; i < STEP - 2; i++) {
                        threshes[1 + i] = i * diff + stats.OverlapAreaExtremes.min;
                    }
                }

            }
            public void computeData(EvaluatorsDETGraph graph) {
                double totalGenuine = stats.GenuinesCount;
                double totalImpostor = stats.ImpostorsCount;
                for (int i = 0; i < STEP; i++) {
                    stats.Thresh = threshes[i];
                    FalseRejection[i] = stats.FalseRejection / totalGenuine;
                    FalseAcceptance[i] = stats.FalseAcceptance / totalImpostor;


                }
                graph.reportTick();
            }
        }

        List<DETData> data;


        private void createGraph() {
            GraphPane myPane = zedGraphControlDET.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "DET curves";

            myPane.XAxis.Title.Text = "false acceptance rate";
            myPane.YAxis.Title.Text = "false rejection rate";

            List<Color> colors = new List<Color>();
            colors.Add(Color.Red);
            colors.Add(Color.Green);
            colors.Add(Color.Blue);
            colors.Add(Color.PowderBlue);
            colors.Add(Color.Yellow);
            colors.Add(Color.Pink);
            colors.Add(Color.DarkKhaki);
            colors.Add(Color.Orange);
            colors.Add(Color.Violet);
            colors.Add(Color.Gray);
            colors.Add(Color.Black);
            colors.Add(Color.Cyan);
            colors.Add(Color.Magenta);
            colors.Add(Color.Chocolate);

            int color = 0;

            foreach (Method e in this.getAllMethods()) {
                LineItem i = myPane.AddCurve(e.method, new PointPairList(), colors[color], SymbolType.None);
                color = ++color % colors.Count;
                i.Line.Width = 2;
                DETCurves.Add(i);
            }

            myPane.Legend.FontSpec.Size = 5;

            zedGraphControlDET.AxisChange();

        }






    }
}
