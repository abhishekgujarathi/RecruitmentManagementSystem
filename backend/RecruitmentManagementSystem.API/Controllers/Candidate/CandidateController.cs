
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.DTOS;
using RecruitmentManagementSystem.API.Models;
using RecruitmentManagementSystem.API.Services;
using RecruitmentManagementSystem.API.Services.Candidate;
using System.Security.Claims;

namespace RecruitmentManagementSystem.API.Controllers.Candidate
{
    // CandidateController.cs

    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {

        private readonly ICandidateService _candidateService;
        private readonly IFileUploadService _fileUploadService;

        public CandidateController(ICandidateService candidateService, IFileUploadService fileUploadService)
        {
            _candidateService = candidateService;
            _fileUploadService = fileUploadService;
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
        [HttpPut("profile")]
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



        // -------- CV/RESUME --------
        // GET    /api/candidate/{candidateId}/cv
        [Authorize(Roles = "Candidate")]
        [HttpGet("cv")]
        public async Task<IActionResult> GetCV()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim?.Value, out Guid userId);

            var cvDetails = await _fileUploadService.GetPdfAsync(userId);

            if (cvDetails is null)
                return NotFound();

            cvDetails.Url = Url.Action(nameof(GetCV), "Candidate");


            return Ok(cvDetails);

        }

        // GET    /api/candidate/cv/download
        [Authorize(Roles = "Candidate")]
        [HttpGet("cv/download")]
        public IActionResult DownloadCV()
        {
            // getting userid
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdClaim?.Value, out Guid userId))
                return Unauthorized();

            var result = _fileUploadService.DownloadPdf(userId);

            if (result is null)
                return NotFound("cv not found");



            return File(result.Value.FileBytes, "application/pdf", result.Value.FileName);
        }

        // POST   /api/candidate/cv
        [Authorize(Roles = "Candidate")]
        [HttpPost("cv")]
        public async Task<IActionResult> StoreCV([FromForm] FileDto file)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdClaim?.Value, out Guid userId);

            try
            {
                var fileName = await _fileUploadService.UploadPdfAsync(userId, file.File);

                return Ok(new { message = "cv uploaded successfully", fileName });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // DELETE /api/candidate/cv/{id}
        // -------- CV/RESUME --------

    }
}
