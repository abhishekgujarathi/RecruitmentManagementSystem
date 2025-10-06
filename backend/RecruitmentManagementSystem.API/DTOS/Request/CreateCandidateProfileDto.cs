using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Dtos
{
    public class CreateCandidateProfileDto
    {
        [Required]
        [MaxLength(200)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string? City { get; set; }

        [Required]
        [MaxLength(100)]
        public string? State { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Country { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 4)]
        public string? PostalCode { get; set; }

        // Optional collections for creation
        public ICollection<CreateEducationDto>? Educations { get; set; }
        public ICollection<CreateExperienceDto>? Experiences { get; set; }
        public ICollection<CreateCandidateSocialDto>? CandidateSocials { get; set; }
        public ICollection<CreateCandidateSkillDto>? CandidateSkills { get; set; }
    }

    public class CreateEducationDto
    {
        [Required]
        [MaxLength(200)]
        public string InstituteName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string DegreeType { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FieldOfStudy { get; set; } = string.Empty;

        [Range(0, 100)]
        public decimal? PercentageScore { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCurrent { get; set; } = false;
    }

    public class CreateExperienceDto
    {
        [Required]
        [MaxLength(200)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Position { get; set; } = string.Empty;

        [Range(0, 50)]
        public decimal? DurationYears { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCurrent { get; set; } = false;

        [MaxLength(1000)]
        public string? JobDescription { get; set; }
    }
    public class CreateCandidateSocialDto
    {
        [Required]
        public Guid SocialPlatformId { get; set; }  // FK to SocialPlatform

        [Required]
        [MaxLength(300)]
        [Url(ErrorMessage = "Please provide a valid URL.")]
        public string Link { get; set; } = string.Empty;
    }
    public class CreateCandidateSkillDto
    {
        [Required]
        public Guid SkillId { get; set; }

        [Range(0, 50)]
        public decimal? ExperienceYears { get; set; }

        [MaxLength(50)]
        public string? ProficiencyLevel { get; set; }
    }
}
