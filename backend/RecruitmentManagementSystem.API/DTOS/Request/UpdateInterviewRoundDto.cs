namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class UpdateInterviewRoundDto
    {
        public Guid RoundId { get; set; }
        public DateTime? ScheduledAt { get; set; }

        public string? MeetLink { get; set; }

        public List<Guid> PanelMembers { get; set; } = new();
    }

}
