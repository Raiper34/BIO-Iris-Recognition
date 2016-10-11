using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Template.Persistence;

namespace BIO.Framework.Extensions.Standard.Template.Persistence {
    public class PersistentTemplateCreator<TPersistentTemplate> : IPersistentTemplateCreator 
        where TPersistentTemplate : IPersistentTemplate, new() {
        
        #region IPersistentTemplateCreator<TPersistentTemplate> Members

        public IPersistentTemplate createPersistentTemplate(string name, Framework.Core.Database.BiometricID recordId) {
            TPersistentTemplate t = new TPersistentTemplate();
            t.Name = name;
            return t;
        }

        public IPersistentTemplate createPersistentTemplate(string name, IPersistentTemplate parent) {
            TPersistentTemplate t = new TPersistentTemplate();
            t.Name = name;
            return t;
        }

        #endregion
    }

    
}
