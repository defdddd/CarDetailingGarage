using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IReviewRepo : IUniversal
    {
        IEnumerable<ReviewModel> GetAll(int pageNumber, int pageSize);
        ReviewModel Insert(ReviewModel value);
        ReviewModel Update(ReviewModel value);
        ReviewModel Search(string fullName);
        void Delete(ReviewModel value);
    }
}
