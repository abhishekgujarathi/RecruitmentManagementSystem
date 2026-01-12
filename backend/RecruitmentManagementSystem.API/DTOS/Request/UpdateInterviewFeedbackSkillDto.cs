namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class UpdateInterviewFeedbackSkillDto
    {
        public Guid SkillId { get; set; }
        public decimal Rating { get; set; }   
        public decimal? ExperienceYears { get; set; }
    }
}
