
namespace Telepresence.API.Contract.Robot
{
    /// <summary>
    /// Register Robot Response Contract
    /// </summary>
    public class RegisterRobotResponse : ResponseContractBase
    {
        /// <summary>
        /// Registered robot id
        /// </summary>
        public string RobotId { get; set; }
    }
}
