using CDG.Models;
using CDG.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDetailingGarage.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfilePictureController : ControllerBase
    {
        private readonly IProfilePictureManage _manage;
        public ProfilePictureController( IProfilePictureManage manage)
        {
            _manage = manage;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _manage.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("insert")]
        [Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> Insert([FromBody] ProfilePictureModel value)
        {
            try
            {
                CheckRole(value);

                return Ok(await _manage.InsertAsync(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        [Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> Update([FromBody] ProfilePictureModel value)
        {

            try
            {
                CheckRole(value);

                return Ok(await _manage.UpdateAsync(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> SearchbyId(int id)
        {
            try
            { 
                return Ok(await _manage.SearchByIdAsync(id));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var value  = (ProfilePictureModel[]) await _manage.GetAllAsync();

                CheckRole(value[0]);

                await _manage.DeleteAsync(id);

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private void CheckRole(ProfilePictureModel value)
        {

            var userId = int.Parse(User.FindFirst("Identifier")?.Value);

            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (!(role == "Admin" || value.UserId == userId))
                throw new Exception("You don t have access to modify or insert this value");

        }
    } 
     
}
