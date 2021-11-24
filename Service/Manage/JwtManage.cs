﻿using DB.Repository.Interfaces;
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
        private readonly IPersonRepo personRepo;
        private readonly string myKey;

        public JwtManage(IPersonRepo personRepo, string myKey)
        {
            this.personRepo = personRepo;
            this.myKey = myKey;
        }

        public bool IsValidUserNameAndPassowrd(AuthModel authModel)
        {
            var user = personRepo.Search(authModel.UserName);

            if (user == null) return false;
            if (user.Password != authModel.Password) return false;
            return true;
        }
        public dynamic GenerateToken(AuthModel authModel)
        {
            var username = authModel.UserName;
            var user = personRepo.Search(username);

            var claims = new List<Claim>
            {
                new Claim("UserName",user.UserName),
                new Claim("Identifier",user.Id+""),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(7)).ToUnixTimeSeconds().ToString())
            };

            if (user.IsAdmin)
                claims.Add(new Claim("Role", "Admin"));
            else
                claims.Add(new Claim("Role", "User"));

            var token = new JwtSecurityToken
                (
                   new JwtHeader
                    (
                        new SigningCredentials
                        (
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(myKey)),
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
    }
}