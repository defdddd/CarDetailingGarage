using DB.Repository.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.DataAccess
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly string connection;
        public ReviewRepo(IConnection connection)
        {
            this.connection = connection.DataBaseConnection;
        }
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(ReviewModel value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReviewModel> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public ReviewModel Insert(ReviewModel value)
        {
            throw new NotImplementedException();
        }

        public ReviewModel Search(string fullName)
        {
            throw new NotImplementedException();
        }

        public ReviewModel Update(ReviewModel value)
        {
            throw new NotImplementedException();
        }
    }
}
