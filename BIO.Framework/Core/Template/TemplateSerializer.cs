using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace BIO.Framework.Core.Template {
    public class TemplateSerializer<TTemplate, TempaltedTFeatureVector>
        where TTemplate : ITemplate<TempaltedTFeatureVector>
        where TempaltedTFeatureVector : FeatureVector.IFeatureVector {

        BinaryFormatter formatter = new BinaryFormatter();

        public void writeToStream(System.IO.Stream s, TTemplate template) {
            formatter.Serialize(s, template);
        }
        public void initFromStream(System.IO.Stream s, out TTemplate template) {
            //s.Position = 0;
            object obj = formatter.Deserialize(s);
            template = (TTemplate)obj;
            //return template;
        }
        
    }
}
