using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Manage
{
    public interface IPersonManage
    {
        Task<IEnumerable<PersonModel>> GetAllPage(int pageSize, int pageNumber);
        Task<PersonModel> Search(string userName);
    }
}