using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.Common;
using RecruitmentManagementSystem.API.Models;
using RecruitmentManagementSystem.API.Services.Jobs;
using System.Security.Claims;
namespace RecruitmentManagementSystem.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;

        public JobsController(IJobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetJobsAsync()
        {

            var userRoleType = UserExtensions.GetUserRoleType(User);


            var userIdClaims = User.FindFirst(ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaims?.Value, out Guid userId);


            var jobs = await _jobsService.GetJobsAsync(userId, userRoleType);


            return Ok(jobs);
        }

        [HttpGet("{jobID}")]
        public async Task<ActionResult> GetJobAsync([FromRoute] Guid jobID)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            // parsing string to guid
            Guid.TryParse(userIdClaim?.Value, out Guid userId);

            var userRoleType = UserExtensions.GetUserRoleType(User);


            var job = await _jobsService.GetJobAsync(jobID,userId,userRoleType);

            if (job is null)
            {
                return NotFound("Invalid job id");
            }


            return Ok(job);
        }

    }
}
