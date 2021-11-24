using DataAccess.SqlDataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class PersonData : IPersonData
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        public PersonData(ISqlDataAccess sqlDataAccess)
        {
           _sqlDataAccess = sqlDataAccess;
        }

        public Task<IEnumerable<PersonModel>> GetAllAsync(int pageNumber, int pageSize) =>
           _sqlDataAccess.LoadData<PersonModel, dynamic>("GetAllPerson",
                new { pageNumber = pageNumber, pageSize = pageSize });

        public async Task<PersonModel> InsertAsync(PersonModel value)
        {
           return await _sqlDataAccess.SaveData<PersonModel, dynamic>("InsertPerson",
                new 
                {
                    UserName = value.UserName,
                    Password = value.Password,
                    Name = value.Name,
                    Email = value.Email,
                    Phone = value.Email,
                    IsAdmin = value.IsAdmin
                });  
        }
        public async Task<PersonModel> UpdateAsync(PersonModel value)
        {
           return await _sqlDataAccess.SaveData<PersonModel, PersonModel>("UpdatePerson",value);  
        }
        public async Task<PersonModel> SearchAsync(string fullName)
        {
           return await _sqlDataAccess.SaveData<PersonModel, dynamic>("SearchPerson", new { Name = fullName });          
        }
        public async Task DeleteAsync(PersonModel value)
        {
           await _sqlDataAccess.SaveData<dynamic,dynamic>("DeletePerson", new { Id = value.Id });
        }
        public Task<int> Count() => _sqlDataAccess.SaveData<int, dynamic>("CountPerson", new { });             
    }
}
