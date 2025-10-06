using RecruitmentManagementSystem.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Net;

namespace RecruitmentManagementSystem.API.Models
{
    public class CandidateSocial
    // CandidateSocials(CSid, CPid, SPid, Link), pk[CSid], fk[CPid, SPid]

    {
        [Key]
        public Guid CandidateSocialsId { get; set; }

        [Required]
        public Guid CandidateProfileId { get; set; }
        public CandidateProfile CandidateProfile { get; set; }

        [Required]
        public Guid SocialPlatformId { get; set; }
        public SocialPlatform SocialPlatform { get; set; }

        [Required]
        public string Link { get; set; }
    }
}
