namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class ReviewCommentDto
    {
        public Guid ReviewCommentId { get; set; }
        public Guid CommentedByUid { get; set; }
        public string CommentedByName { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;
        public DateTime CommentDate { get; set; }
    }
}
