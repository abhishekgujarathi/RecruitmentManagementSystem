using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.Services;
using System.Security.Claims;

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

        // returns list of all reviewers
        [HttpGet("{applicationId:guid}")]
        public async Task<IActionResult> GetReviewers([FromQuery] Guid applicationId)
        {
            var result = await _reviewersService.GetReviewersAsync(applicationId);

            return Ok(result);
        }


        // list all applications given to a reviewer
        [HttpGet("applications")]
        public async Task<IActionResult> GetApplications( )
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim.Value, out Guid revId);
            var result = await _reviewersService.GetApplicationsAsync(revId);

            return Ok(result);
        }

    }
}
