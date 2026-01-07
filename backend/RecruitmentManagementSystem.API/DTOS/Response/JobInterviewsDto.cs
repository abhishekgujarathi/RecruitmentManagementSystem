using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class JobInterviewsDto
    {
        public Guid JobInterviewRoundId { get; set; }

        public Guid JobId { get; set; }
        public int RoundNumber { get; set; }
        public string RoundType { get; set; }
        public bool IsActive { get; set; } = true;


    }
}
