using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.Services;

namespace RecruitmentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewersController:Controller
    {
        private readonly IReviewersService _reviewersService;

        public ReviewersController(IReviewersService reviewersService)
        {
            _reviewersService = reviewersService;

        }

        [HttpGet]
        public async Task<IActionResult> GetReviewers()
        {
            var result = await _reviewersService.GetReviewersAsync();

            return Ok(result);
        }
        
    }
}
