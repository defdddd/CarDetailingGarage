using DB.Repository.Interfaces;
using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.DataAccess
{
    public class GaragePictureRepo : IGaragePictureRepo
    {
        private readonly string connection;
        public GaragePictureRepo(IConnection connection)
        {
            this.connection = connection.DataBaseConnection;
        }
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(GaragePictureModel value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GaragePictureModel> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public GaragePictureModel Insert(GaragePictureModel value)
        {
            throw new NotImplementedException();
        }

        public GaragePictureModel Search(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public GaragePictureModel Update(GaragePictureModel value)
        {
            throw new NotImplementedException();
        }
    }
}
