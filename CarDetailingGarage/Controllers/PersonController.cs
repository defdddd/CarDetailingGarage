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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var pageSize = await _personManage.CountAsync() + 1;
                return Ok(await _personManage.GetAllAsync(1, pageSize));
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
               // var userId = int.Parse(User.FindFirst("Identifier")?.Value);
                return Ok(await _personManage.GetAllAsync(pageNumber, pageSize));
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

        [HttpPost("update")]
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

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
