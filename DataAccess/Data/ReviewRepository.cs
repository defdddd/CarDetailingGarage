using DataAccess.Data.Repostiory;
using DataAccess.Data.Interface;
using DataAccess.SqlDataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ReviewRepository : Repository<ReviewModel>, IReviewRepository
    {
        protected override string GetAll => "GetAllReview";

        protected override string Update => "UpdateReview";

        protected override string Delete => "DeleteReview";

        protected override string Count => "CountReview";

        public ReviewRepository(ISqlDataAccess sqlDataAccess)
        {
            this._sqlDataAccess = sqlDataAccess;
        }

        public override async Task<ReviewModel> InsertAsync(ReviewModel value) =>
             await _sqlDataAccess.SaveData<ReviewModel, dynamic>("InsertReview",
                 new
                     {
                         UserId = value.UserId,
                         AppointmentId = value.AppointmentId,
                         Grade = value.Grade,
                         Review = value.Review,
                         IsOke = value.IsOke
                     }
                 );

        public async Task<ReviewModel> SearchByIdAsync(int id) =>
            await _sqlDataAccess.SaveData<ReviewModel, dynamic>("SearchReviewById", new { Id = id });

        public async Task<IEnumerable<ReviewModel>> GetMyReviewsAsync(int userId, int pageNumber, int pageSize) =>
          await _sqlDataAccess.LoadData<ReviewModel, dynamic>("GetMyReviews",
               new { userId = userId, pageNumber = pageNumber, pageSize = pageSize });
    }
}
