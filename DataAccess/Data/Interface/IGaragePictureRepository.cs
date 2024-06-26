﻿using DataAccess.Data.Repostiory;
using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Interface
{
    public interface IGaragePictureRepository : IRepository<GaragePictureModel>
    {
        Task<IEnumerable<GaragePictureModel>> GetAppointmentPicturesAsync(int appointmentId, int pageNumber, int pageSize);
        Task<GaragePictureModel> SearchByIdAsync(int id);
    }
}
