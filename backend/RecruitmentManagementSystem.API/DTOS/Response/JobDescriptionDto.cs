namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class JobDescriptionDto
    {
        public Guid JobDescriptionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string JobType { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string? Responsibilities { get; set; }
        public int MinimumExperienceReq { get; set; }
    }
}