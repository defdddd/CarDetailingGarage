using DataAccess.Data.CommonData;
using DataAccess.Data.Interface;
using DataAccess.SqlDataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class AppointmentRepository : Repository<AppointmentModel>, IAppointmentRepository
    {
        protected override string GetAll => "GetAllAppointment";
        protected override string Update => "UpdateAppointment";
        protected override string Delete => "DeleteAppointment";
        protected override string Count => "CountAppointment";
        public AppointmentRepository(ISqlDataAccess sqlDataAccess)
        {
            this._sqlDataAccess = sqlDataAccess;
        }
        public async Task<IEnumerable<AppointmentModel>> GetMyAppointmentsAsync(int personId, int pageNumber, int pageSize) =>
             await _sqlDataAccess.LoadData<AppointmentModel, dynamic>("GetMyAppointment",
                new { personId = personId, pageNumber = pageNumber, pageSize = pageSize });

        public override async Task<AppointmentModel> InsertAsync(AppointmentModel value) =>
            await _sqlDataAccess.SaveData<AppointmentModel, dynamic>("InsertAppointment",
                new 
                   {
                        UserName = value.FullName,
                        Type = value.Type,
                        Date = value.Date,
                        Price = value.Price,
                        PersonId = value.PersonId,
                        IsDone = value.IsDone
                   });

        public async Task<AppointmentModel> SearchByIdAsync(int appointmentId) =>
            await _sqlDataAccess.SaveData<AppointmentModel, dynamic>("SearchAppointmentById", new { Id = appointmentId });


    }
}
