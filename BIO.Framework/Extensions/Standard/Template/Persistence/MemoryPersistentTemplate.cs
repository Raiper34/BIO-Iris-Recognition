using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Template.Persistence;

namespace BIO.Framework.Extensions.Standard.Template.Persistence {
    public class MemoryPersistentTemplate : IPersistentTemplate {
        System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();

        #region IPersistentTemplate Members

        public System.IO.Stream getStream() {
            memoryStream.Position = 0;
            return memoryStream;
        }

        #endregion

        #region IPersistentTemplate Members

        private string name;

        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        #endregion

        Dictionary<string, IPersistentTemplate> subtemplates = new Dictionary<string, IPersistentTemplate>();

        #region IPersistentTemplate Members


        public IPersistentTemplate getSubtemplate(string name) {
            return subtemplates[name];
        }

        PersistentTemplateCreator<MemoryPersistentTemplate> creator = new PersistentTemplateCreator<MemoryPersistentTemplate>();

        public IPersistentTemplate createSubtemplate(string name) {
            IPersistentTemplate newtempalte =  creator.createPersistentTemplate(name, this);
            subtemplates.Add(name, newtempalte);
            return newtempalte;
        }

        #endregion
    }
}
