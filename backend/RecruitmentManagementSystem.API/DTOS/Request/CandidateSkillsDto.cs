namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class CandidateSkillsDto
    {
        public List<SkillExperience> Skills { get; set; } = new();

        public class SkillExperience
        {
            public Guid SkillId { get; set; }
            public int YearsOfExperience { get; set; }
            public bool HasSkill { get; set; } = true;
        }
    }

}
