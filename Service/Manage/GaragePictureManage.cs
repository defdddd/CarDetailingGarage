using CDG.Validation.ValidatorTool;
using DataAccess.UnitOfWork;
using FluentValidation;
using Models.Pictures;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manage
{
    public class GaragePictureManage : IGaragePictureManage
    {

        private IUnitOfWork _unitOfWork;
        private IValidator<GaragePictureModel> _validator;

        public GaragePictureManage(IUnitOfWork unitOfWork, IValidator<GaragePictureModel> validator)
        {
            _unitOfWork = unitOfWork ?? throw new NullReferenceException(nameof(unitOfWork));
            _validator = validator ?? throw new NullReferenceException(nameof(validator));
        }
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GaragePictureRepository.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.GaragePictureRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GaragePictureModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1) throw new Exception("Invalid data");

            return await _unitOfWork.GaragePictureRepository.GetAllAsync(pageNumber, pageSize) ??
                throw new Exception("This table is empty");
        }

        public async Task<IEnumerable<GaragePictureModel>> GetAllAsync()
        {
            var pageSize = await _unitOfWork.GaragePictureRepository.CountAsync() + 1;
            if (pageSize == 1) throw new Exception("This table is empty");

            return await _unitOfWork.GaragePictureRepository.GetAllAsync(1, pageSize);
        }

        public async Task<IEnumerable<GaragePictureModel>> GetAppointmentPicturesAsync(int appointmentId, int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1) throw new Exception("Invalid data");

            return await _unitOfWork.GaragePictureRepository.GetAppointmentPicturesAsync(appointmentId, pageNumber, pageSize) ??
                throw new Exception("This table is empty");
        }

        public async Task<GaragePictureModel> InsertAsync(GaragePictureModel value)
        {
            var GaragePicture = await _unitOfWork.GaragePictureRepository.SearchByIdAsync(value.Id);

            if (GaragePicture != null) throw new Exception("GaragePicture already exists");

            ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfWork.GaragePictureRepository.InsertAsync(value);
        }

        public async Task<GaragePictureModel> SearchByIdAsync(int id)
        {
            return await _unitOfWork.GaragePictureRepository.SearchByIdAsync(id) ?? throw new Exception("GaragePicture does not exists");
        }

        public async Task<GaragePictureModel> UpdateAsync(GaragePictureModel value)
        {
            var GaragePicture = await _unitOfWork.GaragePictureRepository.SearchByIdAsync(value.Id);

            if (GaragePicture is null) throw new Exception("GaragePicture does not exists");

            ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfWork.GaragePictureRepository.UpdateAsync(value);
        }
       
    }
}
