using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IReviewerPictureRepo : IUniversal
    {
        IEnumerable<ReviewerPictureModel> GetAll(int pageNumber, int pageSize);
        ReviewerPictureModel Insert(ReviewerPictureModel value);
        ReviewerPictureModel Update(ReviewerPictureModel value);
        ReviewerPictureModel Search(int reviewerId, int appointmentId);
        void Delete(ReviewerPictureModel value);
    }
}
