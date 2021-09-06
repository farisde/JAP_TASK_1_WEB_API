using System.Threading.Tasks;
using JAP_TASK_1_WEB_API.Models;

namespace JAP_TASK_1_WEB_API.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<bool> UserExists(string email);
    }
}