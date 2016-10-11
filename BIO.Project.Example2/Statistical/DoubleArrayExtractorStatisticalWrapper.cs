using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIO.Framework.Core;
using BIO.Framework.Extensions.Standard.FeatureVector;
using BIO.Framework.Core.FeatureVector;

namespace BIO.Project.Example2.Statistical {
    class DoubleArrayExtractorStatisticalWrapper <TInputData> : IFeatureVectorExtractor<TInputData, DoubleArrayFeatureVector>
    where TInputData : BIO.Framework.Core.InputData.IInputData {

        IFeatureVectorExtractor<TInputData, DoubleArrayFeatureVector> internalExtractor = null;

        public IFeatureVectorExtractor<TInputData, DoubleArrayFeatureVector> InternalExtractor {
            get { return internalExtractor; }
        }

        StatisticalMethod method = null;

        public DoubleArrayExtractorStatisticalWrapper(
            IFeatureVectorExtractor<TInputData, DoubleArrayFeatureVector> internalExtractor,
            StatisticalMethod method
            ) {
                this.internalExtractor = internalExtractor;
                this.method = method;
        }


        #region IFeatureVectorExtractor<TInputData,DoubleArrayFeatureVector> Members

        public DoubleArrayFeatureVector extractFeatureVector(TInputData input) {
            DoubleArrayFeatureVector fv = internalExtractor.extractFeatureVector(input);
            double[] data = method.project(fv.FeatureVector);
            return new DoubleArrayFeatureVector(data);
        }

        #endregion

        internal void train(List<TInputData> data) {

            bool sourceMatrixCreated = false;
            double[,] sourceMatrix = new double[0, 0];
            int[] labels = new int[0];
            //Accord.Math.Matrix.

            int index = 0;

            foreach (TInputData input in data) {
                DoubleArrayFeatureVector fv = this.InternalExtractor.extractFeatureVector(input);

                if (!sourceMatrixCreated) {
                    sourceMatrix = new double[data.Count(), fv.FeatureVector.Count()];
                    labels = new int[data.Count()];
                    sourceMatrixCreated = true;
                }
                Accord.Math.Matrix.SetRow<double>(sourceMatrix, index, fv.FeatureVector);
                index++;
            }

            method.train(sourceMatrix, labels);
            
        }
    }
}
