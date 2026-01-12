using System.ComponentModel.DataAnnotations;
namespace RecruitmentManagementSystem.API.Models
{
    public class VerificationDocument
    {
        [Key]
        public Guid VerificationDocumentId { get; set; }

        [Required]
        public Guid CandidateVerificationId { get; set; }
        public CandidateVerification CandidateVerification { get; set; } = default!;

        [Required]
        public string DocumentType { get; set; } = string.Empty;

        [Required]
        public string FileUrl { get; set; } = string.Empty;

        public string Status { get; set; } = VerificationStatus.Pending;

        public string? Remarks { get; set; }

        public Guid? VerifiedBy { get; set; }
        public User? ReviewedByUser { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public DateTime? VerifiedOn { get; set; }
    }
}
