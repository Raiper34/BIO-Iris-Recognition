using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Extensions.Standard.BiometricSystem {
    public class DecisionMaker : Core.BiometricSystem.IDecisionMaker {

        DecisionMakerSettings settings = null;

        public DecisionMakerSettings Settings {
            get { return settings; }
            set { settings = value; }
        }

        public DecisionMaker() {
            
        }
        public DecisionMaker(DecisionMakerSettings settings) {
            this.settings = settings;
        }
        
        #region IDecisionMaker Members

        public Core.BiometricSystem.IDecisionMakerResult makeDecision(Core.Comparator.MatchingScore matchingScore) {
            if (settings == null || !matchingScore.IsValid) {
                return new DecisionMakerResult(matchingScore);
            } else {
                if (settings.AcceptValuesAboveThresh) {
                    if (matchingScore.Score > settings.Thresh) {
                        return new DecisionMakerResult(matchingScore, Core.BiometricSystem.ResultStatus.ACCEPTED);
                    } else {
                        return new DecisionMakerResult(matchingScore, Core.BiometricSystem.ResultStatus.REJECTED);
                    }
                } else {
                    if (matchingScore.Score > settings.Thresh) {
                        return new DecisionMakerResult(matchingScore, Core.BiometricSystem.ResultStatus.REJECTED);
                    } else {
                        return new DecisionMakerResult(matchingScore, Core.BiometricSystem.ResultStatus.ACCEPTED);
                    }
                } 
            }
        }

        #endregion
    }
}
