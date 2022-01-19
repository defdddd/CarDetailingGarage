using DataAccess.Data.Repostiory;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Data.Interface
{
    public interface IPersonRepository : IRepository<PersonModel>
    {
        Task<PersonModel> SearchByUserNameAsync(string userName);
        Task<Boolean> CheckEmailAsync(string email);
    }
}