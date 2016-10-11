using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.BiometricSystem {
    public class DecisionMakerSettings {

        bool acceptValuesAboveThresh;

        public bool AcceptValuesAboveThresh {
            get { return acceptValuesAboveThresh; }
            set { acceptValuesAboveThresh = value; }
        }

        double thresh;

        public double Thresh {
            get { return thresh; }
            set { thresh = value; }
        }
    }
}
