using DataAccess.Data.Repostiory;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Interface
{
    public interface IReviewRepository : IRepository<ReviewModel>
    {
        Task<ReviewModel> SearchByIdAsync(int id);
        Task<IEnumerable<ReviewModel>> GetMyReviewsAsync(int userId, int pageNumber, int pageSize);

    }
}
