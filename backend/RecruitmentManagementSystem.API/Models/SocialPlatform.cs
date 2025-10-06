using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    //SocialPlatform(SPid, Name), pk[SPid]
    public class SocialPlatform
    {
        // pk (SPid)
        [Key]
        public Guid SocialPlatformId { get; set; }

        public string? Name { get; set; }
    }
}
