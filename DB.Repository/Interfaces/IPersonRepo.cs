using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IPersonRepo : IUniversal
    {
        IEnumerable<PersonModel> GetAll(int pageNumber, int pageSize);
        PersonModel Insert(PersonModel value);
        PersonModel Update(PersonModel value);
        PersonModel Search(string fullName);
        void Delete(PersonModel value);
    }
}
