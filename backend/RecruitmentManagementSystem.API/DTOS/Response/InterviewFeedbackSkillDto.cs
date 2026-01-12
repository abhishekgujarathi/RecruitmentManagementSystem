namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class InterviewFeedbackSkillDto
    {
        public Guid SkillId { get; set; }
        public string SkillName { get; set; } = string.Empty;
        public decimal Rating { get; set; }
    }
}
