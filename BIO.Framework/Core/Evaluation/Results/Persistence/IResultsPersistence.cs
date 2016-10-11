using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace BIO.Framework.Core.Evaluation.Results.Persistence {
    public interface IResultsPersistence {
        /// <summary>
        /// load results from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="results"></param>
        void load(Stream stream, out Results results);
        /// <summary>
        /// save results to stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="results"></param>
        void save(Stream stream, Results results);
    }
}
