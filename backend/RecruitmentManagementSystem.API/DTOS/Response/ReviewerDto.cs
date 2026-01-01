namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class ReviewerDto
    {
        public Guid ReviewerId { get; set; }
        public string Name { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Status { get; set; } 
        public DateTime? ReviewedOn { get; set; }
    }
}
