namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class MyApplicationDto
    {
        public Guid ApplicationId { get; set; }

        public Guid JobId { get; set; }

        public string JobTitle { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; }

        public string CurrentStatus { get; set; } = string.Empty;
    }
}
