using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Template {
    /// <summary>
    /// template
    /// </summary>
    /// <typeparam name="TFeatureVector"></typeparam>
    public interface ITemplate <TFeatureVector> : IEnumerable<TFeatureVector>
        where TFeatureVector : FeatureVector.IFeatureVector {
        /// <summary>
        /// add feature vector to template
        /// </summary>
        /// <param name="featureVector"></param>
        void addFeatureVector(TFeatureVector featureVector);
    }
}
