using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace BIO.Framework.Core.Evaluation.Results.Persistence {
    public class XmlResultsSerializer : IResultsSerializer {

        #region IResultsSerializer Members

        
        public void writeToStream(Stream toStream, Results results) {
            XmlSerializer xs = new XmlSerializer(typeof(Results));
            xs.Serialize(toStream, results);
        }

        public void initFromStream(Stream fromStream, out Results results) {
            XmlSerializer xs = new XmlSerializer(typeof(Results));
            results = (Results)xs.Deserialize(fromStream);

        }

        #endregion
    }
}
