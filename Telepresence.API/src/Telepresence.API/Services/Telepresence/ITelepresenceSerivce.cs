using System.Threading.Tasks;
using Telepresence.API.Contract.TelepresenceUser;

namespace Telepresence.API.Services.Telepresence
{
    public interface ITelepresenceSerivce
    {
        Task<TelepresenceUserRegisterResponse> RegisterAsync(TelepresenceUserRegisterRequest request);
    }
}
