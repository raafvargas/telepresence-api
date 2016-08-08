using System.Threading.Tasks;
using Telepresence.API.Contract.TelepresenceUser;
using Telepresence.API.Contract.User;
using Telepresence.API.Dependency;

namespace Telepresence.API.Services.Telepresence
{
    /// <summary>
    /// Telepresence Service
    /// </summary>
    public interface ITelepresenceSerivce : IDependencyResolver
    {
        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="request">User information</param>
        /// <returns>Registered user id</returns>
        Task<UserRegisterResponse> RegisterAsync(UserRegisterRequest request);

        /// <summary>
        /// Gets a user
        /// </summary>
        /// <param name="request">User identifier</param>
        /// <returns></returns>
        Task<GetUserResponse> GetAsync(GetUserRequest request);
    }
}
