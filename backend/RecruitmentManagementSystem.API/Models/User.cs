using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class User
    {
        // User(Uid, Fname, Lname, email, mobNumber, DOB, gender, URid, pwdHash, createdDate, lastLogin, active) , pk[Uid], fk[URid]
        [Key]
        public Guid UserId { get; set; }

        public required string Fname { get; set; }
        public required string Lname { get; set; }
        public required string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public required string MobileNumber { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public string? Gender { get; set; }

        // Foreign key for UserRole
        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; } = default!;

        public required DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; } = true;

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        // makes easy to access users profile if there
        public CandidateProfile? CandidateProfile { get; set; }

        // if employee then its employee roles [rec/int/rev]
        public ICollection<EmployeeUserRole> EmployeeUserRoles { get; set; }
        = new List<EmployeeUserRole>();
    }
}
