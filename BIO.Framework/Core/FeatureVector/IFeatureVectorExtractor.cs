using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.FeatureVector {
    public interface IFeatureVectorExtractor<TInputData, TFeatureVector>
        where TInputData : InputData.IInputData
        where TFeatureVector : FeatureVector.IFeatureVector {
       /// <summary>
       /// extract feature vector from input data
       /// </summary>
       /// <param name="input">input data</param>
       /// <returns></returns>
       TFeatureVector extractFeatureVector(TInputData input);       
    }
}
