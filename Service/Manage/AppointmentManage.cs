using Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manage
{
    public class AppointmentManage : IAppointmentManage
    {
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentModel> InsertAsync(AppointmentModel value)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentModel> UpdateAsync(AppointmentModel value)
        {
            throw new NotImplementedException();
        }
    }
}
