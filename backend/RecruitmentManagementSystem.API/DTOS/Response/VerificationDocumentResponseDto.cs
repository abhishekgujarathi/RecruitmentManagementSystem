using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class VerificationDocumentResponseDto
    {
        public Guid DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string Status { get; set; }
        public string? Remarks { get; set; }
        public string? FileUrl { get; set; }
    }
}
