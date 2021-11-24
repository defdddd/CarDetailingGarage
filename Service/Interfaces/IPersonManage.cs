using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Manage
{
    public interface IPersonManage
    {
        Task<IEnumerable<PersonModel>> GetAllPageAsync(int pageSize, int pageNumber);
        Task<PersonModel> SearchByUserNameAsync(string userName);
    }
}