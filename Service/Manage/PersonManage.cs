using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manage
{
    public class PersonManage : IPersonManage
    {
        private readonly IPersonData _personData;

        public PersonManage(IPersonData _personData)
        {
            this._personData = _personData;
        }
        public async Task<IEnumerable<PersonModel>> GetAllPage(int pageSize, int pageNumber)
        {
            return await _personData.GetAll(pageNumber, pageSize);
        }
        public async Task<PersonModel> Search(string userName)
        {
            var user = await _personData.Search(userName);
            return user ?? throw new Exception("User not Found");
        }
    }
}
