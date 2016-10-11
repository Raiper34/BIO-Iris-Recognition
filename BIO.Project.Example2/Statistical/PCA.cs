using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accord.Statistics.Analysis;

namespace BIO.Project.Example2.Statistical {
    class PCA : StatisticalMethod {

        protected double fvSpaceReduction = 0.25;

        protected Accord.Statistics.Analysis.PrincipalComponentAnalysis pca = null;

        public override double[] project(double[] original) {

            if (pca == null) {
                throw new InvalidOperationException("PCA is not trained");
            }

            double[,] input = new double[1, original.Length];
            Accord.Math.Matrix.SetRow<double>(input, 0, original);
            int reduction = (int)(pca.Components.Count() * this.fvSpaceReduction);
            double[,] output = pca.Transform(input, reduction);
            return Accord.Math.Matrix.GetRow<double>(output, 0);
            
        }

        public override void train(double[,] sourceData, int[] labels) {
            pca = new PrincipalComponentAnalysis(sourceData, Accord.Statistics.Analysis.AnalysisMethod.Standardize);
            pca.Compute();
        }
    }
}
