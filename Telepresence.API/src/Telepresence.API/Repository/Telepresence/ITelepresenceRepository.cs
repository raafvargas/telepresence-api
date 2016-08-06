using System.Collections.Generic;
using System.Threading.Tasks;
using Telepresence.API.Dependency;
using Telepresence.API.Models.Telepresence;

namespace Telepresence.API.Repository.Telepresence
{
    public interface ITelepresenceRepository : IDependencyResolver
    {
        Task<string> RegisterAsync(User user);
        Task<ICollection<User>> GetAsync();
        Task<User> GetAsync(string id);
    }
}
