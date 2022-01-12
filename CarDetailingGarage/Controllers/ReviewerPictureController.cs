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
    public class ReviewerPictureController : ControllerBase
    {
        private readonly IReviewerPictureManage _reviewerPictureManage;

        public ReviewerPictureController(IReviewerPictureManage reviewerPictureManage)
        {
            _reviewerPictureManage = reviewerPictureManage;
        }


        // GET: api/<PersonController>
        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _reviewerPictureManage.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{reviewId}/{appointmentId}")]
        public async Task<IActionResult> GetReviewPicture(int reviewId, int appointmentId)
        {
            try
            {
                return Ok(await _reviewerPictureManage.GetReviewPicturesAsync(reviewId,appointmentId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MyReviewerPictures(int pageNumber, int pageSize)
        {
            try
            {
                return Ok(await _reviewerPictureManage.GetAllAsync(pageNumber, pageSize));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Search(int id)
        {
            try
            {
                return Ok(await _reviewerPictureManage.SearchByIdAsync(id));
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
                return Ok(await _reviewerPictureManage.CountAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<PersonController>
        [HttpPost("insert")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Insert([FromBody] ReviewerPictureModel ReviewerPicture)
        {
            try
            {
                await CheckRole(ReviewerPicture);

                return Ok(await _reviewerPictureManage.InsertAsync(ReviewerPicture));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        [Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> Update([FromBody] ReviewerPictureModel ReviewerPicture)
        {

            try
            {
                await CheckRole(ReviewerPicture);

                return Ok(await _reviewerPictureManage.UpdateAsync(ReviewerPicture));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ReviewerPicture = await _reviewerPictureManage.SearchByIdAsync(id);

                await CheckRole(ReviewerPicture);

                await _reviewerPictureManage.DeleteAsync(id);

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private async Task CheckRole(ReviewerPictureModel reviewerPictureModel)
        {
            var userId = int.Parse(User.FindFirst("Identifier")?.Value);

            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (!(role == "Admin" || await _reviewerPictureManage.GetUserId(reviewerPictureModel) == userId))
                throw new Exception("You don t have access to modify or insert this value");

        }

    }
}
