using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Project {
    public class TrainableProjectSettings : StandardProjectSettings {
        
        public double ValidatorSamplesRation { get; set; }
        public double TrainTestSamplesRation { get; set; }
    }
}
