namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class JobApplicationDto
    {
        public Guid JobApplicationId { get; set; }
        public string CandidateName { get; set; } = string.Empty;
        public DateTime ApplicationDate { get; set; }
        public string CurrentStatus { get; set; } = "Pending";
        public Guid CandidateProfileId  { get; set; }
        public Guid ApplicationId  { get; set; }
    }
}
