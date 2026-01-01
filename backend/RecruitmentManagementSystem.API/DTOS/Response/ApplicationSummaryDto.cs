using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class ApplicationSummaryDto
    {
        public Guid JobApplicationId { get; set; }

        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
        public string? CurrentStatus { get; set; } = "Pending";
        public required string FullName { get; set; }

        public required string Email {get;set;}

        public required string JobTitle { get; set; }

    }
}
