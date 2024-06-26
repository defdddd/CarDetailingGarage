﻿using DataAccess.Data.Repostiory;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Interface
{
    public interface IAppointmentRepository : IRepository<AppointmentModel>
    {
        Task<IEnumerable<AppointmentModel>> GetMyAppointmentsAsync(int personId, int pageNumber, int pageSize);
        Task<AppointmentModel> SearchByIdAsync(int appointmentId);
        Task<Boolean> CheckDateAvailability(string date);
        Task<IEnumerable<AppointmentModel>> GetCurrentAppointments();
    }
}
