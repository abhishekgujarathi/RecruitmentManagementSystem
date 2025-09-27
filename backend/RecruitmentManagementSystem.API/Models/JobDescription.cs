using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentManagementSystem.API.Models
{
    public class JobDescription
    {
        //JDescription = [JDid,jTitle, jobDetails, JTid , responsibilties, location ,min_exp_req, other_criteria]
        [Key]
        public Guid JobDescriptionId { get; set; }
        public required string Title { get; set; } = string.Empty;
        public required string Details { get; set; } = string.Empty;
        public string? Responsibilty { get; set; }
        public string Location { get; set; } = string.Empty;
        public int MinimumExperienceReq { get; set; }

        //foreing key for jobtype
        public Guid JobTypeId { get; set; }
        public JobType JobType { get; set; } = default!;

    }
}
