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

        [Authorize(Roles = "Recruiter")]
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


        [Authorize(Roles = "Recruiter")]
        [HttpPost("applications/rounds/{roundId}/panelMembers")]
        public async Task<IActionResult> AddPanelMember(Guid roundId, [FromBody] EmployeeIdDto idDto)
        {
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid recruiterId);
            await _interviewService.AddPanelMemberAsync(roundId, idDto.UserId, recruiterId);
            return Ok();
        }

        [Authorize(Roles = "Recruiter")]
        [HttpDelete("applications/rounds/panelMembers/{panelMemberId}")]
        public async Task<IActionResult> RemovePanelMember(Guid panelMemberId)
        {
            await _interviewService.RemovePanelMemberAsync(panelMemberId);
            return NoContent();
        }

        [Authorize(Roles = "Recruiter")]
        [HttpPatch("applications/rounds/{roundId}/schedule")]
        public async Task<IActionResult> ScheduleInterview(Guid roundId,ScheduleInterviewDto dto)
        {
            await _interviewService.ScheduleInterviewAsync(roundId, dto.ScheduledAt);
            return Ok();
        }

        [Authorize(Roles = "Recruiter")]
        [HttpPatch("applications/rounds/{roundId}/meetLink")]
        public async Task<IActionResult> AssignMeetLink(Guid roundId,AssignMeetLinkDto dto)
        {
            await _interviewService.AssignMeetLinkAsync(roundId, dto.MeetLink);
            return Ok();
        }



    }
}
