using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Manage;
using System;
using System.Threading.Tasks;

namespace CarDetailingGarage
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManage _authManage;
        public AuthController(IAuthManage authManage)
        {
            this._authManage = authManage;
        }

        // POST api/<AuthController>
        [HttpPost]
        public async Task<IActionResult> Create(AuthModel authModel)
        {
            try
            {
                return Ok(await _authManage.GenerateToken(authModel));
            }
            catch (Exception e1)
            {

                return BadRequest(e1.Message);
            }        
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            try
            {
                return Ok(await _authManage.CheckEmailAsync(email));
            }
            catch (Exception e1)
            {

                return BadRequest(e1.Message);
            }
        }
        [HttpGet("username/{username}")]
        public async Task<IActionResult> CheckUserName(string userName)
        {
            try
            {
                return Ok(await _authManage.CheckUserNameAsync(userName));
            }
            catch (Exception e1)
            {

                return BadRequest(e1.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PersonModel person)
        {
            try
            {
                return Ok(await _authManage.RegisterAsync(person));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
