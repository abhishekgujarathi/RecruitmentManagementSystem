using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.Services;
using RecruitmentManagementSystem.API.Services.Jobs;
using System.Security.Claims;

namespace RecruitmentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : Controller
    {
        private readonly IInterviewService _interviewService;

        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }

        [Authorize(Roles = "Recruiter")]
        [HttpGet("jobs/{jobId}")]
        public async Task<IActionResult> GetJobInterviewRounds(Guid jobId)
        {
            try
            {
                var res = await _interviewService.GetJobInterviewRoundsAsync(jobId);
                return Ok(res);
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }

        [Authorize(Roles = "Recruiter, Interviewer")]
        [HttpGet("applications/{applicationId}")]
        public async Task<IActionResult> GetApplicationInterviewRounds(Guid applicationId)
        {
            try
            {
                var res = await _interviewService.GetApplicationInterviewRoundsAsync(applicationId);
                return Ok(res);
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }

        // update delete and insert all in one
        [Authorize(Roles = "Recruiter")]
        [HttpPut("jobs/{jobId}")]
        public async Task<IActionResult> UpsertJobInterviewRounds(Guid jobId, [FromBody] List<JobInterviewsUpsertDto> rounds)
        {
            try
            {
                await _interviewService.UpdateJobInterviewRoundsAsync(jobId, rounds);
                return Ok();
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }

        // update delete and insert all in one
        [Authorize(Roles = "Recruiter")]
        [HttpPut("applications/{applicationId}")]
        public async Task<IActionResult> UpsertApplicationInterviewRounds(Guid applicationId, [FromBody] List<ApplicationInterviewsUpsertDto> rounds)
        {
            try
            {
                await _interviewService.UpdateApplicationInterviewRoundsAsync(applicationId, rounds);
                return Ok();
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }


        //[Authorize(Roles = "Recruiter")]
        //[HttpPost("applications/rounds/{roundId}/panelMembers")]
        //public async Task<IActionResult> AddPanelMember(Guid roundId, [FromBody] EmployeeIdDto idDto)
        //{
        //    Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid recruiterId);
        //    await _interviewService.AddPanelMemberAsync(roundId, idDto.UserId, recruiterId);
        //    return Ok();
        //}

        //[Authorize(Roles = "Recruiter")]
        //[HttpDelete("applications/rounds/panelMembers/{panelMemberId}")]
        //public async Task<IActionResult> RemovePanelMember(Guid panelMemberId)
        //{
        //    await _interviewService.RemovePanelMemberAsync(panelMemberId);
        //    return NoContent();
        //}

        //[Authorize(Roles = "Recruiter")]
        //[HttpPatch("applications/rounds/{roundId}/schedule")]
        //public async Task<IActionResult> ScheduleInterview(Guid roundId,ScheduleInterviewDto dto)
        //{
        //    await _interviewService.ScheduleInterviewAsync(roundId, dto.ScheduledAt);
        //    return Ok();
        //}

        //[Authorize(Roles = "Recruiter")]
        //[HttpPatch("applications/rounds/{roundId}/meetLink")]
        //public async Task<IActionResult> AssignMeetLink(Guid roundId,AssignMeetLinkDto dto)
        //{
        //    await _interviewService.AssignMeetLinkAsync(roundId, dto.MeetLink);
        //    return Ok();
        //}
        [Authorize(Roles = "Recruiter")]
        [HttpPut("applications/rounds/")]
        public async Task<IActionResult> UpdateRound([FromBody] UpdateInterviewRoundDto dto)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                // parsing string to guid
                Guid.TryParse(userIdClaim?.Value, out Guid recruiterId);

                await _interviewService.UpdateInterviewRoundAsync(dto.RoundId, recruiterId, dto);
                return Ok();
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }

        [HttpPost("applications/rounds/{roundId}/notify")]
        public async Task<IActionResult> NotifyRound(Guid roundId)
        {
            try
            {

                await _interviewService.NotifyInterviewRoundAsync(roundId);
                return Ok();
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }


        // get interviewer own assigned interviews
        // GET /api/interviews/assigned
        [Authorize(Roles = "Interviewer")]
        [HttpGet("assigned")]
        public async Task<IActionResult> GetAssignedRounds()
        {
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid interviewerId);
            var rounds = await _interviewService.GetInterviewerAssignedRoundsAsync(interviewerId);
            return Ok(rounds);
        }


        //// GET all feedback for a round
        [HttpGet("applications/{applicationId}/feedbacks/all")]
        public async Task<IActionResult> GetAllFeedback(Guid applicationId)
        {
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid interviewerId);
            var feedback = await _interviewService.GetInterviewAllRoundSummariesAsync(applicationId);
            return Ok(feedback);
        }

        //// GET my feedback for a round
        [HttpGet("applications/{applicationId}/feedbacks")]
        public async Task<IActionResult> GetMyFeedback(Guid applicationId)
        {
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid interviewerId);
            var feedback = await _interviewService.GetInterviewRoundSummariesAsync(applicationId,interviewerId);
            return Ok(feedback);
        }

        //// PUT /api/interviews/{roundId}/feedback
        [HttpPut("{roundId}/feedback")]
        public async Task<IActionResult> UpsertFeedback(Guid roundId, [FromBody] UpdateInterviewFeedbackDto dto)
        {
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid interviewerId);
            await _interviewService.UpsertInterviewFeedbackAsync(roundId, interviewerId, dto);
            return NoContent();
        }

        [HttpPost("applications/rounds/{roundId}/reject")]
        public async Task<IActionResult> RejectRound(Guid roundId)
        {
            try
            {
                await _interviewService.RejectInterviewRoundAsync(roundId);
                return Ok(new { message = "Round rejected successfully" });
            }
            catch (Exception ex)
            {
                
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("applications/rounds/{roundId}/complete")]
        public async Task<IActionResult> CompleteRound(Guid roundId)
        {
            try
            {
                await _interviewService.CompleteInterviewRoundAsync(roundId);
                return Ok(new { message = "Round completed successfully" });
            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message });
            }
        }

    }

}
