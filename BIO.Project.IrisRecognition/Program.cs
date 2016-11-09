using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Core.Evaluation.Results;


namespace BIO.Project.IrisRecognition {
    

    class Program {
        static void Main(string[] args) {

            Console.WriteLine("<Iris Recognition>");
            Console.WriteLine("Filip Gulan and Marek Marusic");

            ProjectSettings settings = new ProjectSettings();
            var project = new StandardProject<StandardRecord<StandardRecordData>>(settings);
            Results results = project.run();

        }

    }
}
