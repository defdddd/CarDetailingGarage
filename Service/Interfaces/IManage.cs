using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IManage<T> where T : class
    {
        Task<int> CountAsync();
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<T> InsertAsync(T value);
        Task<T> UpdateAsync(T value);
    }
}
