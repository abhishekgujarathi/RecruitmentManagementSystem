using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace RecruitmentManagementSystem.API.Models
{
    public class Job
    //Jobs = [Jid, JDid, createdBy, createdDate, LastModifiedDate, deadline_date]
    {
        // pk (Jid)
        [Key]
        public Guid JobId { get; set; }

        // fk to JobDescription
        public required Guid JobDescriptionId { get; set; }
        public JobDescription JobDescription { get; set; } = default!; // this is callled navigation property filled if needed directly by efcore

        // use collection everywhere
        public ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();


        public required int OpeningsCount { get; set; }

        // createdBy fk to the Recruiter User
        // Assuming your User primary key (Uid) is a Guid
        public required Guid CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; } = default!; // this is callled navigation property filled if needed directly by efcore
        // default! means its required to be fetched


        // createdDate
        public required DateTime CreatedDate { get; set; }

        // LastModifiedDate
        public DateTime? LastModifiedDate { get; set; }

        // deadline_date
        public required DateTime DeadlineDate { get; set; }

        public bool IsActive { get; set; } = false;
        public DateTime? ClosedDate { get; set; }
        

        // nav prop
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}