using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class CVReviewStage
    {
        [Key]
        public Guid CVReviewStageSid { get; set; }
        public Guid JobApplicationId { get; set; }
        public JobApplication JobApplication { get; set; } = default!; 

        // Reviewer
        public Guid ReviewedByUid { get; set; }
        public User Reviewer { get; set; } = default!; 

        // Review details
        public DateTime? ReviewDate { get; set; }
        public string? ReviewStatus { get; set; }  
        public bool? IsPass { get; set; }
    }
}
