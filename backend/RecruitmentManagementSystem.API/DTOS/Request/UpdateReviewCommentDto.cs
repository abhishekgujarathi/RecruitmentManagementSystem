namespace RecruitmentManagementSystem.API.DTOS.Request
{
    public class UpdateReviewCommentDto
    {
        public Guid? ReviewCommentId { get; set; }
        public string CommentText { get; set; } = string.Empty;
    }
}
