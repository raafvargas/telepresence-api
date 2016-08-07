namespace Telepresence.API.Contract.UserRobot
{
    /// <summary>
    /// Request contract to send a command
    /// </summary>
    public class SendCommandRequest
    {
        /// <summary>
        /// Movement in axis X
        /// </summary>
        public string AxisX { get; set; }
        
        /// <summary>
        /// Movement in axis Y
        /// </summary>
        public string AxisY { get; set; }
        
        /// <summary>
        /// User Id
        /// </summary>
        public string UserId { get; set; }
    }
}
