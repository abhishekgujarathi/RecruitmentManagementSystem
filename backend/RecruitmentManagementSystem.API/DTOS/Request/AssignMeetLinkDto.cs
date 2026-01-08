using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class AssignMeetLinkDto
    {
        [Required]
        public string MeetLink { get; set; } = string.Empty;
    }

}
