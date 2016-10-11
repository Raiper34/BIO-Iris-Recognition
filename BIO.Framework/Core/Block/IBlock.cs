using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIO.Framework.Core.Block {
    public interface IBlock {
        /// <summary>
        /// get block name
        /// </summary>
        /// <returns></returns>
        // Property declaration:
        string Name {
            get;
            set;
        }
    }
}
