using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Evaluation.Results.Visualization {
    public interface IResultsVisualizer : IProgressReporter {

        void postprocessResults(Results results);
    }
}
