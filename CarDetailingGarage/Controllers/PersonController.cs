using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Manage;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDetailingGarage.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin,User")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonManage _personManage;

        public PersonController(IPersonManage personManage)
        {
            this._personManage = personManage;
        }
        // GET: api/<PersonController>
        [HttpGet("all")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _personManage.GetAllAsync());
            }
            catch(Exception e)
            {       
                return BadRequest(e.Message);
            }
        }


        // GET api/<PersonController>/5
        [HttpGet("{pageNumber}/{pageSize}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetAll(int pageNumber,int pageSize)
        {
            try
            {
                return Ok(await _personManage.GetAllAsync(pageNumber, pageSize));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<PersonController>/5
        [HttpGet("count")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetSizeOf()
        {
            try
            {               
                return Ok(await _personManage.CountAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("username/{userName}")]
        public async Task<IActionResult> Search(string userName)
        {
            try
            {
                var person = await _personManage.SearchByUserNameAsync(userName);
                await CheckRole(person);
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> SearchId(int id)
        {
            try
            {
                var person = await _personManage.SearchByIdAsync(id);
                await CheckRole(person);
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST api/<PersonController>
        [HttpPost("insert")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Insert([FromBody] PersonModel person)
        {
            try
            {
                return Ok(await _personManage.InsertAsync(person));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] PersonModel person)
        {
            try
            {
                await CheckRole(person);

                return Ok(await _personManage.UpdateAsync(person));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _personManage.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private async Task CheckRole(PersonModel person)
        {
            var userId = int.Parse(User.FindFirst("Identifier")?.Value);
            var user = await _personManage.SearchByIdAsync(person.Id);
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userId.Equals(person.Id) && !user.IsAdmin.Equals(person.IsAdmin))
                throw new Exception("You can't edit your role, contact the owner for this task");

            if (!(role == "Admin" || person.Id == userId))
                throw new Exception("You don't have access to modify, view or insert this value");

        }

    }
}
