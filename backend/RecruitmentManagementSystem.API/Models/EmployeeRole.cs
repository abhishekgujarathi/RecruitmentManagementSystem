using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class EmployeeRole
    {
        [Key]
        public Guid EmployeeRoleId { get; set; }

        [Required]
        public string RoleName { get; set; } = string.Empty;
        // Recruitr | Reviewr | Interviewr | Admin

        public bool IsActive { get; set; } = true;

        public ICollection<EmployeeUserRole> EmployeeUserRoles { get; set; }
            = new List<EmployeeUserRole>();
    }

}
