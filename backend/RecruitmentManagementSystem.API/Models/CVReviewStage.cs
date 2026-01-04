using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class CVReviewStage
    {
        [Key]
        public Guid CVReviewStageId { get; set; }

        [Required]
        public Guid AssignedReviewersId { get; set; }
        public AssignedReviewer AssignedReviewer { get; set; } = default!;

        public DateTime? ReviewDate { get; set; }
        public string? ReviewStatus { get; set; }
        public bool? IsPass { get; set; }
    }
}
