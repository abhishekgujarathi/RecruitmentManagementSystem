using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentManagementSystem.API.Models
{
    public class ApplicationSkill
    {
        [Key]
        public Guid ApplicationSkillId { get; set; }

        [Required]
        public Guid JobApplicationId { get; set; }
        public JobApplication JobApplication { get; set; } = default!;

        [Required]
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; } = default!;

        [Required]
        public Guid ReviewerId { get; set; }

        [Range (0,50)]
        public decimal? ExperienceYears { get; set; }

        public bool HasSkill { get; set; } = true;
    }

}
