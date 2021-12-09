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
        public async Task<int> CountAsync() => await _unitOfwork.PersonRepository.CountAsync();
        public async Task DeleteAsync(int id) => await _unitOfwork.PersonRepository.DeleteAsync(id);     
        public async Task<IEnumerable<PersonModel>> GetAllAsync(int pageNumber, int pageSize) =>       
            await _unitOfwork.PersonRepository.GetAllAsync(pageNumber, pageSize) ;
        public async Task<PersonModel> InsertAsync(PersonModel value) =>
            await _unitOfwork.PersonRepository.InsertAsync(value);
        public async Task<PersonModel> SearchByUserNameAsync(string userName)
        {
            var user = await _unitOfwork.PersonRepository.SearchByUserNameAsync(userName);
            return user ?? throw new Exception("User not Found");
        }
        public async Task<PersonModel> UpdateAsync(PersonModel value)
        {            
            return await _unitOfwork.PersonRepository.UpdateAsync(value) ?? throw new NullReferenceException("User not Found");
        }
    }
}
