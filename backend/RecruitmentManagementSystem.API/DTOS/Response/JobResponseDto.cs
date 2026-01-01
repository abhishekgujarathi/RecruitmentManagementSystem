namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class JobResponseDto
    {
        public required Guid JobId { get; set; }
        public required JobDescriptionDto JobDescription { get; set; } = default!;
        public required int OpeningsCount { get; set; }
        public required DateTime DeadlineDate { get; set; }
        public required DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public required Guid CreatedByUserId { get; set; }
        public bool? IsApplied { get; set; }
    }
}
