using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIO.Framework.Core;
using BIO.Framework.Extensions.Standard.FeatureVector;

namespace BIO.Project.Example2.Statistical {
    abstract class StatisticalMethod {
        public abstract double[] project(double[] original);

        public abstract void train(double[,] sourceData, int[] labels);

        //public void train(DoubleArrayFeatureVector original);

        //public double test(DoubleArrayFeatureVector original);

    }
}
