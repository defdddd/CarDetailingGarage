using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IAppointmentRepo
    {
        IEnumerable<AppointmentModel> MyAppointments(int personId, int pageNumber, int pageSize);
        IEnumerable<AppointmentModel> GetAll(int pageNumber, int pageSize);
        AppointmentModel Insert(AppointmentModel value);
        AppointmentModel Update(AppointmentModel value);
        AppointmentModel Search(string fullName);
        void Delete(AppointmentModel value);
        int Count();
    }
}
