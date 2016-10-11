using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.BiometricSystem {
    public interface IDecisionMaker {
        /// <summary>
        /// make decision from matching score
        /// </summary>
        /// <param name="matchongScore"></param>
        /// <returns></returns>
        IDecisionMakerResult makeDecision(Comparator.MatchingScore matchingScore);
    }
}
