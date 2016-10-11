using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Template.Persistence {
    public interface IPersistentTemplate {
        /// <summary>
        /// every persistent template has its own name
        /// </summary>
        string Name {
            get;
            set;
        }

        /// <summary>
        /// get tempalte stream to store data
        /// </summary>
        /// <returns></returns>
        System.IO.Stream getStream();

        /// <summary>
        /// get subtemplate
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IPersistentTemplate getSubtemplate(string name);
        /// <summary>
        /// create subtemplate and returns it
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IPersistentTemplate createSubtemplate(string name);
    }
}
