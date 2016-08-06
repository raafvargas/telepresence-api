using System;
using Telepresence.API.Repository.Base;

namespace Telepresence.API.Models
{
    /// <summary>
    /// Robot class
    /// </summary>
    public class Robot : DocumentBase
    {        
        /// <summary>
        /// Robot Name
        /// </summary>
        public string Name { get; set; }
    }
}
