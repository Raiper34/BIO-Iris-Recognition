using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.Template {

    [Serializable]
    public class Template <TFeatureVector> : Core.Template.ITemplate<TFeatureVector>
        where TFeatureVector : Core.FeatureVector.IFeatureVector {

        List<TFeatureVector> featureVectors = new List<TFeatureVector>();



        #region ITemplate<TFeatureVector> Members

        public void addFeatureVector(TFeatureVector featureVector) {
            this.featureVectors.Add(featureVector);
        }

        #endregion

        #region IEnumerable<TFeatureVector> Members

        public IEnumerator<TFeatureVector> GetEnumerator() {
            foreach (TFeatureVector fv in featureVectors){
                yield return fv;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
             foreach (TFeatureVector fv in featureVectors){
                yield return fv;
            }
        }

        #endregion

        
    }
}
