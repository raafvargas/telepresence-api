namespace Telepresence.API.Contract.UserRobot
{
    /// <summary>
    /// Return information about association between users and robots
    /// </summary>
    public class AssociateUserRobotResponse : ResponseContractBase
    {
        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; set; }
    }
}
