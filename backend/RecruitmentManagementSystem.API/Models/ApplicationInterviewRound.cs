using RecruitmentManagementSystem.API.Common;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    // later when application is moved to interview in process status
    // automatically move job rounds to application
    public class ApplicationInterviewRound
    {
        [Key]
        public Guid ApplicationInterviewRoundId { get; set; }

        [Required]
        public Guid JobApplicationId { get; set; }
        public JobApplication JobApplication { get; set; } = default!;

        public int RoundNumber { get; set; }
        public string RoundType { get; set; }

        public DateTime? ScheduledAt { get; set; } = null;

        public string Status { get; set; } = InterviewRoundStatus.Pending;
        public string? MeetLink { get; set; }

        // define empty list 
        public virtual ICollection<InterviewPanelMember> PanelMembers { get; set; } = new List<InterviewPanelMember>();
    }
}
