using System.ComponentModel.DataAnnotations;
namespace RecruitmentManagementSystem.API.DTOS.Request
{

    public class JobCreateRequestDto
    {
        [Required(ErrorMessage = "job title is reqq")]
        [StringLength(150, MinimumLength = 5)]
        public required string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "job details are req")]
        [StringLength(4000)]
        public required string Details { get; set; } = string.Empty; 

        [Required(ErrorMessage = "job type is required.")]
        public required string TypeName { get; set; } = string.Empty;

        public string? Responsibilities { get; set; } 

        [Required(ErrorMessage = "location needed")]
        public required string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "minimum experience is required")]
        [Range(0,100)]
        public required int MinimumExperienceReq { get; set; }

        [Required(ErrorMessage = "no. of openings is req")]
        [Range(1, 100, ErrorMessage = "must have at least one opening")]
        public required int OpeningsCount { get; set; }

        [Required(ErrorMessage = "Application deadline is required.")]
        public required DateTime DeadlineDate { get; set; }
    }
}
