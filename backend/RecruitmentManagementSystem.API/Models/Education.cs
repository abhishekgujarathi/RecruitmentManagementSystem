using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentManagementSystem.API.Models
{
    public class Education
    {
        [Key]
        public Guid EducationId { get; set; }

        [Required]
        public Guid CandidateProfileId { get; set; }
        // navigation property

        [JsonIgnore]
        public CandidateProfile CandidateProfile { get; set; } = default!;


        public required string InstituteName { get; set; }


        public required string DegreeType { get; set; }

        public required string FieldOfStudy { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 100)]
        public decimal? PercentageScore { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCurrent { get; set; } = false;


    }
}