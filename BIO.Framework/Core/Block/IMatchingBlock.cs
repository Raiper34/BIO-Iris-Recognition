using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BIO.Framework.Core.Comparator;

namespace BIO.Framework.Core.Block {
    /// <summary>
    /// Atention - programmer is responisble for right usage of interface
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public interface IMatchingBlock<TData> : ITemplateExtractingBlock<TData> {
        /// <summary>
        /// compute matching score of input data against template
        /// </summary>
        /// <param name="data"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        //double computeMatchingScore(TData data, Template.Persistence.IPersistentTemplate template);

        /// <summary>
        /// clear all pushed templates -> all indexes are since then invalid
        /// </summary>
        void resetTemplates();
        /// <summary>
        /// push template to actual buffer -> returns template index that is then used for matching
        /// </summary>
        /// <param name="template"></param>
        /// <returns>template index</returns>
        int pushTemplate(Template.Persistence.IPersistentTemplate template);
        
        /// <summary>
        /// set actual input data
        /// </summary>
        void setInputData(TData inputData);
        /// <summary>
        /// compute matching score of actual input and template in buffer with given index
        /// </summary>
        /// <param name="templateIndex"></param>
        MatchingScore computeMatchingScore(int templateIndex);
    }
}
