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
    public class ReviewerPictureManage : IReviewerPictureManage
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ReviewerPictureModel> _validator;

        public ReviewerPictureManage(IUnitOfWork unitOfWork, IValidator<ReviewerPictureModel> validator)
        {
            _unitOfWork = unitOfWork ?? throw new NullReferenceException(nameof(unitOfWork));
            _validator = validator ?? throw new NullReferenceException(nameof(validator));
        }
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.ReviewerPictureRepository.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ReviewerPictureRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ReviewerPictureModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1) throw new ValidationException("Invalid data");

            return await _unitOfWork.ReviewerPictureRepository.GetAllAsync(pageNumber, pageSize) ??
                throw new ValidationException("This table is empty");
        }

        public async Task<IEnumerable<ReviewerPictureModel>> GetAllAsync()
        {
            var pageSize = await _unitOfWork.ReviewerPictureRepository.CountAsync() + 1;
            if (pageSize == 1) throw new ValidationException("This table is empty");

            return await _unitOfWork.ReviewerPictureRepository.GetAllAsync(1, pageSize);
        }

        public Task<IEnumerable<ReviewerPictureModel>> GetReviewPicturesAsync(int reviewId, int appointmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetUserId(ReviewerPictureModel reviewerPictureModel)
        {
            var appointment = await _unitOfWork.AppointmentRepository.SearchByIdAsync(reviewerPictureModel.AppointmentId)
                ?? throw new ValidationException("Appointment does not exists");

            return appointment.PersonId;
        }

        public async Task<ReviewerPictureModel> InsertAsync(ReviewerPictureModel value)
        {
            _ = await _unitOfWork.ReviewerPictureRepository.SearchByIdAsync(value.Id)
                ?? throw new ValidationException("Appointment already exists");

            await ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfWork.ReviewerPictureRepository.InsertAsync(value);
        }

        public async Task<ReviewerPictureModel> SearchByIdAsync(int id)
        {
            return await _unitOfWork.ReviewerPictureRepository.SearchByIdAsync(id) 
                ?? throw new ValidationException("Appointment does not exists");
        }

        public async Task<ReviewerPictureModel> UpdateAsync(ReviewerPictureModel value)
        {
            _ = await _unitOfWork.ReviewerPictureRepository.SearchByIdAsync(value.Id)
                ?? throw new ValidationException("Appointment does not exists");

            await ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfWork.ReviewerPictureRepository.UpdateAsync(value);
        }

    }
}
