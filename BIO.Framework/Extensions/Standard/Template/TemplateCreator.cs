using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Template;
using BIO.Framework.Core;


namespace BIO.Framework.Extensions.Standard.Template {
    public class TemplateCreator<
        TFeatureVector, 
        TTemplate> 
     : ITemplateCreator<
        TFeatureVector, 
        TTemplate
     >
        where TFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector
        where TTemplate : BIO.Framework.Core.Template.ITemplate<TFeatureVector>, new() {

        #region ITemplateCreator<TFeatureVector,TTemplate> Members

        public TTemplate createTemplate(TFeatureVector featureVector) {
            TTemplate t = new TTemplate();
            t.addFeatureVector(featureVector);
            return t;
        }

        public void addToTemplate(TTemplate to, TFeatureVector featureVector) {
            to.addFeatureVector(featureVector);
        }

        #endregion

        #region ITemplateCreator<TFeatureVector,TTemplate> Members


        public TTemplate createEmptyTemplate() {
            TTemplate t = new TTemplate();
            return t;
        }

        #endregion
    }
}
