using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Template {
    public interface ITemplateCreator<TFeatureVector, TTemplate> 
        where TFeatureVector : FeatureVector.IFeatureVector 
        where TTemplate : ITemplate<TFeatureVector> {
        /// <summary>
        /// creates template from featue vector
        /// </summary>
        /// <param name="featureVector">given feature vector</param>
        /// <returns>new template</returns>
        TTemplate createTemplate(TFeatureVector featureVector);

        /// <summary>
        /// creates empty template from featue vector
        /// </summary>
        /// <returns>new template</returns>
        TTemplate createEmptyTemplate();

        /// <summary>
        /// add to template
        /// </summary>
        /// <param name="to"></param>
        /// <param name="featureVector"></param>
        void addToTemplate(TTemplate to, TFeatureVector featureVector);
    }
}
