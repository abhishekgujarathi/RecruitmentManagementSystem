using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class JobUpdateRequestDto
    {
        public string? Title { get; set; }
        public string? Details { get; set; }
        public string? Responsibilities { get; set; }
        public string? Location { get; set; }
        public int? MinimumExperienceReq { get; set; }
        public string? TypeName { get; set; }
        public int? OpeningsCount { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public List<Guid>? SkillIds { get; set; }
    }
}