using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BIO.Framework.Core.Evaluation.Results.Persistence {
    public class BinaryResultsSerializer : IResultsSerializer {

        #region IResultsSerializer Members

        BinaryFormatter formatter = new BinaryFormatter();

        public void writeToStream(Stream toStream, Results results) {
            formatter.Serialize(toStream, results);
        }

        public void initFromStream(Stream fromStream, out Results results) {
            object obj = formatter.Deserialize(fromStream);
            results = (Results)obj;
        }

        #endregion
    }
}
