﻿using DataAccess.Data.CommonData;
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
                    Email = value.Email,
                    Phone = value.Email,
                    IsAdmin = value.IsAdmin
                });  

        public async Task<PersonModel> SearchByUserNameAsync(string userName) =>
           await _sqlDataAccess.SaveData<PersonModel, dynamic>("SearchPersonUserName", new { UserName = userName });

    }
}