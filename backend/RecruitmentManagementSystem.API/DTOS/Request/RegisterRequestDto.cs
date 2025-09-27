using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class RegisterRequestDto
    {
        [Required]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Username must be atleast 3 letters long.")]
        public required string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(100,MinimumLength =8,ErrorMessage ="Password Must Be atleast 8 chars long.")]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string MobileNumber { get; set; } = string.Empty;
        
    }
}
