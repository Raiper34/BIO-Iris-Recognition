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
    public class CompressedResultsPersistence<ResultsSerializer> : ResultsPersistence<ResultsSerializer>
        where ResultsSerializer : IResultsSerializer, new() {

        public override void load(Stream stream, out Results results) {
            GZipStream gzStream = new GZipStream(stream, CompressionMode.Decompress);
            base.load(gzStream, out results);
            gzStream.Close();
        }

        public override void save(Stream stream, Results results) {
            GZipStream gzStream = new GZipStream(stream, CompressionMode.Compress);
            base.save(gzStream, results);
            gzStream.Close();
        }

    }
}
