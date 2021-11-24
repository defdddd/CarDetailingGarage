using Models;
using System.Collections.Generic;

namespace Service.Manage
{
    public interface IPersonManage
    {
        IEnumerable<PersonModel> GetAllPage(int pageSize, int pageNumber);
        PersonModel Search(string userName);
    }
}