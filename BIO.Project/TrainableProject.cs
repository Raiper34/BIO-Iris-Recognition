using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Evaluation;
using BIO.Framework.Core.Database;
using BIO.Framework.Extensions.Standard.Database.Subsets;
using BIO.Framework.Core.Evaluation.Results.Persistence;
using BIO.Framework.Core.Evaluation.Results.Visualization;

namespace BIO.Project {
    public class TrainableProject <TInputRecord> 
        : StandardProject<TInputRecord> 
        where TInputRecord : BIO.Framework.Core.Database.IRecord {

        ITrainableProjectSettings<TInputRecord> settings;

        BIO.Framework.Extensions.Training.ITrainable<TInputRecord> trainableObject;


        public TrainableProject(BIO.Framework.Extensions.Training.ITrainable<TInputRecord> trainableObject, ITrainableProjectSettings<TInputRecord> settings) 
            : base(settings) {
                this.settings = settings;
                this.trainableObject = trainableObject;
        }


        protected override Framework.Core.Evaluation.Results.Results internalRun(Database<TInputRecord> inputDatabase) {
            
            //create database subsets
            TrainTestAndValidationDatabaseSubsetCreator<TInputRecord> ttvSubset =
                new Framework.Extensions.Standard.Database.Subsets.TrainTestAndValidationDatabaseSubsetCreator<TInputRecord>(
                    inputDatabase,
                    settings.ValidatorSamplesRatio,
                    settings.TrainTestSamplesRatio
                );
            
            //template subset
            Database<TInputRecord> trainDbSubset = ttvSubset.getDatabaseSubset(TrainTestAndValidationDatabaseSubsetCreator<TInputRecord>.TrainSubset);
            Database<TInputRecord> testDbSubset = ttvSubset.getDatabaseSubset(TrainTestAndValidationDatabaseSubsetCreator<TInputRecord>.TestSubset);
            Database<TInputRecord> validationDbSubset = ttvSubset.getDatabaseSubset(TrainTestAndValidationDatabaseSubsetCreator<TInputRecord>.ValidationSubset);
            
            this.trainableObject.ProgressChangedEvent +=new Framework.Core.ProgressChangedEventHandler(trainableObject_ProgressChangedEvent);

            Console.WriteLine("Training");

            this.trainableObject.train(trainDbSubset.getCollections());

            Console.WriteLine();
            Console.WriteLine("Training done");
            Console.WriteLine("-------------");
            Console.WriteLine("Testing");

            double error = this.trainableObject.test(testDbSubset.getCollections());
            Console.WriteLine();
            Console.WriteLine("Testing error is " + error);
            
            Console.WriteLine("-------------");

            Console.WriteLine("Validation start");

            Framework.Core.Evaluation.Results.Results r =  base.internalRun(validationDbSubset);
            //Framework.Core.Evaluation.Results.Results r = base.internalRun(inputDatabase);
            
            
            Console.WriteLine("Validation done");

            return r;
        }

        void trainableObject_ProgressChangedEvent(Framework.Core.ProgressReport progress) {
            Console.Write("\r{1}% {0}", progress.Message, progress.Progress);
        }

       
    }
}
