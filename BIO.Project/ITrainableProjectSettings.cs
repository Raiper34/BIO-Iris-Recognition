using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Project {
    public interface ITrainableProjectSettings<TInputRecord> : IStandardProjectSettings< TInputRecord>
        where TInputRecord : Framework.Core.Database.IRecord
       {    
        double ValidatorSamplesRatio { get;  }
        double TrainTestSamplesRatio { get;  }
    }
}
