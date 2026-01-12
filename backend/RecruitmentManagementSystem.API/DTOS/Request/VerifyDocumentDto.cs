using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class VerifyDocumentDto
    {
        public string Status { get; set; }
        public string? Remarks { get; set; }
    }
}
