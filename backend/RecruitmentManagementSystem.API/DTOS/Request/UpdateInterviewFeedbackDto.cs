namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class UpdateInterviewFeedbackDto
    {
        public Guid ApplicationInterviewRoundId { get; set; }
        // removin all cmments  and will insert this as new
        public string? Comments { get; set; }
        public List<UpdateInterviewFeedbackSkillDto> SkillRatings { get; set; } = new();
    }
}
