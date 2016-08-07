namespace Telepresence.API.Contract.TelepresenceUser
{
    /// <summary>
    /// Response contract for register users
    /// </summary>
    public class UserRegisterResponse : ResponseContractBase
    {
        /// <summary>
        /// User Id
        /// </summary>
        public string UserId { get; set; }
    }
}
