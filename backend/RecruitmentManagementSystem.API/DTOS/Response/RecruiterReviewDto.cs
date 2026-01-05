using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class RecruiterReviewDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public bool ReviewCompleted { get; set; }
        public List<ReviewCommentDto> Comments { get; set; } = new();
        public List<ReviewSkillDto> Skills { get; set; } = new();
    }
}
