using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Serialization;
using BIO.Framework.Core.Comparator;

namespace BIO.Framework.Core.Evaluation.Results {
    [Serializable]
    public class Result : IXmlSerializable {
        /// <summary>
        /// template record
        /// </summary>
        private Database.Record templateRecord;

        public Database.Record TemplateRecord {
            get { return templateRecord; }
        }
        /// <summary>
        /// tested record
        /// </summary>
        private Database.Record testedRecord;

        public Database.Record TestedRecord {
            get { return testedRecord; }
        }
        /// <summary>
        /// asociative array - method, matching score
        /// </summary>
        private BIO.Framework.Tools.SerializableDictionary<string, MatchingScore> matchingScores = new BIO.Framework.Tools.SerializableDictionary<string, MatchingScore>();

        public BIO.Framework.Tools.SerializableDictionary<string, MatchingScore> MatchingScores {
            get { return matchingScores; }
        }

        /// <summary>
        /// construct
        /// </summary>
        /// <param name="r">testing record</param>
        public Result(Database.Record templateR, Database.Record testedR) {
            this.templateRecord = templateR;
            this.testedRecord = testedR;
        }
        public MatchingScore getMatchingScore(string method) {
            if (!matchingScores.ContainsKey(method)) return MatchingScore.invalid();
            return matchingScores[method];
        }
        public void setMatchingScore(string method, MatchingScore score) {
            if (!matchingScores.ContainsKey(method)) {
                matchingScores.Add(method, score);
            } else {
                matchingScores[method] = score;
            }
        }

        public IEnumerable<string> getMethods() {
            return matchingScores.Keys;
        }
        

        public bool isGenuine() {
            //Console.Write(this.TemplateRecord.BiometricID.ToString() + this.TestedRecord.BiometricID.ToString());
            return this.TemplateRecord.BiometricID == this.TestedRecord.BiometricID;
        }

        internal void merge(Result result) {
            foreach (KeyValuePair<string, MatchingScore> val in result.matchingScores) {
                this.setMatchingScore(val.Key, val.Value);
            }
        }

        public string UniqueId {
            get {
                return this.TemplateRecord.SampleID.ToString() + "_" + this.TestedRecord.SampleID.ToString(); 
            }
        }

        #region IXmlSerializable Members

        public Result() { }

        public System.Xml.Schema.XmlSchema GetSchema() {
            return null;
        }

        public void ReadXml(XmlReader reader) {
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            if (wasEmpty) {
                throw new InvalidOperationException("Tag result is empty");
            }

            reader.ReadStartElement("templateRecord");
            XmlSerializer templateRecordSerializer = new XmlSerializer(this.templateRecord.GetType());
            this.templateRecord = (Database.Record)templateRecordSerializer.Deserialize(reader);
            reader.ReadEndElement();

            reader.ReadStartElement("testedRecord");
            XmlSerializer testedRecordSerializer = new XmlSerializer(this.testedRecord.GetType());
            this.testedRecord = (Database.Record)testedRecordSerializer.Deserialize(reader);
            reader.ReadEndElement();

            XmlSerializer resultSerializer = new XmlSerializer(matchingScores.GetType());
            this.matchingScores = (BIO.Framework.Tools.SerializableDictionary<string, MatchingScore>)resultSerializer.Deserialize(reader);

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer) {

            writer.WriteStartElement("templateRecord");
            XmlSerializer templateRecordSerializer = new XmlSerializer(this.templateRecord.GetType());
            templateRecordSerializer.Serialize(writer, this.templateRecord);
            writer.WriteEndElement();

            writer.WriteStartElement("testedRecord");
            XmlSerializer testingRecordSerializer = new XmlSerializer(this.testedRecord.GetType());
            testingRecordSerializer.Serialize(writer, this.testedRecord);
            writer.WriteEndElement();

            XmlSerializer resultSerializer = new XmlSerializer(this.matchingScores.GetType());
            resultSerializer.Serialize(writer, this.matchingScores);

        }

        #endregion
    }
}
