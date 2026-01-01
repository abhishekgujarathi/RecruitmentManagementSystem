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

        [Authorize(Roles = "Recruiter")]
        [HttpGet("jobs/{jobId}/applications")]
        public async Task<IActionResult> GetJobApplications(Guid jobId)
        {
            try
            {

                var applications = await _recruitersService.GetJobApplicationsAsync(jobId);

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

        //called to get details of any applications
        [Authorize(Roles = "Recruiter")]
        [HttpGet("applications/{applicationId}")]
        public async Task<IActionResult> GetApplication(Guid applicationId)
        {
            //Candidate summary
            //Job info
            //Application status
            //Review progress

            var result = await _recruitersService.GetApplicationSummaryAsync(applicationId);

            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [Authorize(Roles = "Recruiter")]
        [HttpGet("applications/{applicationId}/cv")]
        public async Task<IActionResult> GetApplicationCV(Guid applicationId)
        {

            var result = await _recruitersService.GetApplicationCVAsync(applicationId);

            if (result is null)
                return NotFound();

            return File(result.Value.FileBytes, "application/pdf", result.Value.FileName);

        }

        // --- old not used now ---
        [Authorize(Roles = "Recruiter")]
        [HttpGet("candidate/{candidateProfileId}")]
        public async Task<IActionResult> GetCandidate(Guid candidateProfileId)
        {
            try
            {
                //var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                //Guid.TryParse(userIdClaim?.Value, out Guid recruiterId);

                //var result = await _recruitersService.GetRecruiterCandidate(candidateProfileId);

                //if (result is null)
                //    return NotFound();

                //return Ok(result);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // --- old not used mostly now ---


        // adding and removing recruiters
        [Authorize(Roles = "Recruiter")]
        [HttpGet("applications/{applicationId}/reviewers")]
        public async Task<IActionResult> GetAssignedReviewers(Guid applicationId)
        {
            var reviewers = await _recruitersService.GetAssignedReviewersAsync(applicationId);
            if (reviewers == null || !reviewers.Any())
                return NotFound(new { message = "No reviewers assigned." });

            return Ok(reviewers);
        }

        [Authorize(Roles = "Recruiter")]
        [HttpPost("applications/{applicationId}/reviewers")]
        public async Task<IActionResult> AssignReviewer(Guid applicationId, [FromBody] AssignReviewerRequestDto request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            // parsing string to guid
            Guid.TryParse(userIdClaim?.Value, out Guid recruiterId);

            // request contains ReviewerId and optional note
            var success = await _recruitersService.AssignReviewerAsync(applicationId,request.ReviewerId,recruiterId );

            if (!success)
                return BadRequest(new { message = "Failed to assign reviewer." });

            return Ok(new { message = "Reviewer assigned successfully." });
        }

    }
}
