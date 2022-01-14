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
    public class ReviewManage : IReviewManage
    {
        private IUnitOfWork _unitOfWork;
        private IValidator<ReviewModel> _validator;

        public ReviewManage(IUnitOfWork unitOfWork, IValidator<ReviewModel> validator)
        {
            _unitOfWork = unitOfWork ?? throw new NullReferenceException(nameof(unitOfWork));
            _validator = validator ?? throw new NullReferenceException(nameof(validator));
        }
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.ReviewRepository.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ReviewRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ReviewModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1) throw new Exception("Invalid data");

            return await _unitOfWork.ReviewRepository.GetAllAsync(pageNumber, pageSize) ??
                throw new Exception("This table is empty");
        }

        public async Task<IEnumerable<ReviewModel>> GetAllAsync()
        {
            var pageSize = await _unitOfWork.ReviewRepository.CountAsync() + 1;
            if (pageSize == 1) throw new Exception("This table is empty");

            return await _unitOfWork.ReviewRepository.GetAllAsync(1, pageSize);
        }

        public async Task<IEnumerable<ReviewModel>> GetMyReviewsAsync(int personId, int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1) throw new Exception("Invalid data");

            return await _unitOfWork.ReviewRepository.GetMyReviewsAsync(personId, pageNumber, pageSize) ??
                throw new Exception("This table is empty");
        }

        public async Task<ReviewModel> InsertAsync(ReviewModel value)
        {
            var Review = await _unitOfWork.ReviewRepository.SearchByIdAsync(value.Id);

            var appointment = await _unitOfWork.AppointmentRepository.SearchByIdAsync(value.AppointmentId);

            if (appointment == null) throw new Exception("The selected appointment does not exits");

            if (Review != null) throw new Exception("Review already exists");

            ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfWork.ReviewRepository.InsertAsync(value);
        }

        public async Task<ReviewModel> SearchByIdAsync(int id)
        {
            return await _unitOfWork.ReviewRepository.SearchByIdAsync(id) ?? throw new Exception("Review does not exists");
        }

        public async Task<ReviewModel> UpdateAsync(ReviewModel value)
        {
            var Review = await _unitOfWork.ReviewRepository.SearchByIdAsync(value.Id);

            var appointment = await _unitOfWork.AppointmentRepository.SearchByIdAsync(value.AppointmentId);

            if (appointment == null) throw new Exception("The selected appointment does not exits");

            if (Review is null) throw new Exception("Review does not exists");

            ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfWork.ReviewRepository.UpdateAsync(value);
        }
    }
}