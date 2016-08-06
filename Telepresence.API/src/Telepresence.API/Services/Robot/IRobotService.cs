using System.Threading.Tasks;
using Telepresence.API.Contract.Robot;
using Telepresence.API.Dependency;

namespace Telepresence.API.Services.Robot
{
    public interface IRobotService : IDependencyResolver
    {
        Task<RegisterRobotResponse> RegisterAsync(RegisterRobotRequest request);
        Task<GetRobotResponse> GetAsync(GetRobotRequest request);
    }
}
