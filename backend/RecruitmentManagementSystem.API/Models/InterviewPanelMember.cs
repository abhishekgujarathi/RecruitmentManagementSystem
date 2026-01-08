using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class InterviewPanelMember
    {
        [Key]
        public Guid InterviewPanelMemberId { get; set; }

        public Guid ApplicationInterviewRoundId { get; set; }
        public ApplicationInterviewRound ApplicationInterviewRound { get; set; } = default!;

        public Guid InterviewerId { get; set; }
        public User Interviewer { get; set; } = default!;

        public Guid AssignedByUserId { get; set; }
        public User AssignedByUser { get; set; } = default!;
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
