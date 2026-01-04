using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class JobSkill
    {
        [Key]
        public Guid JobSkillId { get; set; }

        [Required]
        public Guid JobId { get; set; }
        public Job Job { get; set; } = default!;

        [Required]
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; } = default!;

        public int? MinExperienceYears { get; set; }
    }

}
