namespace Telepresence.API.Contract.User
{
    /// <summary>
    /// Request contract to get an user
    /// </summary>
    public class GetUserRequest
    {
        /// <summary>
        /// User identifier
        /// </summary>
        public string Identifier { get; set; }
    }
}