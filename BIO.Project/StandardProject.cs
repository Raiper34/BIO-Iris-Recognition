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
    public class StandardProject <TInputRecord>  where TInputRecord : BIO.Framework.Core.Database.IRecord {

        //private IDatabaseCreator<TInputRecord> databaseCreator = null;
        
        //IDatabaseEvaluator<TInputRecord> evaluator = null;

        IStandardProjectSettings<TInputRecord> settings = null;

        public StandardProject(IStandardProjectSettings<TInputRecord> settings) {
            this.settings = settings;
        }

        protected void printDbOverview(string text, BIO.Framework.Core.Database.IRecordEnumerable dbIterator) {
            //debugging console output
            Console.WriteLine(text);
            Console.WriteLine("--------------");
            BIO.Framework.Utils.Console.Database.DatabaseOverview.showGlobalOverview(dbIterator);
            Console.WriteLine();
        }

        protected virtual BIO.Framework.Core.Evaluation.Results.Results internalRun(Database<TInputRecord> inputDatabase){
        
            //create database subsets
            TemplateAndEvaluationDatabaseSubsetCreator<TInputRecord> templateTestSubset = 
                new Framework.Extensions.Standard.Database.Subsets.TemplateAndEvaluationDatabaseSubsetCreator<TInputRecord>(
                    inputDatabase, 
                    settings.TemplateSamples
                );

            //template subset
            Database<TInputRecord> templateDbSubset = templateTestSubset.getDatabaseSubset(TemplateAndEvaluationDatabaseSubsetCreator<TInputRecord>.TemplateSubset);
            
            //debugging console output
            this.printDbOverview("Templates database subset", templateDbSubset.getCollections());
           

            //database for templates
            BIO.Framework.Core.Database.TemplateDatabase.TemplateDatabase templateDatabase = new BIO.Framework.Core.Database.TemplateDatabase.TemplateDatabase();
            //progress report event
            settings.getBlockEvaluator().ProgressChangedEvent +=new Framework.Core.ProgressChangedEventHandler(evaluator_ProgressChangedEvent);
            //template extraction
            Console.WriteLine("Template extraction");
            settings.getBlockEvaluator().extractTemplates(
                templateDbSubset.getCollections(),
                templateDatabase
            );

            Console.WriteLine();
            Console.WriteLine("Template extraction done");

            Console.WriteLine();
            //test subset
            Database<TInputRecord> testDbSubset = templateTestSubset.getDatabaseSubset(TemplateAndEvaluationDatabaseSubsetCreator<TInputRecord>.EvaluationSubset);

            //debugging console output
            this.printDbOverview("Evaluation database subset", testDbSubset.getCollections());
           

            //templates are ready - now evaluate db
            Console.WriteLine("Algorithm evaluation");
            //where to store results
            BIO.Framework.Core.Evaluation.Results.Results results = new Framework.Core.Evaluation.Results.Results();
            //own evaluation
            settings.getBlockEvaluator().evaluateRecords(
                testDbSubset.getCollections(),
                templateDatabase,
                results);

            Console.WriteLine();
            Console.WriteLine("Algorithm evaluation done");

            //save results to file (xml|binary and plain|zipped)
            string fileName = "results.zip";
            ResultsPersistence persistence = new ResultsPersistence(new CompressedResultsPersistence<XmlResultsSerializer>());
            persistence.saveResults(results, fileName);
            Console.WriteLine("Results saved to " + fileName);

            //postprocess results
            List<IResultsVisualizer> postprocessors = new List<IResultsVisualizer>();
            //statistics
            postprocessors.Add(new BIO.Framework.Extensions.Standard.Evaluation.Results.Visualization.StatisticsSummaryResultsPostprocessor("summary.txt"));
            //genuine x impostor graph
            postprocessors.Add(new BIO.Framework.Extensions.ZedGraph.Evaluation.Results.Visualization.ZedGraphResultsGraphVisualizer("GenuineImpostor.png"));

            foreach (IResultsVisualizer pp in postprocessors) {
                pp.ProgressChangedEvent += new Framework.Core.ProgressChangedEventHandler(evaluator_ProgressChangedEvent);
                pp.postprocessResults(results);
            }

            Console.WriteLine();

            return results;
        }

        public BIO.Framework.Core.Evaluation.Results.Results run() {

            Console.WriteLine("BIO.Framework project:");
            Console.WriteLine();

            Console.WriteLine();

            Database<TInputRecord> inputDatabase = settings.getDatabaseCreator().createDatabase();

            //debugging console output
            this.printDbOverview("Input Database", inputDatabase.getCollections());

            if (inputDatabase.getCollections().getRecords().Count() == 0) {
                throw new InvalidOperationException("Database is empty - please check the database creator");
            }

            BIO.Framework.Core.Evaluation.Results.Results results = this.internalRun(inputDatabase);

            //show results in Windoows GUI form
            BIO.Framework.Utils.UI.Evaluation.Results.ResultsForm rf = new Framework.Utils.UI.Evaluation.Results.ResultsForm(results/*, 
                biometricSystem.getInputDatabaseCreatorInstance().createDatabase()*/);
            System.Windows.Forms.Application.Run(rf);

            return results;
        }

        void evaluator_ProgressChangedEvent(Framework.Core.ProgressReport progress) {
            Console.Write("\r{1}% {0}", progress.Message, progress.Progress); 
        }
    }
}
