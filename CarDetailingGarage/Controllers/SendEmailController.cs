using CDG.Models;
using CDG.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDetailingGarage.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class SendEmailController : ControllerBase
    {
        IEmailService _emailService;
        public SendEmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("forgotPasswordToken/{email}/{code}")]
        public async Task<IActionResult> ForgotPasswordToken(string email, string code)
        {
            try
            {
                return Ok(await _emailService.GetTokenForForgotPasswordAsync(email, code));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<SendEmailController>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EmailModel value)
        {
            try
            {
                await _emailService.SendCratedEmailAsync(value);
                return Ok(value);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("appointment")]
        [Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> Appointment([FromBody] EmailModel value)
        {
            try
            {
                await _emailService.SendAppointmentMadeEmailAsync(value);
                return Ok(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("finished")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Finished([FromBody] EmailModel value)
        {
            try
            {
                await _emailService.SendAppointmentFinishedEmailAsync(value);
                return Ok(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("forgotPasswordSend")]
        public async Task<IActionResult> ForgotPasswordSend([FromBody] EmailModel value)
        {
            try
            {
                await _emailService.SendForgotPasswordEmailAsync(value);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
