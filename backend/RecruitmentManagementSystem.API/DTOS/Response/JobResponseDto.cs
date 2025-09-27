namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class JobResponseDto
    {
        public Guid JobId { get; set; }
        public int OpeningsCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public JobDescriptionDto JobDescription { get; set; }
        public Guid CreatedByUserId { get; set; }

    }
}
