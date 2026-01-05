namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class UpdateApplicationStatusDto
    {
        public string NewStatus { get; set; } = string.Empty;

        public string? Note { get; set; } //using note only if onhold
    }


}
