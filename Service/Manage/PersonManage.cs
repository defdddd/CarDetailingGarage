﻿using CDG.Validation.ValidatorTool;
using DataAccess.Data;
using DataAccess.UnitOfWork;
using FluentValidation;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manage
{
    public class PersonManage : IPersonManage
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IValidator<PersonModel> _validator;

        public PersonManage(IUnitOfWork unitOfWork, IValidator<PersonModel> validator)
        {
            _unitOfwork = unitOfWork ?? throw new NullReferenceException(nameof(unitOfWork));
            _validator = validator ?? throw new NullReferenceException(nameof(validator));
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfwork.PersonRepository.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfwork.PersonRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PersonModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1) throw new ValidationException("Invalid data");

            return await _unitOfwork.PersonRepository.GetAllAsync(pageNumber, pageSize) ??
                throw new ValidationException("This table is empty");
        }

        public async Task<IEnumerable<PersonModel>> GetAllAsync()
        {

            var pageSize = await _unitOfwork.PersonRepository.CountAsync() + 1;
            if(pageSize == 1) throw new ValidationException("This table is empty");

            return await _unitOfwork.PersonRepository.GetAllAsync(1, pageSize);
        }

        public async Task<PersonModel> InsertAsync(PersonModel value)
        {
            if (await _unitOfwork.PersonRepository.CheckUserNameAsync(value.UserName))
                throw new ValidationException("User already exists");

            await ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfwork.PersonRepository.InsertAsync(value);

        }

        public async Task<PersonModel> SearchByIdAsync(int id)
        {
            return await _unitOfwork.PersonRepository.SearchByIdAsync(id) ??
                 throw new ValidationException("User does not exists");
        }

        public async Task<PersonModel> SearchByUserNameAsync(string userName)
        {
            return await _unitOfwork.PersonRepository.SearchByUserNameAsync(userName) ?? 
                throw new ValidationException("User does not exists");
        }

        public async Task<PersonModel> UpdateAsync(PersonModel value)
        {
            if (!await _unitOfwork.PersonRepository.CheckUserNameAsync(value.UserName))
                throw new ValidationException("User does not exists");

            await ValidatorTool.FluentValidate(_validator, value);

            return await _unitOfwork.PersonRepository.UpdateAsync(value);
        }
    }
}
