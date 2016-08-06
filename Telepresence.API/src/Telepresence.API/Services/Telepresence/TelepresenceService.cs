using System.Threading.Tasks;
using Telepresence.API.Contract.TelepresenceUser;
using Telepresence.API.Models.Telepresence;
using Telepresence.API.Repository.Telepresence;

namespace Telepresence.API.Services.Telepresence
{
    public class TelepresenceService : ITelepresenceSerivce
    {
        private readonly ITelepresenceRepository _repository;
       
        public TelepresenceService(ITelepresenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<TelepresenceUserRegisterResponse> RegisterAsync(TelepresenceUserRegisterRequest request)
        {
            var registration = await _repository.RegisterAsync(new User
            {
                Identifier = request.Identifier,
                Name = request.UserName,
                Password = request.Password
            });

            return new TelepresenceUserRegisterResponse
            {
                UserId = registration
            };
        }
    }
}
