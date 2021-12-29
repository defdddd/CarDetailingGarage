using Models.Pictures;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manage
{
    public class GaragePictureManage : IGaragePictureManage
    {
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GaragePictureModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GaragePictureModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GaragePictureModel> InsertAsync(GaragePictureModel value)
        {
            throw new NotImplementedException();
        }

        public Task<GaragePictureModel> UpdateAsync(GaragePictureModel value)
        {
            throw new NotImplementedException();
        }
    }
}
