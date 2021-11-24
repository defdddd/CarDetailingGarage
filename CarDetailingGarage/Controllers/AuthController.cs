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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
                return new ObjectResult(await _jwtManage.GenerateToken(authModel));
            }
            else
            {
                return BadRequest();
            }
        }
     
    }
}
