using CDG.DataAccess.Data.Interface;
using CDG.Models;
using DataAccess.Data.Repostiory;
using DataAccess.SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.DataAccess.Data
{
    public class ProfilePictureRepository : Repository<ProfilePictureModel>, IProfilePictureRepository
    {
        protected override string GetAll => "GetProfilePicture";

        protected override string Update => "UpdateProfilePicture";

        protected override string Delete => "DeleteProfilePicture";

        protected override string Count => "CountProfilePicture";

        public ProfilePictureRepository(ISqlDataAccess sqlDataAccess)
        {
            this._sqlDataAccess = sqlDataAccess;
        }

        public async override Task<ProfilePictureModel> InsertAsync(ProfilePictureModel value) =>
           await _sqlDataAccess.SaveData<ProfilePictureModel, dynamic>("InsertProfilePicture",
                new
                {
                    UserId = value.UserId,
                    Image = value.Image
                });

        public async Task<ProfilePictureModel> SearchByIdAsync(int id) =>
            await _sqlDataAccess.SaveData<ProfilePictureModel, dynamic>("SearchProfilePicture",
                new
                {
                    Id = id
                }
                );
    }
}
