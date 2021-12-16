using Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manage
{
    public class ReviewManage : IReviewManage
    {
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewModel> InsertAsync(ReviewModel value)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewModel> UpdateAsync(ReviewModel value)
        {
            throw new NotImplementedException();
        }
    }
}
