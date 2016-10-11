using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Database.TemplateDatabase {
    public class TemplateRecord : Record  {
        public Template.Persistence.IPersistentTemplate PersistentTemplate { get; set; }

        public TemplateRecord(string sampleID, BiometricID bioID, Template.Persistence.IPersistentTemplate template) {
            this.PersistentTemplate = template;
            this.BiometricID = bioID;
            this.SampleID = sampleID;
        }
    }
}
