using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Project {
    public abstract class ProjectSettings<TInputRecord, TInputData> : IProjectSettings<TInputRecord> 
        where TInputRecord : Framework.Core.Database.IRecord
        where TInputData : Framework.Core.InputData.IInputData {

        /// <summary>
        /// get biometric database evaluator
        /// </summary>
        /// <returns></returns>
        protected abstract BIO.Framework.Core.Evaluation.Block.IBlockEvaluatorSettings<TInputRecord, TInputData> getEvaluatorSettings();

        /// <summary>
        /// get database creator
        /// </summary>
        /// <returns></returns>
        public abstract BIO.Framework.Core.Database.IDatabaseCreator<TInputRecord> getDatabaseCreator();


        #region IProjectSettings<TInputRecord> Members

       

        #endregion

        #region IProjectSettings<TInputRecord> Members

        Framework.Core.Evaluation.Block.IBlockEvaluator<TInputRecord> blockEvaluator = null;

        public Framework.Core.Evaluation.Block.IBlockEvaluator<TInputRecord> getBlockEvaluator() {
            if (blockEvaluator == null) {
                blockEvaluator = new Framework.Extensions.Standard.Evaluation.Block.BlockEvaluator<TInputRecord, TInputData>(this.getEvaluatorSettings());
            }
            return blockEvaluator;
        }

        #endregion
    }
}
