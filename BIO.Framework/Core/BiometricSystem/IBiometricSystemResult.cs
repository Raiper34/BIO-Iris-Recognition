using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.BiometricSystem {
    public interface IBiometricSystemResult : IDecisionMakerResult {
        /// <summary>
        /// get user biometric ID
        /// throws exception if status is not ACCEPTED
        /// </summary>
        /// <returns></returns>
        Database.BiometricID getBiometricID();

        

    }
}
