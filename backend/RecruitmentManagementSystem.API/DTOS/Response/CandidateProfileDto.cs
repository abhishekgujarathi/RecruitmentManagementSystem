using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class CandidateProfileDto
{
    public Guid CandidateProfileId { get; set; }

    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }

    [StringLength(6)]
    public string? PostalCode { get; set; }

    public ICollection<CandidateSocialDto>? CandidateSocials { get; set; }
    public ICollection<EducationDto>? Educations { get; set; }
    public ICollection<ExperienceDto>? Experiences { get; set; }
    public ICollection<CandidateSkillDto>? CandidateSkills { get; set; }
    public ICollection<CVStorageDto>? CVStorages { get; set; }
}

public class EducationDto
{
    public Guid EducationId { get; set; }
    public string InstituteName { get; set; } = default!;
    public string DegreeType { get; set; } = default!;
    public string FieldOfStudy { get; set; } = default!;
    public decimal? PercentageScore { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsCurrent { get; set; }
}

public class ExperienceDto
{
    public Guid ExperienceId { get; set; }
    public string CompanyName { get; set; } = default!;
    public string Position { get; set; } = default!;
    public decimal? DurationYears { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public string? JobDescription { get; set; }
}

public class CandidateSocialDto
{
    public Guid CandidateSocialsId { get; set; }
    public Guid SocialPlatformId { get; set; }
    public string Link { get; set; } = default!;
}

public class CandidateSkillDto
{
    public Guid CandidateSkillId { get; set; }
    public Guid SkillId { get; set; }
    public decimal? ExperienceYears { get; set; }
    public string? ProficiencyLevel { get; set; }
}

public class CVStorageDto
{
    public Guid CVStorageId { get; set; }
    public string FileName { get; set; } = default!;
    public string FileType { get; set; } = default!;
    public long FileSize { get; set; }
    public DateTime UploadedAt { get; set; }
    public string Url { get; set; } = default!;
}
