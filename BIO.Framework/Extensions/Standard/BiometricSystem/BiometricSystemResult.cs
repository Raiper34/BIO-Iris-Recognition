using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.BiometricSystem {
    class BiometricSystemResult : Core.BiometricSystem.IBiometricSystemResult {

        Core.BiometricSystem.ResultStatus status = Core.BiometricSystem.ResultStatus.UNKNOWN;

        Core.Comparator.MatchingScore matchingScore;

        Core.Database.BiometricID biometricID = null;

        public BiometricSystemResult(Core.BiometricSystem.ResultStatus status) {
            this.status = status;
        }

        public BiometricSystemResult(Core.BiometricSystem.IDecisionMakerResult decisionMakerResult) {
            this.status = decisionMakerResult.Status;
            this.matchingScore = decisionMakerResult.MatchingScore;
        }

        public BiometricSystemResult(Core.BiometricSystem.IDecisionMakerResult decisionMakerResult, Core.Database.BiometricID biometricID) {
            this.status = decisionMakerResult.Status;
            this.matchingScore = decisionMakerResult.MatchingScore;
            this.biometricID = biometricID;
        }
        
        #region IBiometricSystemResult Members

        public Core.Database.BiometricID getBiometricID() {
            if (this.Status == Core.BiometricSystem.ResultStatus.ACCEPTED) {
                if (biometricID == null) {
                    throw new InvalidOperationException("Unknown biometric ID (internal processing error)"); 
                }
                return this.biometricID;
            } else {
                throw new InvalidOperationException("Unknown biometric ID (input sample was not accepted)"); 
            }
        }

        #endregion

        #region IDecisionMakerResult Members

        public Core.BiometricSystem.ResultStatus Status {
            get { return this.status; }
        }

        public Core.Comparator.MatchingScore MatchingScore {
            get { return this.matchingScore; }
        }

        #endregion
    }
}
