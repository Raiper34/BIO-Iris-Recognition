using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core {

    

    public class ProgressReport {
        public int Progress { get; set; }

        public string Message {get; set;}

        public ProgressReport(string message) {
            this.Message = message;
            this.Progress = 0;
        }
        public ProgressReport(string message, int percent) {
            this.Message = message;
            this.Progress = percent;
        }
        public ProgressReport(string message, int item, int total) {
            this.Message = message + " (" + item + "/" + total + ")";
            this.Progress = item * 100 / total;
        }
    }
}
