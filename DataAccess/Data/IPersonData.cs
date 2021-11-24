using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IPersonData : IUniversal
    {
        Task DeleteAsync(PersonModel value);
        Task<IEnumerable<PersonModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<PersonModel> InsertAsync(PersonModel value);
        Task<PersonModel> SearchAsync(string fullName);
        Task<PersonModel> UpdateAsync(PersonModel value);
    }
}