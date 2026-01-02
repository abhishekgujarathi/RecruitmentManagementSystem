using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;
using System.Threading.Tasks;

namespace RecruitmentManagementSystem.API.Services
{
    public interface IReviewersService
    {
        Task<List<KeyValuePair<Guid, string>>> GetReviewersAsync(Guid applicationId);

        //get reviewer's all applications
        Task<IEnumerable<JobApplicationDto>> GetApplicationsAsync(Guid reviewerId);

    }
    public class ReviewersService : IReviewersService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReviewersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<KeyValuePair<Guid, string>>> GetReviewersAsync(Guid applicationId)
        {

            // getting alredy assigned reviewers
            var assignedReviewerIds = await _context.AssignedReviewers
               .Where(ar => ar.JobApplicationId == applicationId)
               .Select(ar => ar.Uid)
               .ToListAsync();

            var result = await _context.Users
                .Where(u =>
                    u.IsActive &&
                    u.UserType.TypeName == "Employee"

                    // returning all employees
                    // && u.EmployeeUserRoles.Any(eur =>
                    //    //eur.EmployeeRole.RoleName == "Reviewer"
                    //) 
                    &&
                    // filltring alredy assigned to the application id
                    !assignedReviewerIds.Contains(u.UserId)
                )
                .Select(u => new KeyValuePair<Guid, string>(
                    u.UserId,
                    u.Fname + " " + u.Lname
                ))
                .ToListAsync();

            return result;
        }

        // get all applications assigned to the user
        public async Task<IEnumerable<JobApplicationDto>> GetApplicationsAsync(Guid reviewerId)
        {
            var applications = await _context.JobApplications
                .Include(a => a.CandidateProfile)
                    .ThenInclude(cp => cp.User)
                .Include(a => a.AssignedReviewers)
                .Where(a => a.AssignedReviewers.Any(ar => ar.Uid == reviewerId))
                .Select(a => new JobApplicationDto
                {
                    JobApplicationId = a.JobApplicationId,
                    CandidateName = a.CandidateProfile.User.Fname + " " + a.CandidateProfile.User.Lname,
                    ApplicationDate = a.ApplicationDate,
                    CurrentStatus = a.CurrentStatus,
                    CandidateProfileId = a.CandidateProfileId,
                    ApplicationId = a.JobApplicationId
                })
                .ToListAsync();

            var a = applications;

            return applications;
        }


    }
}
