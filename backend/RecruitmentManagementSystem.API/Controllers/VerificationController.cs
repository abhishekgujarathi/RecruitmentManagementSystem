using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.Services;
using System.Security.Claims;

namespace RecruitmentManagementSystem.API.Controllers
{
    public class VerificationController : Controller
    {
        private readonly IVerificationService _verificationService;

        public VerificationController(IVerificationService verificationService)
        {
            _verificationService = verificationService;
        }

        [Authorize(Roles = "Candidate")]
        [HttpPost("{verificationId}/documents")]
        public async Task<IActionResult> UploadDocument(
            Guid verificationId,
            [FromForm] UploadVerificationDocumentDto dto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _verificationService.UploadDocumentAsync(
                verificationId,
                userId,
                dto);

            return Ok();
        }

        [Authorize(Roles = "Candidate")]
        [HttpGet("{verificationId}")]
        public async Task<IActionResult> GetVerification(Guid verificationId)
        {
            var result = await _verificationService.GetVerificationAsync(verificationId);
            return Ok(result);
        }


        [HttpPost("{verificationId}/request-documents")]
        public async Task<IActionResult> RequestDocuments(
        Guid verificationId,
        [FromBody] RequestDocumentsDto dto)
        {
            await _verificationService.RequestDocumentsAsync(
                verificationId,
                dto.DocumentTypes);

            return Ok(new { message = "Documents requested" });
        }

        // HR approves/rejects a document
        [HttpPut("documents/{documentId}/verify")]
        public async Task<IActionResult> VerifyDocument(Guid documentId,[FromBody] VerifyDocumentDto dto)
        {
            var hrId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _verificationService.VerifyDocumentAsync(
                documentId,
                hrId,
                dto);

            return Ok(new { message = "Document verification updated" });
        }
    }
}
