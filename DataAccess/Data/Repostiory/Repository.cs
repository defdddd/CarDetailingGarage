using DataAccess.SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repostiory
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ISqlDataAccess _sqlDataAccess;
        protected abstract string GetAll { get; }
        protected abstract string Update { get; }
        protected abstract string Delete { get; }
        protected abstract string Count { get; }

        public async Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize) =>
          await _sqlDataAccess.LoadData<T, dynamic>(GetAll,
               new { pageNumber = pageNumber, pageSize = pageSize });

        public async Task<T> UpdateAsync(T value)
        {
            await _sqlDataAccess.SaveData<T, T>(Update, value);
            return value;
        }

        public async Task DeleteAsync(int id)
        {
            await _sqlDataAccess.SaveData<dynamic, dynamic>(Delete, new { Id = id });
        }
        public async Task<int> CountAsync() => await _sqlDataAccess.SaveData<int, dynamic>(Count, new { });

        public abstract Task<T> InsertAsync(T value);
           
    }
}
