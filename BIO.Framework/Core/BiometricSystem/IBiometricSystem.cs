using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.BiometricSystem {
    public interface IBiometricSystem <TInputData> : IProgressReporter where TInputData : InputData.IInputData {
        /// <summary>
        /// get settings - what are the components
        /// </summary>
        /// <returns></returns>
        IBiometricSystemSettings<TInputData> getBiometricSystemSettings();

        /// <summary>
        /// get template database
        /// </summary>
        /// <returns></returns>
        Database.TemplateDatabase.TemplateDatabase getTemplateDatabase();

        /// <summary>
        /// register user to database
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="biometricID"></param>
        void register(TInputData inputData, Database.BiometricID biometricID);
        /// <summary>
        /// identify user
        /// </summary>
        /// <param name="inputData"></param>
        IIdentificationResult identify(TInputData inputData);
        /// <summary>
        /// verify user
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="biometricID"></param>
        /// <returns></returns>
        IVerificationResult verify(TInputData inputData, Database.BiometricID biometricID);
    }
}
