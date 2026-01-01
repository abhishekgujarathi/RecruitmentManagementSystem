namespace RecruitmentManagementSystem.API.DTOS.Response
{
    public class CvResponseDto
    {
        public string FileName { get; set; }
        public string Url { get; set; }
        public DateTime UploadedAt { get; set; }
        public long FileSize { get; set; }
    }

}
