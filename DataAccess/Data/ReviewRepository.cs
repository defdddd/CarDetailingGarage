using DataAccess.Data.CommonData;
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
                         Review = value.Review,
                         IsOke = value.IsOke
                     }
                 );                    
    }
}
