namespace RecruitmentManagementSystem.API.Models
{

    // many empplye can have many roles
    // and many roles will have many empllyes
    public class EmployeeUserRole
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid EmployeeRoleId { get; set; }
        public EmployeeRole EmployeeRole { get; set; }

        public DateTime AssignedOn { get; set; } = DateTime.UtcNow;
    }

}
