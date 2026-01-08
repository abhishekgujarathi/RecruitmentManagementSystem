using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class ScheduleInterviewDto
    {
        [Required]
        public DateTime ScheduledAt { get; set; }
    }

}
