using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    // used to define first for job position by recruiter
    public class JobInterviewRound
    {
        [Key]
        public Guid JobInterviewRoundId { get; set; }

        [Required]
        public Guid JobId { get; set; }
        public Job Job { get; set; } = default!;

        public int RoundNumber { get; set; }

        [Required]
        public string RoundType { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
