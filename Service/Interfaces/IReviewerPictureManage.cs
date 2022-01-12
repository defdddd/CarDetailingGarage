using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IReviewerPictureManage :IManage<ReviewerPictureModel>
    {
        Task<IEnumerable<ReviewerPictureModel>> GetReviewPicturesAsync(int reviewId, int appointmentId);
        Task<ReviewerPictureModel> SearchByIdAsync(int id);
        Task<int> GetUserId(ReviewerPictureModel reviewerPictureModel);
    }
}
