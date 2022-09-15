using Sat.Recruitment.Api.Models.Request;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Interfaces
{
    public interface IUserApiService
    {
        Task<string> Add(UserRequest user);
    }
}
