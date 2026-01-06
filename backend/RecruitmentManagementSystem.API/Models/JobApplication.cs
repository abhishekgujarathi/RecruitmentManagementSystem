using RecruitmentManagementSystem.API.Common;
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


        // managing status
        [MaxLength(50)]
        public string CurrentStatus { get; set; } = ApplicationStatus.Applied;
        public string? StatusNote { get; set; }
        public DateTime StatusUpdatedAt { get; set; }
        // managin status

        public ICollection<AssignedReviewer> AssignedReviewers { get; set; } = new List<AssignedReviewer>();
        public ICollection<ReviewComment> ReviewComments { get; set; } = new List<ReviewComment>();
        public ICollection<ApplicationSkill> ApplicationSkills { get; set; } = new List<ApplicationSkill>();

    }
}
