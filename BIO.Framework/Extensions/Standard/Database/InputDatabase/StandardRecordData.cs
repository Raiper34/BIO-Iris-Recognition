using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.Database.InputDatabase {
    public class StandardRecordData : IStandardRecordData {
        /// <summary>
        /// stored data are just simple string
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// anotations are also string
        /// </summary>
        public string Anotations { get; set; }

        public StandardRecordData (string data = "", string anotations = ""){
            this.Data = data;
            this.Anotations = anotations;
        }
    }
}
