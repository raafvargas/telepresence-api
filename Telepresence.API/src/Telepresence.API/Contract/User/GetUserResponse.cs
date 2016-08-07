namespace Telepresence.API.Contract.User
{
    /// <summary>
    /// Response contract
    /// </summary>
    public class GetUserResponse : ResponseContractBase
    {
        /// <summary>
        /// The specified user
        /// </summary>
        public Models.Telepresence.User User { get; set; }
    }
}
