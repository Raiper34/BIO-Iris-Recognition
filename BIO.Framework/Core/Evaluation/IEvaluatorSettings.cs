using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Evaluation {
    public interface IEvaluatorSettings <
        TInputRecord,
        TInputData
    > 
        where TInputRecord : Database.IRecord
        where TInputData : InputData.IInputData {

        /// <summary>
        /// evaluation name
        /// </summary>
        string Name {
            get;
            set;
        }


        /// <summary>
        /// input data creator
        /// </summary>
        /// <returns></returns>
        InputData.IInputDataCreator<TInputRecord, TInputData> getInputDataCreator();
        


    }
}
