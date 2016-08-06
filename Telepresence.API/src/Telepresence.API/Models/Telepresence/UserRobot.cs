using System;
using Telepresence.API.Repository.Base;

namespace Telepresence.API.Models.Telepresence
{
    /// <summary>
    /// Association between user and robot
    /// </summary>
    public class UserRobot : DocumentBase
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
