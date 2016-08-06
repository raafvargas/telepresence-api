using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Telepresence.API.Contract
{
    /// <summary>
    /// Base Response
    /// </summary>
    public class ResponseContractBase
    {
        /// <summary>
        /// Exception ocurred
        /// </summary>
        public Exception Exception { get; set; }
    }
}
