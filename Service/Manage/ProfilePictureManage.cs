using CDG.Models;
using CDG.Service.Interfaces;
using CDG.Validation.ValidatorTool;
using DataAccess.UnitOfWork;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Service.Manage
{
    public class ProfilePictureManage : IProfilePictureManage
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IValidator<ProfilePictureModel> _validator;

        public ProfilePictureManage(IUnitOfWork unitOfWork, IValidator<ProfilePictureModel> validator)
        {
            _unitOfwork = unitOfWork ?? throw new NullReferenceException(nameof(unitOfWork));
            _validator = validator ?? throw new NullReferenceException(nameof(validator));
        }
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfwork.ProfilePictureRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<ProfilePictureModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProfilePictureModel>> GetAllAsync()
        {
            return await _unitOfwork.ProfilePictureRepository.GetAllAsync(1, 10);
        }

        public async Task<ProfilePictureModel> InsertAsync(ProfilePictureModel value)
        {
            if (await SearchByIdAsync(value.UserId) != null)
                throw new ValidationException("ProfilePicture already exists");

            await ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfwork.ProfilePictureRepository.InsertAsync(value);
        }

        public async Task<ProfilePictureModel> SearchByIdAsync(int id)
        {
            return await _unitOfwork.ProfilePictureRepository.SearchByIdAsync(id);
        }

        public async Task<ProfilePictureModel> UpdateAsync(ProfilePictureModel value)
        {
            _ = await SearchByIdAsync(value.UserId)
               ?? throw new ValidationException("ProfilePicture does not exists");

            await ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfwork.ProfilePictureRepository.UpdateAsync(value);
        }
    }
}
