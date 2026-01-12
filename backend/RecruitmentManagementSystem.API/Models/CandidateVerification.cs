using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class CandidateVerification
    {
        [Key]
        public Guid CandidateVerificationId { get; set; }

        [Required]
        public Guid CandidateProfileId { get; set; }
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public Guid? JobId { get; set; }
        public Job? Job { get; set; }

        public string Status { get; set; } = VerificationStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }

        public ICollection<VerificationDocument> Documents { get; set; }
            = new List<VerificationDocument>();
    }
}
