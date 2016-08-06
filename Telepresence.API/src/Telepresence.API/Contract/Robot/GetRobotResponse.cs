namespace Telepresence.API.Contract.Robot
{
    /// <summary>
    /// Get robot response contract
    /// </summary>
    public class GetRobotResponse : ResponseContractBase
    {
        /// <summary>
        /// The robot
        /// </summary>
        public Models.Robot Robot { get; set; }
    }
}
