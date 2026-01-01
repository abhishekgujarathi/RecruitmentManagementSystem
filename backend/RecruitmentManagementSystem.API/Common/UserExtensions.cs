using RecruitmentManagementSystem.API.Common.Enums;
using System.Security.Claims;

namespace RecruitmentManagementSystem.API.Common
{
    public static class UserExtensions
    {
        public static UserRoleType GetUserRoleType(this ClaimsPrincipal user)
        {
            if (!user.Identity?.IsAuthenticated ?? true)
                return UserRoleType.Anonymous;

            if (user.IsInRole("Candidate"))
                return UserRoleType.Candidate;

            if (user.IsInRole("Recruiter"))
                return UserRoleType.Recruiter;

            return UserRoleType.Anonymous;
        }
    }
}
