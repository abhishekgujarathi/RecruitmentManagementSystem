using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class InterviewSkillRating
    {
        [Key]
        public Guid InterviewSkillRatingId { get; set; }

        [Required]
        public Guid InterviewFeedbackId { get; set; }
        public InterviewFeedback InterviewFeedback { get; set; } = default!;

        [Required]
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; } = default!;

        [Range(0, 5)]
        public decimal Rating { get; set; }
    }

}
