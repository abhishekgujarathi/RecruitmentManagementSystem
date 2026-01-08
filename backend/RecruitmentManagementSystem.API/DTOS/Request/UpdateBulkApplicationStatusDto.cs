namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class UpdateBulkApplicationStatusDto
    {
        public List<Guid> ApplicationIds { get; set; }
        public string NewStatus { get; set; }
        public string? Note { get; set; }
    }
}
