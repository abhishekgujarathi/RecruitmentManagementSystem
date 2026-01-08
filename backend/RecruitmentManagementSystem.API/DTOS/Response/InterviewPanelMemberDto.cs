namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class InterviewPanelMemberDto
    {
       
        public Guid InterviewPanelMemberId { get; set; }

        public Guid InterviewerId { get; set; }
        public string InterviewerName { get; set; } = string.Empty;
    }

}
