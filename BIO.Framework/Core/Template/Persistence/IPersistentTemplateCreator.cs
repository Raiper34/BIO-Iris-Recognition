using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Database;

namespace BIO.Framework.Core.Template.Persistence {
    public interface IPersistentTemplateCreator {
        /// <summary>
        /// create persistent template with given name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
 
        IPersistentTemplate createPersistentTemplate(string name, Core.Database.BiometricID recordId);

        /// <summary>
        /// create persistent tempalte as subtemplate of parent
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
         IPersistentTemplate createPersistentTemplate(string name, IPersistentTemplate parent);
    }
}
