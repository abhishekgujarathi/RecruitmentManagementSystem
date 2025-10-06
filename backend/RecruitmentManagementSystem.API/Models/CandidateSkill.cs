using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentManagementSystem.API.Models
{
    public class CandidateSkill
    {
        [Key]
        public Guid CandidateSkillId { get; set; }

        [Required]
        public Guid CandidateProfileId { get; set; }
        public CandidateProfile CandidateProfile { get; set; } = default!;

        [Required]
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; } = default!;

        [Column(TypeName = "decimal(4,2)")]
        [Range(0, 50)]
        public decimal? ExperienceYears { get; set; }

        public String? ProficiencyLevel { get; set; }

    }
}