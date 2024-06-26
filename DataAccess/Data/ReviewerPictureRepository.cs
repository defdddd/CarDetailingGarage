﻿using DataAccess.Data.Repostiory;
using DataAccess.Data.Interface;
using DataAccess.SqlDataAccess;
using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ReviewerPictureRepository : Repository<ReviewerPictureModel>, IReviewerPictureRepository
    {
        protected override string GetAll => "GetAllReviewerPicture";

        protected override string Update => "UpdateReviewerPicture";

        protected override string Delete => "DeleteReviewerPicture";

        protected override string Count => "CountReviewerPicture";

        public ReviewerPictureRepository(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        public async override Task<ReviewerPictureModel> InsertAsync(ReviewerPictureModel value) =>
            await _sqlDataAccess.SaveData<ReviewerPictureModel, dynamic>("InsertReviewerPicture",
                new
                    { 
                        ReviewId = value.ReviewId,
                        AppointmentId = value.AppointmentId,
                        FileName = value.FileName,
                        ImagePath = value.ImagePath
                    }
                );

        public async Task<IEnumerable<ReviewerPictureModel>> GetReviewPicturesAsync(int reviewId, int appointmentId) =>
            await _sqlDataAccess.LoadData<ReviewerPictureModel, dynamic>("GetReviewPictures",
                new
                    {
                        ReviewId = reviewId,
                        AppointmentId = appointmentId                
                    }
                );


        public async Task<ReviewerPictureModel> SearchByIdAsync(int id) =>
            await _sqlDataAccess.SaveData<ReviewerPictureModel, dynamic>("SearchReviewPictureById",
                new
                    {
                       Id = id
                    }
                );
    }
}
