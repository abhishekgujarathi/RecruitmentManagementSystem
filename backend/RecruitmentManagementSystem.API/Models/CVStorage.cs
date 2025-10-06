using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentManagementSystem.API.Models
{
    public class CVStorage
    {
        [Key]
        public Guid CVStorageId { get; set; }

        [Required]
        public Guid CandidateProfileId { get; set; }
        // nav Prop
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public required string FileName { get; set; }

        public required string FilePath { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.UtcNow;

        public long? FileSize { get; set; }

        public string? FileType { get; set; }

        public bool IsActive { get; set; } = true;

    }
}