using DataAccess.Data;
using DataAccess.UnitOfWork;
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
    public class JwtManage : IJwtManage
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly string _myKey;

        public JwtManage(IUnitOfWork unitOfwork, string _myKey)
        {
            this._unitOfwork = unitOfwork;
            this._myKey = _myKey;
        }

        public async Task<bool> IsValidUserNameAndPassowrd(AuthModel authModel)
        {
            var user = await _unitOfwork.PersonRepository.SearchByUserNameAsync(authModel.UserName);
            if (user == null) return false;
            if (user.Password != authModel.Password) return false;
            return true;
        }
        public async Task<dynamic> GenerateToken(AuthModel authModel)
        {
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

        public async Task<bool> CheckEmailAsync(string email)
        {
            if (!await _unitOfwork.PersonRepository.CheckEmailAsync(email))
                throw new Exception("Email does not exits");
            return true;
        }
    }
}
