using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class RefreshTokenRequestDto
    {

        public Guid userId { get; set; }
        public required string RefreshToken { get; set; }
    }
}
