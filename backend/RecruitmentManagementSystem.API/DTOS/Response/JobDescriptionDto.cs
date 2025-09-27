namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class JobDescriptionDto
    {
        public Guid JobDescriptionId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Location { get; set; }
        public int MinimumExperienceReq { get; set; }
        public string JobType { get; set; }
    }
}