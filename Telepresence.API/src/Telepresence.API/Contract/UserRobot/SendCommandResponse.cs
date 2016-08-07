namespace Telepresence.API.Contract.UserRobot
{
    /// <summary>
    /// Response contract to send command
    /// </summary>
    public class SendCommandResponse : ResponseContractBase
    {
        /// <summary>
        /// Commant sent successfully
        /// </summary>
        public bool Success { get; set; }
    }
}
