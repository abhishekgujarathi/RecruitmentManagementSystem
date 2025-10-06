using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentManagementSystem.API.Models
{
    public class Experience
    {
        [Key]
        public Guid ExperienceId { get; set; }

        [Required]
        public Guid CandidateProfileId { get; set; }
        // Navigation Property
        [JsonIgnore]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public required string CompanyName { get; set; }

        public required string Position { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        [Range(0, 50)]
        public decimal? DurationYears { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCurrent { get; set; } = false;

        public string? JobDescription { get; set; }

    }
}