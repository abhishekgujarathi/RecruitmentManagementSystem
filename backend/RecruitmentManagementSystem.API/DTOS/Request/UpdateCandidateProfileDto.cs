using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Dtos
{
    public class UpdateCandidateProfileDto
    {
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }

        public List<UpdateEducationDto>? Educations { get; set; }
        public List<UpdateExperienceDto>? Experiences { get; set; }
        public List<UpdateCandidateSocialDto>? CandidateSocials { get; set; }
        public List<UpdateCandidateSkillDto>? CandidateSkills { get; set; }
    }

    public class UpdateEducationDto
    {
        [Required]
        public Guid EducationId { get; set; }  // Needed for identifying existing record

        public string? InstituteName { get; set; }
        public string? DegreeType { get; set; }
        public string? FieldOfStudy { get; set; }
        public decimal? PercentageScore { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsCurrent { get; set; }
    }

    public class UpdateExperienceDto
    {
        [Required]
        public Guid ExperienceId { get; set; }

        public string? CompanyName { get; set; }
        public string? Position { get; set; }
        public decimal? DurationYears { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsCurrent { get; set; }
        public string? JobDescription { get; set; }
    }

    public class UpdateCandidateSocialDto
    {
        [Required]
        public Guid CandidateSocialsId { get; set; }

        public Guid? SocialPlatformId { get; set; }
        public string? Link { get; set; }
    }

    public class UpdateCandidateSkillDto
    {
        [Required]
        public Guid CandidateSkillId { get; set; }

        public Guid? SkillId { get; set; }
        public decimal? ExperienceYears { get; set; }
        public string? ProficiencyLevel { get; set; }
    }
}
