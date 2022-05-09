using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace DataAccess.SqlDataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly string _connection;

        //atribuirea stringului de conectare
        public SqlDataAccess(string connection)
        {
            _connection = connection;
        }

        //Implementarea metodei LoadData pentru partea de read din CRUD
        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameteres)
        {
            using var connection = new SqlConnection(_connection);

            return await connection.QueryAsync<T>(storedProcedure, parameteres,
                commandType: CommandType.StoredProcedure);
        }

        //Implementarea metodei SaveData care se ocupa cu celelalte operatii CRUD
        //Create, Update, Delete
        public async Task<T> SaveData<T,U>(string storedProcedure, U parameteres)
        {
            using var connection = new SqlConnection(_connection);

            var results = await connection.QueryAsync<T>(storedProcedure, parameteres,
                 commandType: CommandType.StoredProcedure);

            return results.FirstOrDefault();
        }
    }
}
