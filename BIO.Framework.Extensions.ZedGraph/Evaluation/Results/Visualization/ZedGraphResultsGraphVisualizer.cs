using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;

using BIO.Framework.Core.Evaluation.Results;

namespace BIO.Framework.Extensions.ZedGraph.Evaluation.Results.Visualization {
    public class ZedGraphResultsGraphVisualizer : BIO.Framework.Core.Evaluation.Results.Visualization.IResultsGraphVisualizer<GraphPane> {

        public string FileName { get; set; }

        public ZedGraphResultsGraphVisualizer(string fileName) {
            this.FileName = fileName;
        }

        public void saveGraphToFile(GraphPane graph, string fileName) {
            Bitmap bm = new Bitmap(1, 1);
            using (Graphics g = Graphics.FromImage(bm)) {
                graph.AxisChange(g);
            }
            // For ZedGraph 4.3, the next line is: myPane.Image.Save( @"zedgraph.png", ImageFormat.Png );
            graph.GetImage().Save(fileName);
        }

        public GraphPane createGenuineImpostorGraph(BIO.Framework.Core.Evaluation.Results.Results results) {

            //TODO FIXME
            string method = results.getResultsList().First().getMethods().First();

            Statistics s = new Statistics(method, results);

            List<double> genuine = new List<double>();
            List<double> impostor = new List<double>();

            for (int x = 0; x <= 100; x++) {
                genuine.Add(0);
                impostor.Add(0);
            }

            double max = s.GlobalExtremes.max;
            double min = s.GlobalExtremes.min;

            int step = 2;

            foreach (Result r in results.getResultsList()) {
                
                double value = r.getMatchingScore(method).Score;

                    Int32 bin = (Int32)(((value - min) * 100.0 / (max - min)));

                    if (bin < 0) bin = 0;
                    if (bin >= 100) bin = 99;
                    
                    //round to 50 bins
                    bin = bin / step * step;

                    if (r.isGenuine()) {
                        genuine[bin]++;
                    } else {
                        impostor[bin]++;
                    }
            }
            

            GraphPane myPane = new GraphPane(new RectangleF(0, 0, 1024, 768),
                         "Genuine Impostor", "score", "count");

            PointPairList glist = new PointPairList();
            PointPairList ilist = new PointPairList();
            for (int x = 0; x <= 100; x+= step) {
                glist.Add(x, genuine[x]);
                ilist.Add(x, impostor[x]);
            }

            LineItem myCurve1 = myPane.AddCurve("genuine", glist, Color.Green, SymbolType.Diamond);
            LineItem myCurve2 = myPane.AddCurve("impostor", ilist, Color.Red, SymbolType.Diamond);

            return myPane;
        }

        /// <summary>
        /// create ROC curve graph
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public GraphPane createROCGraph(BIO.Framework.Core.Evaluation.Results.Results results) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// create DET curve graph
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public GraphPane createDETGraph(BIO.Framework.Core.Evaluation.Results.Results results) {
            throw new NotImplementedException();
        }

        #region IResultsVisualizer Members

        public void postprocessResults(BIO.Framework.Core.Evaluation.Results.Results results) {
            this.onProgressChanged(new Core.ProgressReport("ZedGraph: Generate graph"));
            this.saveGraphToFile(this.createGenuineImpostorGraph(results), this.FileName);
        }

        #endregion

        #region IProgressReporter Members

        public event Core.ProgressChangedEventHandler ProgressChangedEvent;

        public void onProgressChanged(Core.ProgressReport e) {
            if (ProgressChangedEvent != null) {
                ProgressChangedEvent(e);
            }
        }

        #endregion
    }
}
