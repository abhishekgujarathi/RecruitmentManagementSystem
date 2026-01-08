namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class JobInterviewsUpsertDto
    {
        // empty means existing will be deleted
        public Guid? JobInterviewRoundId { get; set; }
        public string RoundType { get; set; }
        public int RoundNumber { get; set; }
    }
}
