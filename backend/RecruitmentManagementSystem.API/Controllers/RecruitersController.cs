using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;
using RecruitmentManagementSystem.API.Services;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

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


        // get list of employes to add as reviewer/interviewer
        [Authorize(Roles = "Recruiter")]
        [HttpGet("employees/{applicationId}")]
        public async Task<IActionResult> GetEmployees(Guid applicationId)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                // parsing string to guid
                Guid.TryParse(userIdClaim?.Value, out Guid recruiterId);


                var result = await _recruitersService.GetAllEmployeesForReviewAsync(applicationId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        }
    }
