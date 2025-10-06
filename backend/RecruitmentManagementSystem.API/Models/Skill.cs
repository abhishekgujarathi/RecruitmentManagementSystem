using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class Skill
    {
        [Key]
        public Guid SkillId { get; set; }

        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;
    }
}