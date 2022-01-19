using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDetailingGarage.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentManage _appointmentManage;

        public AppointmentController(IAppointmentManage appointmentManage)
        {
            _appointmentManage = appointmentManage;
        }


        // GET: api/<PersonController>
        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _appointmentManage.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("dateVal/{date}")]
        public async Task<IActionResult> CheckDate(DateTime date)
        {
            try
            {
                return Ok(await _appointmentManage.CheckDateAvailability(date));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("MyApp/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> MyAppointments(int pageNumber, int pageSize)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("Identifier")?.Value);

                return Ok(await _appointmentManage.GetMyAppointmentsAsync(userId, pageNumber, pageSize));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // GET api/<PersonController>/5
        [HttpGet("{pageNumber}/{pageSize}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                return Ok(await _appointmentManage.GetAllAsync(pageNumber, pageSize));
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
                return Ok(await _appointmentManage.SearchByIdAsync(id));
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
                return Ok(await _appointmentManage.CountAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<PersonController>
        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] AppointmentModel appointment)
        {
            try
            {
                CheckRole(appointment);

                return Ok(await _appointmentManage.InsertAsync(appointment));     
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] AppointmentModel appointment)
        {
            try
            {
                CheckRole(appointment);

                return Ok(await _appointmentManage.UpdateAsync(appointment));
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
                var appointment = await _appointmentManage.SearchByIdAsync(id);

                CheckRole(appointment);

                await _appointmentManage.DeleteAsync(id);

                return Ok();                    
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private void CheckRole(AppointmentModel appointment)
        {
            var userId = int.Parse(User.FindFirst("Identifier")?.Value);

            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (!(role == "Admin" || appointment.PersonId == userId))
                throw new Exception("You don t have access to modify or insert this value");

        }

    }
}
