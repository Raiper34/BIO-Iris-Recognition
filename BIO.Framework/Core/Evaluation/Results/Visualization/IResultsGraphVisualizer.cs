using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Evaluation.Results.Visualization {
    public interface IResultsGraphVisualizer <GraphType> : IResultsVisualizer {
        /// <summary>
        /// save graph to file
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="fileName"></param>
        void saveGraphToFile(GraphType graph, string fileName);
        
        /// <summary>
        /// create genuine and impostor graph
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        GraphType createGenuineImpostorGraph(Results results);

        /// <summary>
        /// create ROC curve graph
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        GraphType createROCGraph(Results results);

        /// <summary>
        /// create DET curve graph
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        GraphType createDETGraph(Results results);
    }
}
