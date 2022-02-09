using Models;
using System.Threading.Tasks;

namespace Service.Manage
{
    public interface IAuthManage
    {
        Task<dynamic> GenerateToken(AuthModel authModel);
        Task<bool> IsValidUserNameAndPassowrd(AuthModel authModel);
        Task<bool> CheckEmailAsync(string email);
        Task<bool> CheckUserNameAsync(string userName);
        Task<bool> RegisterAsync(PersonModel person);
    }
}