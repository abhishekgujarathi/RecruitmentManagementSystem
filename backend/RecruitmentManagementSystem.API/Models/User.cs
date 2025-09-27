

namespace RecruitmentManagementSystem.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public required string Role { get; set; } = string.Empty;
        public required string MobileNumber { get; set; } = string.Empty;
        public required DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        
    }
}
