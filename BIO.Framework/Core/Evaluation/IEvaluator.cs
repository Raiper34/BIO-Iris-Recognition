using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Evaluation {
    //TODO
    public interface IEvaluators<TInputRecord> where TInputRecord : Database.IRecord {
        /// <summary>
        /// get class implementing complete evaluator interface
        /// </summary>
        /// <returns></returns>
        //IBlockEvaluator<TInputRecord> getDatabaseEvaluator();

    }
}
