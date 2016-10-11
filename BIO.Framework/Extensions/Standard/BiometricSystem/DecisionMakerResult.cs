using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.BiometricSystem {
    class DecisionMakerResult : Core.BiometricSystem.IDecisionMakerResult {

        Core.BiometricSystem.ResultStatus status = Core.BiometricSystem.ResultStatus.UNKNOWN;
        
        Core.Comparator.MatchingScore matchingScore;

        
        public DecisionMakerResult(Core.Comparator.MatchingScore matchingScore ) { 
            this.matchingScore = matchingScore;
        }
        public DecisionMakerResult(Core.Comparator.MatchingScore matchingScore, Core.BiometricSystem.ResultStatus status) {
            this.matchingScore = matchingScore;
            this.status = status;
        }


        #region IDecisionMakerResult Members

        public Core.BiometricSystem.ResultStatus Status {
            get { return status; }
        }

        public Core.Comparator.MatchingScore MatchingScore {
            get { return matchingScore; }
        }

        #endregion
    }
}
