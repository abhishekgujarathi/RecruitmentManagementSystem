namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class InterviewRoundSummaryDto
    {
        public Guid ApplicationInterviewRoundId { get; set; }
        public string RoundType { get; set; } = string.Empty;
        public DateTime? ScheduledAt { get; set; }
        public string Status { get; set; } = string.Empty;

        //public InterviewFeedbackDto? Feedback { get; set; } = new();
        public List<InterviewFeedbackDto>? Feedbacks { get; set; } = new List<InterviewFeedbackDto>();
    }
}
