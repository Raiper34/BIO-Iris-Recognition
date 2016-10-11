using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.Input {
    public class FileInputData : BIO.Framework.Core.InputData.IInputData {
        /// <summary>
        /// file with input data
        /// </summary>
        private string fileName;
        public string FileName {
            get { return fileName; }
            set {
                fileName = value;
                this.fileNameChanged();
            }
        }

        /// <summary>
        /// construct takes one argument - file with input data
        /// </summary>
        /// <param name="fileName"></param>
        public FileInputData(string fileName) {
            this.fileName = fileName;
        }
        /// <summary>
        /// method called whenever fileName was changed
        /// </summary>
        protected virtual void fileNameChanged() {

        }
    }
}
