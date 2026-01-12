using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class InterviewFeedback
    {
        [Key]
        public Guid InterviewFeedbackId { get; set; }

        [Required]
        public Guid ApplicationInterviewRoundId { get; set; }
        public ApplicationInterviewRound ApplicationInterviewRound { get; set; } = default!;

        [Required]
        public Guid InterviewerId { get; set; }
        public User Interviewer { get; set; } = default!;

        public string? Comments { get; set; }

        [Range(0, 5)]
        public decimal? OverallRating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<InterviewSkillRating> SkillRatings { get; set; } = new List<InterviewSkillRating>();
    }

}
