using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Services;
using System.Security.Claims;

namespace RecruitmentManagementSystem.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class RecruitersController : Controller
    {
        private readonly IRecruitersService _recruitersService;

        public RecruitersController(IRecruitersService recruitersService)
        {
            _recruitersService = recruitersService;
        }

        [Authorize(Roles = "Recruiter")]
        [HttpPost("job")]
        public async Task<ActionResult<JobResponseDto>> CreateJobAsync([FromBody] JobCreateRequestDto request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            // parsing string to guid
            Guid.TryParse(userIdClaim?.Value, out Guid recruiterId);


            var createdJob = await _recruitersService.CreateJobAsync(request, recruiterId);

            // rror in db or fields 
            if (createdJob == null)
            {
                return BadRequest("job creation failed.....");
            }

            return Ok(createdJob);
        }


        [Authorize(Roles = "Recruiter")]
        [HttpPatch("jobs/{jobId}")]
        public async Task<IActionResult> UpdateJob(Guid jobId, [FromBody] JobUpdateRequestDto request)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                // parsing string to guid
                Guid.TryParse(userIdClaim?.Value, out Guid recruiterId);
                var result = await _recruitersService.UpdateJobAsync(jobId, request, recruiterId);

                if (result == null)
                {
                    return NotFound(new { message = "Job not found or invalid job type" });
                }

                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [Authorize(Roles = "Recruiter")]
        [HttpDelete("jobs/{jobId}")]
        public async Task<IActionResult> DeleteJob(Guid jobId)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                // parsing string to guid
                Guid.TryParse(userIdClaim?.Value, out Guid recruiterId);


                var result = await _recruitersService.DeleteJobAsync(jobId, recruiterId);

                if (!result)
                {
                    return NotFound(new { message = "Job not found" });
                }

                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Recruiter")]
        [HttpGet("jobs/{jobId}/applications")]
        public async Task<IActionResult> GetJobApplications(Guid jobId)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                Guid.TryParse(userIdClaim?.Value, out Guid recruiterId);

                var applications = await _recruitersService.GetJobApplicationsAsync(jobId, recruiterId);

                if (applications == null || !applications.Any())
                    return NotFound(new { message = "No applications found for this job." });

                return Ok(applications);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
