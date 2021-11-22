using DB.Repository.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.DataAccess
{
    public class PersonRepo : Connection, IPersonRepo
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(PersonModel value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonModel> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public PersonModel Insert(PersonModel value)
        {
            throw new NotImplementedException();
        }

        public PersonModel Search(string fullName)
        {
            throw new NotImplementedException();
        }

        public PersonModel Update(PersonModel value)
        {
            throw new NotImplementedException();
        }
    }
}
