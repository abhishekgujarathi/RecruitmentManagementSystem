namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class InterviewFeedbackDto
    {
        public Guid InterviewFeedbackId { get; set; }
        public Guid InterviewerId { get; set; }
        public string InterviewerName { get; set; } = string.Empty;
        public string? Comments { get; set; }
        public decimal? OverallRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<InterviewFeedbackSkillDto> SkillRatings { get; set; } = new List<InterviewFeedbackSkillDto>();
    }
}
