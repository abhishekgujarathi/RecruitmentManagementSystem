namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class UploadVerificationDocumentDto
    {
        public string DocumentType { get; set; }
        public IFormFile File { get; set; }
    }
}
