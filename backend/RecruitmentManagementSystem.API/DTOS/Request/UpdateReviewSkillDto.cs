namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class UpdateReviewSkillDto
    {
        public Guid SkillId { get; set; }
        public bool HasSkill { get; set; }
        public decimal? YearsOfExperience { get; set; }
    }
}
