namespace Telepresence.API.Contract.TelepresenceUser
{
    /// <summary>
    /// Request contract for register users
    /// </summary>
    public class UserRegisterRequest
    {
        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User identifier (unique)
        /// </summary>
        public string Identifier { get; set; }
    }
}
