using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;
using RecruitmentManagementSystem.API.Services;
using RecruitmentManagementSystem.API.Services.Candidate;
using System.Security.Claims;

namespace RecruitmentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : Controller
    {
        private readonly IApplicationsService _applicationsService;

        public ApplicationsController(IApplicationsService applicationsService)
        {
            _applicationsService = applicationsService;
        }


        // for candidate to apply to job
        // POST /api/applications/jobs/{jobId}
        [Authorize(Roles = "Candidate")]
        [HttpPost("jobs/{jobId}")]
        public async Task<IActionResult> ApplyToJob(Guid jobId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim?.Value, out Guid userId);

            bool success = await _applicationsService.ApplyToJobAsync(userId, jobId);

            if (!success)
                return BadRequest("Failed to apply for the job or already applied.");

            return Ok(new { message = "Application submitted successfully." });
        }

        //GET /api/applications/job/{jobId}
        [Authorize(Roles = "Recruiter")]
        [HttpGet("jobs/{jobId}")]
        public async Task<IActionResult> GetJobApplications(Guid jobId)
        {
            try
            {

                var applications = await _applicationsService.GetJobApplicationsAsync(jobId);

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

        //GET /api/applications/{applicationId}
        //called to get details of any applications
        [Authorize(Roles = "Recruiter, Reviewer")]
        [HttpGet("{applicationId}")]
        public async Task<IActionResult> GetApplication(Guid applicationId)
        {
            //Candidate summary
            //Job info
            //Application status
            //Review progress

            var result = await _applicationsService.GetApplicationSummaryAsync(applicationId);

            if (result is null)
                return NotFound();
            return Ok(result);
        }




        //GET /api/applications/{applicationId}/cv
        [Authorize(Roles = "Recruiter,Reviewer")]
        [HttpGet("{applicationId}/cv")]
        public async Task<IActionResult> GetApplicationCV(Guid applicationId)
        {

            var result = await _applicationsService.GetApplicationCVAsync(applicationId);

            if (result is null)
                return NotFound();

            return File(result.Value.FileBytes, "application/pdf", result.Value.FileName);

        }


        //GET /api/applications/{applicationId}/reviewers
        [Authorize(Roles = "Recruiter")]
        [HttpGet("{applicationId}/reviewers")]
        public async Task<IActionResult> GetAssignedReviewers(Guid applicationId)
        {
            var reviewers = await _applicationsService.GetAssignedReviewersAsync(applicationId);
            if (reviewers == null || !reviewers.Any())
                return NotFound(new { message = "No reviewers assigned." });

            return Ok(reviewers);
        }


        // to add reviewer
        //POST /api/applications/{applicationId}/reviewers
        [Authorize(Roles = "Recruiter")]
        [HttpPost("{applicationId}/reviewers")]
        public async Task<IActionResult> AssignReviewer(Guid applicationId, [FromBody] AssignReviewerRequestDto request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            // parsing string to guid
            Guid.TryParse(userIdClaim?.Value, out Guid recruiterId);

            // request contains ReviewerId and optional note
            var success = await _applicationsService.AssignReviewerAsync(applicationId, request.ReviewerId, recruiterId);

            if (!success)
                return BadRequest(new { message = "Failed to assign reviewer." });

            return Ok(new { message = "Reviewer assigned successfully." });
        }


        //GET /api/applications/assigned
        // list all applications given to a reviewer
        [Authorize(Roles = "Reviewer")]
        [HttpGet("assigned")]
        public async Task<IActionResult> GetApplications()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim.Value, out Guid revId);
            var result = await _applicationsService.GetApplicationsAsync(revId);

            return Ok(result);
        }



        //POST /api/applications/{applicationId}/skills
        //[Authorize(Roles = "Recruiter,Interviewer")]
        //[HttpPost("{applicationId}/skills")]
        //public async Task<IActionResult> AddCandidateSkills(Guid applicationId, [FromBody] CandidateSkillsDto skillsDto)
        //{
        //    var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        //    Guid.TryParse(userIdClaim?.Value, out Guid userId);

        //    var success = await _applicationsService.AddCandidateSkillsAsync(userId, applicationId, skillsDto);
        //    var success = new bool { };
        //    if (!success)
        //        return BadRequest("Failed to save skills.");

        //    return Ok(new { message = "Skills saved successfully." });
        //}


        //GET /api/applications/{applicationId}/skills
        [HttpGet("{applicationId}/skills")]
        public async Task<IActionResult> GetJobSkills(Guid applicationId)
        {
            // new method to get userid in one line
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId);
            var result = await _applicationsService.GetReviewSkillsAsync(applicationId,userId);
            return Ok(result);
        }

        //POST /api/applications/{applicationId}/skills
        [HttpPost("{applicationId}/skills")]
        [Authorize(Roles = "Reviewer,Interviewer")]
        public async Task<IActionResult> PostJobSkills(
            Guid applicationId,
            [FromBody] List<UpdateReviewSkillDto> skills)
        {
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId);

            await _applicationsService.UpdateReviewSkillsAsync(applicationId, userId, skills);
            return NoContent();
        }


        //GET /api/applications/{id}/reviews
        [Authorize(Roles = "Recruiter")]
        [HttpGet("{applicationId}/reviews/all")]
        public async Task<IActionResult> GetAllReviews(Guid applicationId)
        {

            var result = await _applicationsService.GetAllReviewsAsync(applicationId);
            return Ok(result);
        }

        //GET /api/applications/{id}/reviews get user specific only
        [Authorize(Roles = "Reviewer")]
        [HttpGet("{applicationId}/reviews")]
        public async Task<IActionResult> GetMyReviews(Guid applicationId)
        {

            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId);
            var result = await _applicationsService.GetMyCommentsAsync(applicationId, userId);
            return Ok(result);
        }

        // PUT /api/applications/{id}/reviews
        [HttpPut("{applicationId}/reviews")]
        [Authorize(Roles = "Reviewer")]
        public async Task<IActionResult> UpdateMyReviews(Guid applicationId, [FromBody] List<UpdateReviewCommentDto> comments)
        {

            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId);
            await _applicationsService.UpdateMyCommentsAsync(applicationId, userId, comments);
            return NoContent();
        }


    }
}
