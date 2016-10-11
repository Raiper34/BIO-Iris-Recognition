using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BIO.Framework.Extensions.Standard.Input {
    public interface IImageInputData : BIO.Framework.Core.InputData.IInputData {
        Bitmap Bitmap {
            get;
        }
    }
}
