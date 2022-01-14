using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Data.Repostiory
{
    public interface IRepository<T> where T : class
    {
        Task<int> CountAsync();
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<T> UpdateAsync(T value);
        Task<T> InsertAsync(T value);
    }
}