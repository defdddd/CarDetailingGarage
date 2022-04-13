using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewManage _reviewManage;

        public ReviewController(IReviewManage reviewManage)
        {
            _reviewManage = reviewManage;
        }


        // GET: api/<PersonController>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _reviewManage.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("MyRev")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> MyReviews()
        {
            try
            {
                var userId = int.Parse(User.FindFirst("Identifier")?.Value);
                return Ok(await _reviewManage.GetMyReviewsAsync(userId, 1, await _reviewManage.CountAsync() + 1));
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
                return Ok(await _reviewManage.GetAllAsync(pageNumber, pageSize));
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
                return Ok(await _reviewManage.SearchByIdAsync(id));
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
                return Ok(await _reviewManage.CountAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<PersonController>
        [HttpPost("insert")]
        [Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> Insert([FromBody] ReviewModel Review)
        {
            try
            {
                CheckRole(Review);

                return Ok(await _reviewManage.InsertAsync(Review));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        [Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> Update([FromBody] ReviewModel Review)
        {

            try
            {
                CheckRole(Review);

                return Ok(await _reviewManage.UpdateAsync(Review));
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
                var Review = await _reviewManage.SearchByIdAsync(id);

                CheckRole(Review);

                await _reviewManage.DeleteAsync(id);

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private void CheckRole(ReviewModel Review)
        {

            var userId = int.Parse(User.FindFirst("Identifier")?.Value);

            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (!(role == "Admin" || Review.UserId == userId))
                throw new Exception("You don t have access to modify or insert this value");

        }

    }
}
