using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Serialization;

namespace BIO.Framework.Core.Evaluation.Results {
    [Serializable]
    public class Results : IXmlSerializable {

        /// <summary>
        /// list of all results
        /// </summary>
        private List<Result> results = new List<Result>();

        private Dictionary<string, int> idIndexer = new Dictionary<string, int>();

        private List<string> methods = new List<string>();

        public List<string> Methods {
            get { return methods; }
        }

        public void addResult(Result result) {

            foreach (var m in result.getMethods()) {
                if (!methods.Contains(m)) methods.Add(m);
            }

            Result existing = this.getExistingResult(result);
            if (existing != null) {
                existing.merge(result);
            } else {
                this.results.Add(result);
                this.idIndexer.Add(result.UniqueId, this.results.Count - 1);
            }
        }

        private Result getExistingResult(Result result) {
            if (idIndexer.ContainsKey(result.UniqueId)) {
                return results[idIndexer[result.UniqueId]];
            }
            return null;
        }

        public List<Result> getResultsList() {
            return this.results;
        }

        public void merge(Results other) {
            foreach (Result r in other.getResultsList()) {
                this.addResult(r);
            }
        }


        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema() { return null; }

        public void ReadXml(System.Xml.XmlReader reader) {

            XmlSerializer dataSerializer = new XmlSerializer(this.results.GetType());

            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            if (wasEmpty) {
                throw new InvalidOperationException("Tag evaluation is empty");
            }

            this.results = (List<Result>)dataSerializer.Deserialize(reader);

            reader.ReadEndElement();

        }
        public void WriteXml(System.Xml.XmlWriter writer) {
            XmlSerializer dataSerializer = new XmlSerializer(typeof(List<Result>));
            //writer.WriteStartElement("evaluation");
            dataSerializer.Serialize(writer, this.results);
        }
        #endregion



    }
}
