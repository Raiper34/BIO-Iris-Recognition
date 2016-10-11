using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.BiometricSystem {

    public enum ResultStatus {
        UNKNOWN, ACCEPTED, REJECTED
    }

    public interface IDecisionMakerResult {
        

        ResultStatus Status {
            get;
        }

        Comparator.MatchingScore MatchingScore {
            get;
        }
    }
}
