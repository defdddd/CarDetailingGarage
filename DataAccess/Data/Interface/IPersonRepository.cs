using DataAccess.Data.CommonData;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Data.Interface
{
    public interface IPersonRepository : IRepository<PersonModel>
    {
        Task<PersonModel> SearchByUserNameAsync(string userName);
    }
}