
using Microsoft.Identity.Client.Extensions.Msal;
using RecruitmentManagementSystem.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Net;

namespace RecruitmentManagementSystem.API.Models
{
    public class CandidateProfile
    //CandidateProfile(CPid, ReviewerUserId, address, city, state, country, postalCode) , pk[CPid], fk[ReviewerUserId]

    {
        [Key]
        public Guid CandidateProfileId { get; set; }


        public Guid UserId { get; set; }
        public User? User { get; set; }


        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        [StringLength(6)]
        public string PostalCode { get; set; }


        public virtual ICollection<CandidateSocial> CandidateSocials { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<CandidateSkill> CandidateSkills { get; set; }
        public virtual ICollection<CVStorage> CVStorages { get; set; }


        // adding to reference candidates applications directly
        public virtual ICollection<JobApplication> Applications { get; set; }
    }
}
