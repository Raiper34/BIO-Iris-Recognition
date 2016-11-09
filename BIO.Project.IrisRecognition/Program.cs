using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Core.Evaluation.Results;


namespace BIO.Project.IrisRecognition {
    /// <summary>
    /// example 1 program
    /// to run please download the face database from 
    /// </summary>
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("WORKS");
            //this object has responsibility for creating all needed objects
            ProjectSettings settings = new ProjectSettings();

            var project = new StandardProject<StandardRecord<StandardRecordData>>(settings);

            Results results = project.run();

        }

    }
}
