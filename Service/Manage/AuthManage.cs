using CDG.Validation.Model.Validator;
using CDG.Validation.ValidatorTool;
using DataAccess.Data;
using DataAccess.UnitOfWork;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Models;
using Service.Manage;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manage
{
    public class AuthManage : IAuthManage
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly string _myKey;

        public AuthManage(IUnitOfWork unitOfwork, string _myKey)
        {
            this._unitOfwork = unitOfwork;
            this._myKey = _myKey;
        }

        public async Task<bool> IsValidUserNameAndPassowrd(AuthModel authModel)
        {
            var user = await _unitOfwork.PersonRepository.SearchByUserNameAsync(authModel.UserName) ??
                throw new ValidationException("Invalid username or password");

            if (user.Password != authModel.Password) 
                throw new ValidationException("Invalid username or password"); 
            return true;
        }
        public async Task<dynamic> GenerateToken(AuthModel authModel)
        {
            await IsValidUserNameAndPassowrd(authModel);
            var username = authModel.UserName;
            var user = await _unitOfwork.PersonRepository.SearchByUserNameAsync(username);

            var claims = new List<Claim>
            {
                new Claim("Username",user.UserName),
                new Claim("Identifier",user.Id+""),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(7)).ToUnixTimeSeconds().ToString())
            };

            if (user.IsAdmin)
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            else
                claims.Add(new Claim(ClaimTypes.Role, "User"));

            var token = new JwtSecurityToken
                (
                   new JwtHeader
                    (
                        new SigningCredentials
                        (
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_myKey)),
                            SecurityAlgorithms.HmacSha256
                        )
                     ),
                    new JwtPayload(claims)
                );
            var output = new
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = user.UserName
            };

            return output;
        }

        public async Task<bool> CheckEmailAsync(string email) =>
            await _unitOfwork.PersonRepository.CheckEmailAsync(email);

        public async Task<bool> CheckUserNameAsync(string userName) =>
            await _unitOfwork.PersonRepository.CheckUserNameAsync(userName);

        public async Task<bool> RegisterAsync(PersonModel person)
        {
             if(await _unitOfwork.PersonRepository.CheckUserNameAsync(person.UserName))
                throw new ValidationException("User already exists");

            person.IsAdmin = false;

            var validator = new PersonValidator();

            await ValidatorTool.FluentValidate(validator, person);

            return null != await _unitOfwork.PersonRepository.InsertAsync(person);
        }
    }
}
