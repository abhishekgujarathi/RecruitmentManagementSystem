namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class ApplicationInterviewsUpsertDto
    {
        // empty means existing will be deleted
        public Guid? ApplicationInterviewRoundId { get; set; }
        public string RoundType { get; set; }
        public int RoundNumber { get; set; }
    }
}
