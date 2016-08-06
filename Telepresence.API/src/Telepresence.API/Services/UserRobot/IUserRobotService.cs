using System.Threading.Tasks;
using Telepresence.API.Contract.UserRobot;
using Telepresence.API.Dependency;

namespace Telepresence.API.Services.UserRobot
{
    public interface IUserRobotService : IDependencyResolver
    {
        Task<AssociateUserRobotResponse> AssociateAsync(AssociateUserRobotRequest request);

        Task<SendCommandResponse> SendCommandAsync(SendCommandRequest request);
    }
}
