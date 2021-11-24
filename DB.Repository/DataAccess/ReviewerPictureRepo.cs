using DB.Repository.Interfaces;
using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.DataAccess
{
    public class ReviewerPictureRepo : IReviewerPictureRepo
    {
        private readonly string connection;
        public ReviewerPictureRepo(IConnection connection)
        {
            this.connection = connection.DataBaseConnection;
        }
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(ReviewerPictureModel value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReviewerPictureModel> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public ReviewerPictureModel Insert(ReviewerPictureModel value)
        {
            throw new NotImplementedException();
        }

        public ReviewerPictureModel Search(int reviewerId, int appointmentId)
        {
            throw new NotImplementedException();
        }

        public ReviewerPictureModel Update(ReviewerPictureModel value)
        {
            throw new NotImplementedException();
        }
    }
}
