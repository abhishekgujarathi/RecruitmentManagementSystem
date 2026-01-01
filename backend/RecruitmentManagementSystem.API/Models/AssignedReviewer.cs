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

        public ICollection<CVReviewStage> CVReviewStages { get; set; } = new List<CVReviewStage>();

    }
}
