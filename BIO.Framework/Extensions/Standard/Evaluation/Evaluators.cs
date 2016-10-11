using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Evaluation;
using BIO.Framework.Core.Database;
using BIO.Framework.Core.InputData;

namespace BIO.Framework.Extensions.Standard.Evaluation {
    public class Evaluators<
            TInputRecord,
            TInputData
        > : IEvaluators <TInputRecord>
        where TInputRecord : IRecord
        where TInputData : IInputData
         {
        /*
        //private IBiometricSystemSettings<TInputRecord, TInputData> biometricAlgorithmBlockSettings = null;
        private IEvaluatorSettings<TInputRecord, TInputData> evaluationSettings = null;


        public Evaluators(
            IEvaluatorSettings<TInputRecord, TInputData> evaluationSettings) {
                //this.biometricAlgorithmBlockSettings = biometricAlgorithmBlockSettings;
                this.evaluationSettings = evaluationSettings;
        }

        private DatabaseEvaluator<
           TInputRecord,
           TInputData
        > completeEvaluatorInstance = null;

        public DatabaseEvaluator<
            TInputRecord,
            TInputData
        > getDbEvaluator() {

                if (this.completeEvaluatorInstance == null) {
                    this.completeEvaluatorInstance = new DatabaseEvaluator<TInputRecord, TInputData>
                    (
                        this.evaluationSettings
                    );
                }

                return this.completeEvaluatorInstance;
        }


        #region IEvaluators<TInputRecord> Members

        public IBlockEvaluator<TInputRecord> getDatabaseEvaluator() {
            return this.getDbEvaluator();
        }

        #endregion
         */
    }
}
