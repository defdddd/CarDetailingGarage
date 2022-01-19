using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAppointmentManage : IManage<AppointmentModel>
    {
        Task<AppointmentModel> SearchByIdAsync(int id);
        Task<IEnumerable<AppointmentModel>> GetMyAppointmentsAsync(int personId, int pageNumber, int pageSize);
        Task<Boolean> CheckDateAvailability(DateTime date);

    }
}
