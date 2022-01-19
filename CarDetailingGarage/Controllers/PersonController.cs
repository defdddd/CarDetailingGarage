using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Manage;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDetailingGarage.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonManage _personManage;

        public PersonController(IPersonManage personManage)
        {
            this._personManage = personManage;
        }
        // GET: api/<PersonController>
        [HttpGet("all")]
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

        [HttpGet("{userName}")]
        public async Task<IActionResult> Search(string userName)
        {
            try
            {
                return Ok(await _personManage.SearchByUserNameAsync(userName));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

            // POST api/<PersonController>
            [HttpPost("insert")]
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
                return Ok(await _personManage.UpdateAsync(person));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
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
    }
}
