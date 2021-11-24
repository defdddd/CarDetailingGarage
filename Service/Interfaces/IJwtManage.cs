using Models;

namespace Service.Manage
{
    public interface IJwtManage
    {
        dynamic GenerateToken(AuthModel authModel);
        bool IsValidUserNameAndPassowrd(AuthModel authModel);
    }
}