using System;

namespace Telepresence.API.Contract.UserRobot
{
    /// <summary>
    /// Request contract for association between user and robots
    /// </summary>
    public class AssociateUserRobotRequest
    {
        /// <summary>
        /// Expires
        /// </summary>
        public DateTime AssociationExpires { get; set; }

        /// <summary>
        /// Robot Id
        /// </summary>
        public string RobotId { get; set; }

        /// <summary>
        /// Robot Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Association active
        /// </summary>
        public bool Active { get; set; }
    }
}
