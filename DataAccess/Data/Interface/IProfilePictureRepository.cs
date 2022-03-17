using CDG.Models;
using DataAccess.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.DataAccess.Data.Interface
{
    public interface IProfilePictureRepository : IRepository<ProfilePictureModel>
    {
        Task<ProfilePictureModel> SearchByIdAsync(int id);
    }
}
