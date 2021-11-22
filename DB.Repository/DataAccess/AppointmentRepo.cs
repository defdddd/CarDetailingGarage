using DB.Repository.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.DataAccess
{
    public class AppointmentRepo : IAppointmentRepo
    {
        
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(AppointmentModel value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppointmentModel> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public AppointmentModel Insert(AppointmentModel value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppointmentModel> MyAppointments(int personId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public AppointmentModel Search(string fullName)
        {
            throw new NotImplementedException();
        }

        public AppointmentModel Update(AppointmentModel value)
        {
            throw new NotImplementedException();
        }
    }
}
