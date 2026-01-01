using RecruitmentManagementSystem.API.DTOS.Response;

namespace RecruitmentManagementSystem.API.DTOS
{
    public class RecruiterCandidateProfileDto
    {
        public Guid CandidateProfileId { get; set; }

        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string MobileNumber { get; set; }

        public string? City { get; set; }
        public string? Country { get; set; }

        public ICollection<EducationDto>? Educations { get; set; }
        public ICollection<ExperienceDto>? Experiences { get; set; }
        public ICollection<CandidateSkillDto>? CandidateSkills { get; set; }
    }
}
