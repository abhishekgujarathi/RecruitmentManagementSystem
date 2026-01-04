using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class ReviewComment
    {
        [Key]
        public Guid ReviewCommentId { get; set; }

        [Required]
        public Guid JobApplicationId { get; set; }
        public JobApplication JobApplication { get; set; } = default!;

        [Required]
        public Guid CommentedByUid { get; set; }
        public User CommentedBy { get; set; } = default!;

        [Required]
        public string CommentText { get; set; } = string.Empty;

        public DateTime CommentDate { get; set; } = DateTime.UtcNow;
    }

}

