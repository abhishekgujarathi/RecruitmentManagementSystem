namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class ReviewSkillDto
    {
        public Guid SkillId { get; set; }
        public string SkillName { get; set; } = string.Empty;
        public int? MinExperienceYears { get; set; }

        public Guid? ReviewerId { get; set; }
        public bool? HasSkill { get; set; }
        public decimal? YearsOfExperience { get; set; }
    }
}
