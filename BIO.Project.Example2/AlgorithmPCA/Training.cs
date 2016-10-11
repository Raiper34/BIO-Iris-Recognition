using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Extensions.Training;

namespace BIO.Project.Example2.PCA {
    class Training : ITrainable <StandardRecord<StandardRecordData>> {

        FaceEvaluationSettings settings;

        public Training(FaceEvaluationSettings settings) {
            this.settings = settings;
        }

        #region ITrainable<StandardRecord<StandardRecordData>> Members

        public void train(Framework.Core.Database.IRecordEnumerable<StandardRecord<StandardRecordData>> trainingDatabase) {
            int total =  trainingDatabase.getRecords().Count();
            int act = 0;
            List <EmguGrayImageInputData> data = new List<EmguGrayImageInputData>();
            foreach (StandardRecord<StandardRecordData> r in trainingDatabase.getRecords()) {
                EmguGrayImageInputData input = settings.getInputDataCreator().createInputData(r);
                data.Add(input);
                this.onProgressChanged(new Framework.Core.ProgressReport("Statistical model training", ++act, total));
            }
            this.settings.PcaExtractor.train(data);
        }

        public double test(Framework.Core.Database.IRecordEnumerable<StandardRecord<StandardRecordData>> testingDatabase) {
            //TODO
            return 0.0;
        }

        #endregion

        #region IProgressReporter Members

        public event Framework.Core.ProgressChangedEventHandler ProgressChangedEvent;

        public void onProgressChanged(Framework.Core.ProgressReport e) {
            if (ProgressChangedEvent != null) {
                ProgressChangedEvent(e);
            }
        }

        #endregion
    }
}
