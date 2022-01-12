using DataAccess.Data.CommonData;
using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Interface
{
    public interface IReviewerPictureRepository : IRepository<ReviewerPictureModel>
    {
        Task<IEnumerable<ReviewerPictureModel>> GetReviewPicturesAsync(int reviewId, int appointmentId);
        Task<ReviewerPictureModel> SearchByIdAsync(int id);
    }
}
