using Telepresence.API.Repository.Base;

namespace Telepresence.API.Models.Telepresence
{
    /// <summary>
    /// User model
    /// </summary>
    public class User : DocumentBase
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
    }
}
