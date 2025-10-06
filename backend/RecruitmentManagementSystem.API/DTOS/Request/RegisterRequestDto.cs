using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class RegisterRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "FName must be at least 3 letters long")]
        public required string Fname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "LName must be at least 3 letters long")]
        public required string Lname { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "pwd must be at least 8 characters long.")]
        public required string Password { get; set; }

        [Required]
        public required string Role { get; set; }

        [Required]
        [Phone]
        public required string MobileNumber { get; set; }

        public DateTime? DOB { get; set; }
        public string? Gender { get; set; }
    }
}
