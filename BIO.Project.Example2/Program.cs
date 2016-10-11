using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Core.Evaluation.Results;
using BIO.Framework.Core.Evaluation.Results.Visualization;

using BIO.Framework.Core.Evaluation.Results.Persistence;
using BIO.Framework.Core.Database;
using BIO.Framework.Extensions.Standard.Database.Subsets;


namespace BIO.Project.Example2 {
    class Program {
        static void Main(string[] args) {

            
            //PCA evaluation

            //this object has responsibility for creating all needed objects
            ProjectSettings settings = new ProjectSettings();

            PCA.Training pcaTraining = new PCA.Training(settings.BlockEvaluationSettings);

            TrainableProject<StandardRecord<StandardRecordData>> pcaProject = new TrainableProject<StandardRecord<StandardRecordData>>(
                pcaTraining,
                settings
            );

            BIO.Framework.Core.Evaluation.Results.Results results = pcaProject.run();
        }

    }
}
