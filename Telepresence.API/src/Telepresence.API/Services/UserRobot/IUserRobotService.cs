using System.Threading.Tasks;
using Telepresence.API.Contract.UserRobot;
using Telepresence.API.Dependency;

namespace Telepresence.API.Services.UserRobot
{
    /// <summary>
    /// Service Manager to User and Robots
    /// </summary>
    public interface IUserRobotService : IDependencyResolver
    {
        /// <summary>
        /// Associates an user as robot controller
        /// </summary>
        /// <param name="request">Infos about robot and user</param>
        /// <returns></returns>
        Task<AssociateUserRobotResponse> AssociateAsync(AssociateUserRobotRequest request);

        /// <summary>
        /// Send the user command for the robot
        /// </summary>
        /// <param name="request">Command</param>
        /// <param name="robotId">Robot Id</param>
        /// <returns></returns>
        Task<SendCommandResponse> SendCommandAsync(string robotId, SendCommandRequest request);
    }
}
