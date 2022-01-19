using Models;
using System.Threading.Tasks;

namespace Service.Manage
{
    public interface IJwtManage
    {
        Task<dynamic> GenerateToken(AuthModel authModel);
        Task<bool> IsValidUserNameAndPassowrd(AuthModel authModel);
        Task<bool> CheckEmailAsync(string email);

    }
}