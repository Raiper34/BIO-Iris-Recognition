using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BIO.Framework.Core.Block {
    public interface ITemplateExtractingBlock <TData> : IBlock, IProgressReporter {
        /// <summary>
        /// serialize template to stream
        /// </summary>
        /// <param name="stream"></param>
        void extractAndAddToNewTemplate(TData input, Template.Persistence.IPersistentTemplate newTemplateToStore);

        /// <summary>
        /// serialize template to stream
        /// </summary>
        /// <param name="stream"></param>
        //void extractAndAddToExistingTemplate(TData input, Template.Persistence.IPersistentTemplate existingTemplate, Template.Persistence.IPersistentTemplate newTemplateToStore);

        

    }
}
