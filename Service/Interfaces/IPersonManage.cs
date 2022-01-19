using Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Manage
{
    public interface IPersonManage : IManage<PersonModel>
    {
        Task<PersonModel> SearchByUserNameAsync(string userName);
    }
}