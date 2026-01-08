using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class JobReviewer
    {
        [Key]
        public Guid JobReviewerId { get; set; }

        [Required]
        public Guid JobId { get; set; }
        public Job Job { get; set; } = default!;

        [Required]
        public Guid ReviewerId { get; set; }  
        public User Reviewer { get; set; } = default!;

        public Guid AssignedBy { get; set; }

        public bool IsActive { get; set; } = true;
    }

}
