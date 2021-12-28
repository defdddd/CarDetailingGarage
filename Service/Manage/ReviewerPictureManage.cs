using Models.Pictures;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manage
{
    public class ReviewerPictureManage : IReviewerPictureManage
    {
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewerPictureModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewerPictureModel> InsertAsync(ReviewerPictureModel value)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewerPictureModel> UpdateAsync(ReviewerPictureModel value)
        {
            throw new NotImplementedException();
        }
    }
}
