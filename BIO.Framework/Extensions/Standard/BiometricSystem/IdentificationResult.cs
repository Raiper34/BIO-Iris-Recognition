using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.BiometricSystem {
    class IdentificationResult : BiometricSystemResult, Core.BiometricSystem.IIdentificationResult {

        public IdentificationResult(Core.BiometricSystem.ResultStatus status)
            : base(status) {
        }

        public IdentificationResult(Core.BiometricSystem.IDecisionMakerResult decisionMakerResult) 
            : base(decisionMakerResult) {
            
        }

        public IdentificationResult(Core.BiometricSystem.IDecisionMakerResult decisionMakerResult, Core.Database.BiometricID biometricID) 
            : base(decisionMakerResult, biometricID) {
            
        }
        
        
    }
}
