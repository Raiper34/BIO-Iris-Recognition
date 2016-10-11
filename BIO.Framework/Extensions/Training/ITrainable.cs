using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core;

namespace BIO.Framework.Extensions.Training {
    public interface ITrainable<TInputRecord> : IProgressReporter where TInputRecord : BIO.Framework.Core.Database.IRecord {
        /// <summary>
        /// train some model
        /// </summary>
        /// <param name="trainingDatabase"></param>
        void train(BIO.Framework.Core.Database.IRecordEnumerable<TInputRecord> trainingDatabase);
        /// <summary>
        /// test if it is well trained 
        /// </summary>
        /// <param name="testingDatabase"></param>
        /// <returns>error ratio - how many errors are within testing set</returns>
        double test(BIO.Framework.Core.Database.IRecordEnumerable<TInputRecord> testingDatabase);
    }
}
