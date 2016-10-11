using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core {

    public delegate void ProgressChangedEventHandler(ProgressReport progress);

    public interface IProgressReporter {
        event ProgressChangedEventHandler ProgressChangedEvent;

        void onProgressChanged(ProgressReport e);
    }
}
