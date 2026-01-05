using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class AssignedReviewer
    {
        [Key]
        public Guid AssignedReviewersId { get; set; }

        // Reviewer User ID
        [Required]
        public Guid Uid { get; set; }

        [Required]
        public Guid JobApplicationId { get; set; }

        public User Reviewer { get; set; } = default!;

        [Required]
        public DateTime AssignedDate { get; set; }

        [Required]
        public Guid AssignedByUid { get; set; }

        [Required]
        public bool isActive { get; set; } = true;

        // replacing those from cvreviewstage due to redundacy
        public bool IsReviewCompleted { get; set; } = false;
        public DateTime? ReviewCompletedAt { get; set; }
        public bool? IsPass { get; set; }



    }
}
