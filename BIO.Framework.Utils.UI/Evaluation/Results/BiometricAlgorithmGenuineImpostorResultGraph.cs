using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using BIO.Framework.Core;
using BIO.Framework.Core.Comparator;

namespace BIO.Framework.Utils.UI.Evaluation.Results {
    public partial class EvaluatorGenuineImpostorResultGraph : SingleBiometricAlgorithmDataVisualizer {

        int binCount = 100;

        private PointPairList threshPoints = new PointPairList();

        public override void specificInit() {

            this.getStatistics().ThreshChanged += new Core.Evaluation.Results.Statistics.SettingsChangedEventHandler(EvaluatorGenuineImpostorResultGraph_ThreshChanged);
        
            this.createGraph();
        }

        void EvaluatorGenuineImpostorResultGraph_ThreshChanged(Core.Evaluation.Results.Statistics.StatisticsSettings statisticsSettings) {
            int bin = this.getBin(statisticsSettings.newThresh, this.getStatistics().GlobalExtremes.max);
            threshPoints[0].X = bin;
            threshPoints[1].X = bin;
            this.zgc.Refresh();
        }

        public EvaluatorGenuineImpostorResultGraph() {
            InitializeComponent();
        }


        LineItem myCurveG = null;
        LineItem myCurveI = null;

        

        private int getBin(double value, double maxDistance) {
            return (int)(value * (binCount - 1) / maxDistance);
        }
        
        public void fillHistogram(ref int[] histogram, bool genuine) {
            int binCount = histogram.Count();
            double maxDistance = this.getStatistics().GlobalExtremes.max;

            foreach (BIO.Framework.Core.Evaluation.Results.Result value in this.getResults().getResultsList()) {
               
                bool isGeniune = value.isGenuine();
                if ((genuine && isGeniune) || (!genuine && !isGeniune)) {
                    MatchingScore ms = value.getMatchingScore(this.getMethod());

                    if (!ms.IsValid) {
                        continue;
                    }

                    int bin = getBin(ms.Score, maxDistance);
                    if (bin < 0 || bin >= histogram.Count()) {
                        continue;
                    }
                    histogram[bin]++;
                    
                }
            }
        }

        

        public void updatePanes() {
            
            int[] histogramGenuine = new int[binCount];
            int[] histogramImpostor = new int[binCount];

            for (int i = 0; i < binCount; i++) {
                histogramGenuine[i] = 0;
                histogramImpostor[i] = 0;
            }

            //fill histogram by values from evaluation
            this.fillHistogram(ref histogramGenuine, true);
            this.fillHistogram(ref histogramImpostor, false);

            double genuineRatio = 100.0 / this.getStatistics().GenuinesCount;
            double impostorRatio = 100.0 / this.getStatistics().ImpostorsCount;

            double max = 0;

            PointPairList listG = new PointPairList();
            PointPairList listI = new PointPairList();
            for (int i = 0; i < binCount; i++) {
                double gvalue = histogramGenuine[i] * genuineRatio;
                double ivalue = histogramImpostor[i] * impostorRatio;
                listG.Add(i, gvalue);
                listI.Add(i, ivalue);

                if (gvalue > max) {
                    max = gvalue;
                }
                if (ivalue > max) {
                    max = ivalue;
                }
            }

            myCurveG.Clear();
            myCurveG.Points = listG;

            myCurveI.Clear();
            myCurveI.Points = listI;

            int threshBin = getBin(this.getStatistics().Thresh, this.getStatistics().GlobalExtremes.max);

            threshPoints.Clear();
            threshPoints.Add(new PointPair(threshBin, 0));
            threshPoints.Add(new PointPair(threshBin, max + 0.1));

        }

        public void createGraph() {

            //zgc.GraphPane = new GraphPane();
            GraphPane myPane = zgc.GraphPane;

            
            // Set the titles and axis labels
            myPane.Title.Text = this.getMethod() + " results";
            myPane.XAxis.Title.Text = "distance";
            myPane.YAxis.Title.Text = "relative count";


            myCurveG = myPane.AddCurve("Genuines", new PointPairList(), Color.Green, SymbolType.Circle);
            myCurveI = myPane.AddCurve("Impostors", new PointPairList(), Color.Red, SymbolType.Circle);

            myCurveG.Line.Width = 1;
            myCurveI.Line.Width = 1;

            myCurveG.Line.Fill = new Fill(Color.FromArgb(60, 0, 255, 0));
            myCurveI.Line.Fill = new Fill(Color.FromArgb(60, 255, 0, 0));

            myCurveG.Symbol.Size = 2;
            myCurveI.Symbol.Size = 2;

            myCurveG.Symbol.Fill = new Fill(Color.Green);
            myCurveI.Symbol.Fill = new Fill(Color.Red);

            LineItem myCurveThresh = myPane.AddCurve("Thresh", threshPoints, Color.Black, SymbolType.None);
            myCurveThresh.Line.Width = 1;
            myCurveThresh.Line.Style = System.Drawing.Drawing2D.DashStyle.Dot;


            this.updatePanes();

            

            zgc.AxisChange();

        }


    }
}
