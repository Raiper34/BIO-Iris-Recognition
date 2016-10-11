using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BIO.Framework.Core.Database {
    [Serializable]
    public class Record : IRecord, IXmlSerializable {
        /// <summary>
        /// unique ID within database
        /// </summary>
        public string SampleID { get; set; }

        
        /// <summary>
        /// biometric ID
        /// </summary>
        public BiometricID BiometricID { get; set; }
        /// <summary>
        /// empty constructor
        /// </summary>
        public Record() {
            SampleID = "";
        }
        /*
        public Record(BiometricID bioID) {
            BiometricID = bioID;
            UniqueRecordID = "";
        }*/

        public Record(BiometricID bioID, string sampleID) {
            BiometricID = bioID;
            SampleID = sampleID;
        }

      

        public Record(IRecord fromRecord) {
            this.BiometricID = fromRecord.BiometricID;
            this.SampleID = fromRecord.SampleID;
        }

        
        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema() {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader) {
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            reader.ReadStartElement("sampleID");
            this.SampleID = reader.ReadString();
            reader.ReadEndElement();

            reader.ReadStartElement("personID");
            this.BiometricID.PersonID = reader.ReadString();
            reader.ReadEndElement();


            reader.ReadStartElement("biometric");
            this.BiometricID.Biometric = reader.ReadString();
            reader.ReadEndElement();

            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer) {
            writer.WriteElementString("sampleID", this.SampleID);
            writer.WriteElementString("personID", this.BiometricID.PersonID);
            writer.WriteElementString("biometric", this.BiometricID.Biometric);
        }

        #endregion

        #region Operators

        public static bool operator ==(Record a, Record b) {
            return a.BiometricID == b.BiometricID && a.SampleID == b.SampleID;
        }
        public static bool operator !=(Record a, Record b) {
            return !(a == b);
        }
        public override bool Equals(object obj) {
            return base.Equals(obj);
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        #endregion

    }
}
