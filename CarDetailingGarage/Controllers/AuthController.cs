using Microsoft.AspNetCore.Mvc;
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

namespace CarDetailingGarage
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtManage _jwtManage;
        public AuthController(IJwtManage jwtManage)
        {
            this._jwtManage = jwtManage;
        }

        // POST api/<AuthController>
        [HttpPost]
        public async Task<IActionResult> Create(AuthModel authModel)
        {
            if (await _jwtManage.IsValidUserNameAndPassowrd(authModel))
            {
                return Ok(await _jwtManage.GenerateToken(authModel));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            try
            {
                return Ok(await _jwtManage.CheckEmailAsync(email));
            }
            catch (Exception e1)
            {

                return BadRequest(e1.Message);
            }
        }

    }
}
