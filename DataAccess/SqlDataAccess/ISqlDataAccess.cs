using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameteres);
        Task<T> SaveData<T,U>(string storedProcedure, U parameteres);
    }
}