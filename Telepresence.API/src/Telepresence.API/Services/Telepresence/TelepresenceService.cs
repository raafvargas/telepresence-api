using System.Linq;
using System.Threading.Tasks;
using Telepresence.API.Contract.TelepresenceUser;
using Telepresence.API.Contract.User;
using Telepresence.API.Models.Telepresence;
using Telepresence.API.Repository.Telepresence;

namespace Telepresence.API.Services.Telepresence
{
    /// <summary>
    /// Telepresence Service
    /// </summary>
    public class TelepresenceService : ITelepresenceSerivce
    {
        private readonly ITelepresenceRepository _repository;
       
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public TelepresenceService(ITelepresenceRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="request">User information</param>
        /// <returns>Registered user id</returns>
        public async Task<UserRegisterResponse> RegisterAsync(UserRegisterRequest request)
        {
            var users = await _repository.GetAsync();

            if (users.Any(u => u.Identifier == request.Identifier))
            {
                var user = users.FirstOrDefault(x => x.Identifier == request.Identifier);

                return new UserRegisterResponse
                {
                    UserId = user.id
                };
            }

            var registration = await _repository.RegisterAsync(new User
            {
                Identifier = request.Identifier,
                Name = request.UserName,
                Password = request.Password
            });

            return new UserRegisterResponse
            {
                UserId = registration
            };
        }

        /// <summary>
        /// Gets a user
        /// </summary>
        /// <param name="request">User identifier</param>
        /// <returns></returns>
        public async Task<GetUserResponse> GetAsync(GetUserRequest request)
        {
            var users = await _repository.GetAsync();

            return new GetUserResponse
            {
                User = users.FirstOrDefault(u => u.Identifier == request.Identifier)
            };
        }
    }
}
