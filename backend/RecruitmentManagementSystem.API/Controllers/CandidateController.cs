using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.Dtos;
using RecruitmentManagementSystem.API.Services;
using System.Security.Claims;

namespace RecruitmentManagementSystem.API.Controllers
{
    // CandidateController.cs

    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {

        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        // Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiQWJoaSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiMGEzM2MyMDAtYzlmMi00NTQ3LTgxMGEtYjMzMzdhNzJkNzMzIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQ2FuZGlkYXRlIiwiZXhwIjoxNzU5NjMwNDA2LCJpc3MiOiJSZWNydWl0bWVudE1hbmFnZW1lbnRTeXN0ZW0iLCJhdWQiOiJVc2VycyJ9.uO47rACEZKIUdG9ZjRu56Ie9YkC9gVB__g93tsNf0yU

        [Authorize(Roles = "Candidate")]
        [HttpGet("profile")]
        public async Task<ActionResult<CandidateProfileDto>> GetCandidateProfileAsync()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            // parsing string to guid
            Guid.TryParse(userIdClaim?.Value, out Guid userId);

            var result = await _candidateService.GetProfileByUserIdAsync(userId);
            return Ok(result);
        }

        [Authorize(Roles = "Candidate")]
        [HttpPost("profile")]
        public async Task<ActionResult<CandidateProfileDto?>> CreateCandidateProfile(CreateCandidateProfileDto candidateProfileDto)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            // parsing string to guid
            Guid.TryParse(userIdClaim?.Value, out Guid userId);
            var profile = await _candidateService.CreateProfileAsync(userId, candidateProfileDto);

            return Ok(profile);
        }


        [Authorize(Roles = "Candidate")]
        [HttpPatch("profile")]
        public async Task<IActionResult> UpdateCandidateProfile(UpdateCandidateProfileDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            // parsing string to guid
            Guid.TryParse(userIdClaim?.Value, out Guid userId);

            var updatedProfile = await _candidateService.UpdateProfileAsync(userId, dto);
            return Ok(updatedProfile);
        }

        [Authorize(Roles = "Candidate")]
        [HttpDelete("profile")]
        public async Task<IActionResult> DeleteCandidateProfile(UpdateCandidateProfileDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            // parsing string to guid
            Guid.TryParse(userIdClaim?.Value, out Guid userId);

            var updatedProfile = await _candidateService.DeleteProfileAsync(userId);
            return Ok(updatedProfile);
        }


        [Authorize(Roles = "Candidate")]
        [HttpPost("apply/{jobId}")]
        public async Task<IActionResult> ApplyToJob(Guid jobId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim?.Value, out Guid userId);

            bool success = await _candidateService.ApplyToJobAsync(userId, jobId);

            if (!success)
                return BadRequest("Failed to apply for the job or already applied.");

            return Ok(new { message = "Application submitted successfully." });
        }


        // #####################################################

        // ??? for later plans making everything seperate.

        // #####################################################

        // -------- PROFILE --------
        // GET    /api/candidate/profile/{userId}
        // POST   /api/candidate/profile
        // PUT    /api/candidate/profile/{id}
        // DELETE /api/candidate/profile/{id}
        // -------- PROFILE --------



        // -------- EDUCATION --------
        // GET    /api/candidate/{candidateId}/education
        // POST   /api/candidate/{candidateId}/education
        // PUT    /api/candidate/education/{id}
        // DELETE /api/candidate/education/{id}
        // -------- EDUCATION --------



        // -------- EXPERIENCE --------
        // GET    /api/candidate/{candidateId}/experience
        // POST   /api/candidate/{candidateId}/experience
        // PUT    /api/candidate/experience/{id}
        // DELETE /api/candidate/experience/{id}
        // -------- EXPERIENCE --------



        // -------- SKILLS --------
        // GET    /api/candidate/{candidateId}/skills
        // POST   /api/candidate/{candidateId}/skills
        // PUT    /api/candidate/skills/{id}
        // DELETE /api/candidate/skills/{id}
        // -------- SKILLS --------



        // -------- CV/RESUME --------
        // GET    /api/candidate/{candidateId}/cv
        // POST   /api/candidate/{candidateId}/cv
        // DELETE /api/candidate/cv/{id}
        // GET    /api/candidate/cv/{id}/download
        // -------- CV/RESUME --------



        // -------- SOCIALS --------
        // GET    /api/candidate/{candidateId}/socials
        // POST   /api/candidate/{candidateId}/socials
        // PUT    /api/candidate/socials/{id}
        // DELETE /api/candidate/socials/{id}        
        // -------- SOCIALS --------



    }
}
