using System.Threading.Tasks;
using Telepresence.API.Contract.Robot;
using Telepresence.API.Repository.Robot;

namespace Telepresence.API.Services.Robot
{
    /// <summary>
    /// Service Manager to Robots
    /// </summary>
    public class RobotService : IRobotService
    {
        private readonly IRobotRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Dependent repository</param>
        public RobotService(IRobotRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Register a new robot
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RegisterRobotResponse> RegisterAsync(RegisterRobotRequest request)
        {
            var robot = await _repository.GetAsync(r => r.Name == request.Name);

            if (robot != null)
                return new RegisterRobotResponse { RobotId = robot.id };

            var id = await _repository.RegisterAsync(new Models.Robot
            {
                Name = request.Name
            });

            return new RegisterRobotResponse { RobotId = id };
        }

        /// <summary>
        /// Get a robot
        /// </summary>
        /// <param name="request">Get speficication</param>
        /// <returns></returns>
        public async Task<GetRobotResponse> GetAsync(GetRobotRequest request)
        {
            var robot = await _repository.GetAsync(request.Id);

            return new GetRobotResponse { Robot = robot };
        }
    }
}
