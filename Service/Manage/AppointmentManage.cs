using CDG.Validation.ValidatorTool;
using DataAccess.UnitOfWork;
using FluentValidation;
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
        private IUnitOfWork _unitOfWork;

        private IValidator<AppointmentModel> _validator;
        public AppointmentManage(IUnitOfWork unitOfWork, IValidator<AppointmentModel> validator)
        {
            _unitOfWork = unitOfWork ?? throw new NullReferenceException(nameof(unitOfWork));
            _validator = validator ?? throw new NullReferenceException(nameof(validator));
        }
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.AppointmentRepository.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.AppointmentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AppointmentModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1) throw new Exception("Invalid data");

            return await _unitOfWork.AppointmentRepository.GetAllAsync(pageNumber, pageSize) ??
                throw new Exception("This table is empty");
        }

        public async Task<IEnumerable<AppointmentModel>> GetAllAsync()
        {
            var pageSize = await _unitOfWork.AppointmentRepository.CountAsync() + 1;
            if (pageSize == 1) throw new Exception("This table is empty");

            return await _unitOfWork.AppointmentRepository.GetAllAsync(1, pageSize);
        }

        public async Task<IEnumerable<AppointmentModel>> GetMyAppointmentsAsync(int personId, int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1) throw new Exception("Invalid data");

            return await _unitOfWork.AppointmentRepository.GetMyAppointmentsAsync(personId,pageNumber, pageSize) ??
                throw new Exception("This table is empty");
        }

        public async Task<AppointmentModel> InsertAsync(AppointmentModel value)
        {
            var appointment = await _unitOfWork.AppointmentRepository.SearchByIdAsync(value.Id);

            if (appointment != null) throw new Exception("Appointment already exists");

            ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfWork.AppointmentRepository.InsertAsync(value);
        }

        public async Task<AppointmentModel> SearchByIdAsync(int id)
        {
            return await _unitOfWork.AppointmentRepository.SearchByIdAsync(id) ?? throw new Exception("Appointment does not exists");
        }

        public async Task<AppointmentModel> UpdateAsync(AppointmentModel value)
        {
            var appointment = await _unitOfWork.AppointmentRepository.SearchByIdAsync(value.Id);

            if (appointment is null) throw new Exception("Appointment does not exists");

            ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfWork.AppointmentRepository.UpdateAsync(value);
        }
    }
}
