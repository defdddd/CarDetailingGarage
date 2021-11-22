using DB.Repository.Interfaces;
using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.DataAccess
{
    public class ReviewerPictureRepo : Connection, IReviewerPictureRepo
    {
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

        public ReviewerPictureModel Search(string fullName)
        {
            throw new NotImplementedException();
        }

        public ReviewerPictureModel Update(ReviewerPictureModel value)
        {
            throw new NotImplementedException();
        }
    }
}
