using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace BIO.Framework.Core.Evaluation.Results.Persistence {
    public interface IResultsSerializer {
        /// <summary>
        /// serialize results to stream
        /// </summary>
        /// <param name="toStream"></param>
        /// <param name="results"></param>
        void writeToStream(Stream toStream, Results results);
        /// <summary>
        /// deserialize results from stream
        /// </summary>
        /// <param name="fromStream"></param>
        /// <param name="results"></param>
        void initFromStream(Stream fromStream, out Results results);
    }
}
