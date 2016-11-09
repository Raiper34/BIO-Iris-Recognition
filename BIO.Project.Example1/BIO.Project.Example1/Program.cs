using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;


namespace BIO.Project.Example1 {
    /// <summary>
    /// example 1 program
    /// to run please download the face database from 
    /// </summary>
    class Program {
        static void Main(string[] args) {

            //this object has responsibility for creating all needed objects
            ProjectSettings settings = new ProjectSettings();

            var project = new StandardProject<StandardRecord<StandardRecordData>>(settings);

            BIO.Framework.Core.Evaluation.Results.Results results = project.run();

        }

    }
}
