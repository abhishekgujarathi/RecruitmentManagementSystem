namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class TokenResponseDto
    {
        public required string AuthToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
