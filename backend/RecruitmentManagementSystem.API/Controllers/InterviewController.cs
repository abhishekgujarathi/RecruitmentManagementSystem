using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.Services;
using RecruitmentManagementSystem.API.Services.Jobs;

namespace RecruitmentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController:Controller
    {
        private readonly IInterviewService _interviewService;

        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }

        [HttpGet("jobs/{jobId}")]
        public async Task<IActionResult> GetJobInterviewRounds(Guid jobId)
        {
            try
            {
                var res = await _interviewService.GetJobInterviewRoundsAsync(jobId);
                return Ok(res);
            }
            catch(Exception er)
            {
                return BadRequest(er.Message);
            }
        }

        [HttpGet("applications/{applicationId}")]
        public async Task<IActionResult> GetApplicationInterviewRounds(Guid applicationId)
        {
            try
            {
                var res = await _interviewService.GetApplicationInterviewRoundsAsync(applicationId);
                return Ok(res);
            }
            catch(Exception er)
            {
                return BadRequest(er.Message);
            }
        }

    }
}
