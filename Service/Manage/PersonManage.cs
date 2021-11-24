using DB.Repository.Interfaces;
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
        private readonly IPersonRepo personRepo;

        public PersonManage(IPersonRepo personRepo)
        {
            this.personRepo = personRepo;
        }
        public IEnumerable<PersonModel> GetAllPage(int pageSize, int pageNumber)
        {
            return personRepo.GetAll(pageNumber, pageSize);
        }
        public PersonModel Search(string userName)
        {
            var user = personRepo.Search(userName);
            return user ?? throw new Exception("User not Found");
        }
    }
}
