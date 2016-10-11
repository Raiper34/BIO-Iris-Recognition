using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.InputData {
    public interface IInputDataCreator<TInputRecord, TInputData>
        where TInputRecord : Database.IRecord
        where TInputData : InputData.IInputData {
        /// <summary>
        /// create input data from database record
        /// </summary>
        /// <param name="record">input database record</param>
        /// <returns></returns>
        TInputData createInputData(TInputRecord record);       
    }
}
