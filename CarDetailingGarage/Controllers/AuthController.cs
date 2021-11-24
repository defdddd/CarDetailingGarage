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
        private readonly IJwtManage jwtManage;
        public AuthController(IJwtManage jwtManage)
        {
            this.jwtManage = jwtManage;
        }


        // POST api/<AuthController>
        [HttpPost]
        public IActionResult Create(AuthModel authModel)
        {
            if (jwtManage.IsValidUserNameAndPassowrd(authModel))
            {
                return new ObjectResult(jwtManage.GenerateToken(authModel));
            }
            else
            {
                return BadRequest();
            }
        }
     
    }
}
