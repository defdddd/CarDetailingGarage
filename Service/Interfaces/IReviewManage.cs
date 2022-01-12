using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IReviewManage : IManage<ReviewModel>
    {
        Task<ReviewModel> SearchByIdAsync(int id);
        Task<IEnumerable<ReviewModel>> GetMyReviewsAsync(int userId, int pageNumber, int pageSize);
    }
}
