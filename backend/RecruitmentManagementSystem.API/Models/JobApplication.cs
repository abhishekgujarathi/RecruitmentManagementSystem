using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class JobApplication
    {
        [Key]
        public Guid JobApplicationId { get; set; }

        [Required]
        public Guid CandidateProfileId { get; set; }
        public CandidateProfile CandidateProfile { get; set; } = default!;

        [Required]
        public Guid JobId { get; set; }
        public Job Job { get; set; } = default!;

        [Required]
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;

        [MaxLength(50)]
        public string? CurrentStatus { get; set; } = "Pending";

        public ICollection<AssignedReviewer> AssignedReviewers { get; set; } = new List<AssignedReviewer>();

    }
}
