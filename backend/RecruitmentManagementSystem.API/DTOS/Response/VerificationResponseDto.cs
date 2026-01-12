using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class VerificationResponseDto
    {
        public Guid VerificationId { get; set; }
        public string OverallStatus { get; set; }
        public List<VerificationDocumentResponseDto> Documents { get; set; }
    }
}
