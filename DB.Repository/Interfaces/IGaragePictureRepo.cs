using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IGaragePictureRepo : IUniversal
    {
        IEnumerable<GaragePictureModel> GetAll(int pageNumber, int pageSize);
        GaragePictureModel Insert(GaragePictureModel value);
        GaragePictureModel Update(GaragePictureModel value);
        GaragePictureModel Search(string fullName);
        void Delete(GaragePictureModel value);
    }
}
