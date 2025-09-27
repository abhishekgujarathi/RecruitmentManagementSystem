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
    }
}
