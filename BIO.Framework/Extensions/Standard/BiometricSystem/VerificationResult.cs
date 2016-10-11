using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.BiometricSystem {
    class VerificationResult : BiometricSystemResult, Core.BiometricSystem.IVerificationResult {

        public VerificationResult(Core.BiometricSystem.ResultStatus status)
            : base(status) {
        }

        public VerificationResult(Core.BiometricSystem.IDecisionMakerResult decisionMakerResult) 
            : base(decisionMakerResult) {
        }

        public VerificationResult(Core.BiometricSystem.IDecisionMakerResult decisionMakerResult, Core.Database.BiometricID biometricID) 
            : base(decisionMakerResult, biometricID) {
        }
        
    }
}
