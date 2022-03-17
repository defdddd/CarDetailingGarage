using DataAccess.Data.Repostiory;
using DataAccess.Data.Interface;
using DataAccess.SqlDataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class PersonRepository : Repository<PersonModel>, IPersonRepository
    {
        protected override string GetAll => "GetAllPerson"; 
        protected override string Update => "UpdatePerson"; 
        protected override string Delete => "DeletePerson"; 
        protected override string Count => "CountPerson"; 

        public PersonRepository(ISqlDataAccess sqlDataAccess)
        {
           this._sqlDataAccess = sqlDataAccess;
        }

        public override async Task<PersonModel> InsertAsync(PersonModel value) =>
           await _sqlDataAccess.SaveData<PersonModel, dynamic>("InsertPerson",
                new 
                {
                    UserName = value.UserName,
                    Password = value.Password,
                    Name = value.Name,
                    Gender = value.Gender,
                    Email = value.Email,
                    Phone = value.Phone,
                    IsAdmin = value.IsAdmin
                });  

        public async Task<PersonModel> SearchByUserNameAsync(string userName) =>
           await _sqlDataAccess.SaveData<PersonModel, dynamic>("SearchPersonUserName", new { UserName = userName });

        public  async Task<bool> CheckEmailAsync(string email) =>
            null != await _sqlDataAccess.SaveData<PersonModel, dynamic>("CheckEmailAsync", new { email = email });

        public async Task<bool> CheckUserNameAsync(string userName) =>
            null != await _sqlDataAccess.SaveData<PersonModel, dynamic>("CheckUserNameAsync", new { userName = userName });

        public async Task<PersonModel> SearchByIdAsync(int id) =>
           await _sqlDataAccess.SaveData<PersonModel, dynamic>("SearchPersonId", new { id = id });
    }
}
