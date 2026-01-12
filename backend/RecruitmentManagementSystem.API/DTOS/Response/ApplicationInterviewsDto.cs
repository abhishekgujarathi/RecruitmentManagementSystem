using RecruitmentManagementSystem.API.Common;
using RecruitmentManagementSystem.API.Models;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class ApplicationInterviewsDto
    {
        public Guid ApplicationInterviewRoundId { get; set; }
        public Guid? JobApplicationId { get; set; }
        public int RoundNumber { get; set; }
        public string RoundType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? ScheduledAt { get; set; }
        public string MeetLink { get; set; }
        public List<InterviewPanelMemberDto> PanelMembers { get; set; } = [];

    }
}
