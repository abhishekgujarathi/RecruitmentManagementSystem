using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class JobType
    {
        // JobTypes = [JTid, type_of_Job]

        [Key]
        public Guid JobTypeId { get; set; }
        public required string TypeName { get; set; } = string.Empty;
    }
}
