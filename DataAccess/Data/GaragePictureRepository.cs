using DataAccess.Data.Repostiory;
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
    public class GaragePictureRepository : Repository<GaragePictureModel>, IGaragePictureRepository
    {
        protected override string GetAll => "GetAllGaragePicture";

        protected override string Update => "UpdateGaragePicture";

        protected override string Delete => "DeleteGaragePicture";

        protected override string Count => "CountGaragePicture";
        public GaragePictureRepository(ISqlDataAccess sqlDataAcces)
        {
            _sqlDataAccess = sqlDataAcces;
        }

        public async override Task<GaragePictureModel> InsertAsync(GaragePictureModel value) =>
            await _sqlDataAccess.SaveData<GaragePictureModel, dynamic>("InsertGaragePicture",
                new 
                    {
                        AppointmentId = value.AppointmentId,
                        FileName = value.FileName,
                        ImagePath = value.ImagePath
                    }
                );

        public async Task<IEnumerable<GaragePictureModel>> GetAppointmentPicturesAsync(int appointmentId, int pageNumber, int pageSize) =>
            await _sqlDataAccess.LoadData<GaragePictureModel, dynamic>("GetAppointmentPictures",
                new
                    {
                        appointmentId = appointmentId,
                        pageNumber = pageNumber,
                        pageSize = pageSize
                    }
                );

        public async Task<GaragePictureModel> SearchByIdAsync(int id) =>
            await _sqlDataAccess.SaveData<GaragePictureModel, dynamic>("SearchGaragePictureById", new { Id = id });
    }
}
