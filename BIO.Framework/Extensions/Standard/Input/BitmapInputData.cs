using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace BIO.Framework.Extensions.Standard.Input {
    public class BitmapInputData : FileInputData, IImageInputData {
        private Bitmap image;
        public Bitmap Image {
            get { return image; }
        }
        /// <summary>
        /// construct take path to file
        /// </summary>
        /// <param name="fileName">path to image file</param>
        public BitmapInputData(string fileName)
            : base(fileName) {
            this.fileNameChanged();
        }
        /// <summary>
        /// whenever fileName is changed then load new image
        /// </summary>
        protected override void fileNameChanged() {
            base.fileNameChanged();
            image = (Bitmap)Bitmap.FromFile(this.FileName);
        }

        #region IImageInputData Members

        public Bitmap Bitmap {
            get { return Image; }
        }

        #endregion
    }
}
