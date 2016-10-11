using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Project {
    public interface IStandardProjectSettings<TInputRecord> : IProjectSettings<TInputRecord>
        where TInputRecord : Framework.Core.Database.IRecord {
        
        int TemplateSamples { get; }
    
    }
}
