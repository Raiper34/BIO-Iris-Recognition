using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Project {
    public interface IProjectSettings <TInputRecord>  
        where TInputRecord : Framework.Core.Database.IRecord
         {

        /// <summary>
        /// get biometric database evaluator
        /// </summary>
        /// <returns></returns>
        BIO.Framework.Core.Evaluation.Block.IBlockEvaluator<TInputRecord> getBlockEvaluator();

        /// <summary>
        /// get database creator
        /// </summary>
        /// <returns></returns>
        BIO.Framework.Core.Database.IDatabaseCreator<TInputRecord> getDatabaseCreator();
    }
}
