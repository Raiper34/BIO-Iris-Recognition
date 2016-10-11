using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.Xml;
using System.Globalization;
using System.IO;
using System.IO.Compression;

namespace BIO.Framework.Core.Evaluation.Results.Persistence {
    public class ResultsPersistence <ResultsSerializer> : IResultsPersistence where ResultsSerializer : IResultsSerializer, new() {

        ResultsSerializer serializer = new ResultsSerializer();

        public virtual void load(Stream stream, out Results results) {
            serializer.initFromStream(stream, out results);
        }

        public virtual void save(Stream stream, Results results) {
            serializer.writeToStream(stream, results);
        }


    }

    public class ResultsPersistence {

        IResultsPersistence resultPersistenceObject;

        public ResultsPersistence(IResultsPersistence resultPersistenceObject) {
            this.resultPersistenceObject = resultPersistenceObject;
        }

        public Results loadResults(string path) {
            try {
                FileStream fileStream = File.OpenRead(path);
                Results r;
                resultPersistenceObject.load(fileStream, out r);
                fileStream.Close();
                return r;
            } catch (Exception e) {
                throw new InvalidOperationException("Results load error", e);
            }
        }

        public void saveResults(Results res, string fileName) {
            try {
                FileStream fileStream = File.Create(fileName);
                resultPersistenceObject.save(fileStream, res);
                fileStream.Close();
            } catch (Exception e) {
                throw new InvalidOperationException("Results save error", e);
            }
        }
    }
}
