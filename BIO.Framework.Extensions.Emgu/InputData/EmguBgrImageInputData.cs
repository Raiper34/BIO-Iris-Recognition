using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emgu.CV.CvEnum;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace BIO.Framework.Extensions.Emgu.InputData {
    public class EmguBgrImageInputData : Standard.Input.FileInputData, Standard.Input.IImageInputData {
        private Image<Bgr, Byte> image;
        public Image<Bgr, Byte> Image {
            get { return image;  }
        }
        /// <summary>
        /// construct take path to file
        /// </summary>
        /// <param name="fileName">path to image file</param>
        public EmguBgrImageInputData(string fileName)
            : base(fileName) {
            this.fileNameChanged();
        }
        /// <summary>
        /// whenever fileName is changed then load new image
        /// </summary>
        protected override void fileNameChanged() {
            base.fileNameChanged();
            image = new Image<Bgr, Byte>(this.FileName);
        }

        #region IImageInputData Members

        public System.Drawing.Bitmap Bitmap {
            get { return image.ToBitmap(); }
        }

        #endregion
    }
}
