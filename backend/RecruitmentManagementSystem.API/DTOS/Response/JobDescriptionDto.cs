namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class JobDescriptionDto
    {
        public Guid JobDescriptionId { get; set; }
        public required string Title { get; set; } = string.Empty;
        public required string Location { get; set; } = string.Empty;
        public required string JobType { get; set; } = string.Empty;
        public required string Details { get; set; } = string.Empty;
        public string? Responsibilities { get; set; }
        public required int MinimumExperienceReq { get; set; }
    }
}