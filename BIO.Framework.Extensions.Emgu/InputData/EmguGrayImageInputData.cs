using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emgu.CV.CvEnum;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace BIO.Framework.Extensions.Emgu.InputData {
    public class EmguGrayImageInputData : Standard.Input.FileInputData, Standard.Input.IImageInputData {
        private Image<Gray, Byte> image;
        public Image<Gray, Byte> Image {
            get { return image;  }
        }
        /// <summary>
        /// construct take path to file
        /// </summary>
        /// <param name="fileName">path to image file</param>
        public EmguGrayImageInputData(string fileName)
            : base(fileName) {
            this.fileNameChanged();
        }
        /// <summary>
        /// whenever fileName is changed then load new image
        /// </summary>
        protected override void fileNameChanged() {
            base.fileNameChanged();
            image = new Image<Gray, Byte>(this.FileName);
        }

        #region IImageInputData Members

        public System.Drawing.Bitmap Bitmap {
            get { return image.ToBitmap(); }
        }

        #endregion
    }
}
