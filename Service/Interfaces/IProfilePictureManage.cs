using CDG.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Service.Interfaces
{
    public interface IProfilePictureManage : IManage<ProfilePictureModel>
    {
        Task<ProfilePictureModel> SearchByIdAsync(int id);

    }
}
