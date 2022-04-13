
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Pictures;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDetailingGarage.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GaragePictureController : ControllerBase
    {
        private readonly IGaragePictureManage _garagePictureManage;

        public GaragePictureController(IGaragePictureManage garagePictureManage)
        {
            _garagePictureManage = garagePictureManage;
        }

        // GET: api/<PersonController>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _garagePictureManage.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<PersonController>/5
        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                return Ok(await _garagePictureManage.GetAllAsync(pageNumber, pageSize));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Search(int id)
        {
            try
            {
                return Ok(await _garagePictureManage.SearchByIdAsync(id));
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
                return Ok(await _garagePictureManage.CountAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("pictures/{appointmentId}")]
        public async Task<IActionResult> AppointmentPicture(int appointmentId)
        {
            try
            { 
               return Ok(await _garagePictureManage.GetAppointmentPicturesAsync(appointmentId, 1, await _garagePictureManage.CountAsync() + 1));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<PersonController>
        [HttpPost("insert")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Insert([FromBody] GaragePictureModel garagePicture)
        {
            try
            {
                return Ok(await _garagePictureManage.InsertAsync(garagePicture));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] GaragePictureModel garagePicture)
        {
            try
            {
               return Ok(await _garagePictureManage.UpdateAsync(garagePicture));
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
                await _garagePictureManage.DeleteAsync(id);
                return Ok();            
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}

