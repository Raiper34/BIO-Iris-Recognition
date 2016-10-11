using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BIO.Framework.Core.Database {
    public interface IRecord : IXmlSerializable {
        string SampleID { get; set; }
        /// <summary>
        /// biometric ID
        /// </summary>
        BiometricID BiometricID { get; set; }
    }
}
