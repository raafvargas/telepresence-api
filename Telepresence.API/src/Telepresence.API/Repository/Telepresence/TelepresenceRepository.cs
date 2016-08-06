using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telepresence.API.Models.Telepresence;
using Telepresence.API.Repository.Base;

namespace Telepresence.API.Repository.Telepresence
{
    public class TelepresenceRepository : DocumentDbRespository<User>, ITelepresenceRepository
    {
        public TelepresenceRepository() : base("Telepresence", "User") { }

        public async Task<string> RegisterAsync(User user)
        {
            return await Save(user);
        }

        public async Task<ICollection<User>> GetAsync()
        {
            return await Get();
        }

        public async Task<User> GetAsync(string id)
        {
            return await Get(id);
        }
    }
}
