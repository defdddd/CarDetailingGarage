using CDG.Validation.ModelsValidation;
using DataAccess.Data;
using DataAccess.UnitOfWork;
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
        public PersonManage(IUnitOfWork unitOfwork)
        {
            this._unitOfwork = unitOfwork;
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
            if (pageNumber < 1 || pageSize < 1) throw new Exception("Invalid data");

            return await _unitOfwork.PersonRepository.GetAllAsync(pageNumber, pageSize) ??
                throw new Exception("This table is empty");
        }

        public async Task<PersonModel> InsertAsync(PersonModel value)
        {
           var user = await _unitOfwork.PersonRepository.SearchByUserNameAsync(value.UserName);

           if (user != null) throw new Exception("User already exists");

           if (!PersonValidation.CheckProperties(value)) throw new Exception(PersonValidation.ErrorMessage);

           return await _unitOfwork.PersonRepository.InsertAsync(value);

        }

        public async Task<PersonModel> SearchByUserNameAsync(string userName)
        {
            return await _unitOfwork.PersonRepository.SearchByUserNameAsync(userName) ?? 
                throw new Exception("User does not exists");
        }

        public async Task<PersonModel> UpdateAsync(PersonModel value)
        {
            var user = await _unitOfwork.PersonRepository.SearchByUserNameAsync(value.UserName);

            if (user is null) throw new Exception("User does not exists");

            if (!PersonValidation.CheckProperties(value)) throw new Exception(PersonValidation.ErrorMessage);

            return await _unitOfwork.PersonRepository.UpdateAsync(value);
        }
    }
}
