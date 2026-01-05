using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Common.Enums;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.Services
{
    public interface IApplicationsService
    {
        ////get reviewer's all applications
        Task<IEnumerable<JobApplicationDto>> GetApplicationsAsync(Guid reviewerId);

        // check-applications
        Task<IEnumerable<JobApplicationDto>> GetJobApplicationsAsync(Guid jobId);

        //get application info
        Task<ApplicationSummaryDto> GetApplicationSummaryAsync(Guid applicationId);

        // getting cv for application-id
        Task<(byte[] FileBytes, string FileName)?> GetApplicationCVAsync(Guid applicationId);

        // getting assigned reviewers to application 
        Task<List<ReviewerDto>> GetAssignedReviewersAsync(Guid applicationId);

        // assign reviewer to an application
        Task<bool> AssignReviewerAsync(Guid applicationId, Guid reviewerId, Guid assignedById);


        // candidate use to APPLY 
        Task<bool> ApplyToJobAsync(Guid userId, Guid jobId);

        // te get skills to be reviewed
        Task<List<ReviewSkillDto>> GetReviewSkillsAsync(Guid applicationId, Guid userId);

        // te update skills reviewed
        Task UpdateReviewSkillsAsync(
            Guid applicationId,
            Guid reviewerId,
            List<UpdateReviewSkillDto> skills
        );


        // to get list of all comments 
        Task<List<RecruiterReviewDto>> GetAllReviewsAsync(Guid applicationId);
        // to get list of user comments 
        Task<List<ReviewCommentDto>> GetMyCommentsAsync(Guid applicationId, Guid userId);
        // to update comments
        Task<bool> UpdateMyCommentsAsync(Guid applicationId, Guid userId, List<UpdateReviewCommentDto> comments);


        // check if review submited by user
        Task<AssignedReviewer> GetAssignedReviewerAsync(Guid applicationId, Guid reviewerId);
        // finnally submit review
        Task SubmitReviewAsync(Guid applicationId, Guid reviewerId);
    }
    public class ApplicationsService : IApplicationsService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileUploadService _fileUploadService;

        public ApplicationsService(AppDbContext context, IMapper mapper, IFileUploadService fileUploadService)
        {
            _context = context;
            _mapper = mapper;
            _fileUploadService = fileUploadService;

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


        // check-applications
        public async Task<IEnumerable<JobApplicationDto>> GetJobApplicationsAsync(Guid jobId)
        {
            var job = await _context.Jobs
                .FirstOrDefaultAsync(j => j.JobId == jobId);

            if (job == null)
                throw new Exception("Job not found.");

            var applications = await _context.JobApplications
                .Include(a => a.CandidateProfile)
                .ThenInclude(cp => cp.User)
                .Where(a => a.JobId == jobId)
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

            return applications;
        }


        //get application info
        public async Task<ApplicationSummaryDto?> GetApplicationSummaryAsync(Guid applicationId)
        {
            //Job_Applications [status,applied on]
            //candidate summary [name,email]
            //job [position]

            //applicationId

            var jobApplication = await _context.JobApplications
                .Include(ja => ja.CandidateProfile)
                    .ThenInclude(cp => cp.User)
                .Include(ja => ja.Job)
                    .ThenInclude(j => j.JobDescription)
                .FirstOrDefaultAsync(ja => ja.JobApplicationId == applicationId);

            if (jobApplication == null)
                return null;

            return new ApplicationSummaryDto
            {
                JobApplicationId = jobApplication.JobApplicationId,
                ApplicationDate = jobApplication.ApplicationDate,
                CurrentStatus = jobApplication.CurrentStatus,
                FullName = jobApplication.CandidateProfile?.User != null
                    ? jobApplication.CandidateProfile.User.Fname + " " + jobApplication.CandidateProfile.User.Lname
                    : "Unknown",
                Email = jobApplication.CandidateProfile?.User?.Email ?? "Unknown",
                JobTitle = jobApplication.Job?.JobDescription?.Title ?? "Unknown"
            };

        }


        public async Task<(byte[] FileBytes, string FileName)?> GetApplicationCVAsync(Guid applicationId)
        {
            var application = await _context.JobApplications
            .Include(a => a.CandidateProfile)
            .FirstOrDefaultAsync(a => a.JobApplicationId == applicationId);

            if (application == null)
                return null;

            var userId = application.CandidateProfile.UserId;

            return _fileUploadService.DownloadPdf(userId);
        }


        // to get all assigned reviewer to application-id
        public async Task<List<ReviewerDto>> GetAssignedReviewersAsync(Guid applicationId)
        {
            var reviewers = await _context.AssignedReviewers
                .Include(ar => ar.Reviewer)
                .Where(ar => ar.JobApplicationId == applicationId && ar.isActive)
                .ToListAsync();

            var result = reviewers.Select(ar => new ReviewerDto
            {
                ReviewerId = ar.Uid,
                Name = $"{ar.Reviewer.Fname} {ar.Reviewer.Lname}",
                AssignedDate = ar.AssignedDate,
                Status = ar.IsReviewCompleted ? "Completed" : "Pending",
                ReviewedOn = ar.ReviewCompletedAt
            }).ToList();

            return result;
        }



        public async Task<bool> AssignReviewerAsync(Guid applicationId, Guid reviewerId, Guid assignedById)
        {
            // Check if reviewer exists
            var reviewerExists = await _context.Users.AnyAsync(u => u.UserId == reviewerId);
            if (!reviewerExists)
                throw new Exception("Reviewer does not exist.");

            // Check if assigning recruiter exists
            var assignerExists = await _context.Users.AnyAsync(u => u.UserId == assignedById);
            if (!assignerExists)
                throw new Exception("Assigning recruiter does not exist.");

            var role = await _context.EmployeeRoles.Where(e => e.RoleName == "Reviewer").FirstOrDefaultAsync();
            var roleExists = await _context.EmployeeUserRoles.AnyAsync(r =>
                r.UserId == reviewerId &&
                r.EmployeeRoleId == role.EmployeeRoleId);

            if (!roleExists)
            {
                _context.EmployeeUserRoles.Add(new EmployeeUserRole
                {
                    EmployeeRoleId = role.EmployeeRoleId,
                    UserId = reviewerId,
                    AssignedOn = DateTime.UtcNow
                });
            }


            var assignment = new AssignedReviewer
            {
                AssignedReviewersId = Guid.NewGuid(),
                JobApplicationId = applicationId,
                Uid = reviewerId,
                AssignedByUid = assignedById,
                AssignedDate = DateTime.UtcNow,
                isActive = true
            };

            _context.AssignedReviewers.Add(assignment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ApplyToJobAsync(Guid userId, Guid jobId)
        {
            var candidateProfile = await _context.CandidateProfiles
                .FirstOrDefaultAsync(c => c.UserId == userId);

            // check candidate
            if (candidateProfile == null)
                throw new Exception("Candidate profile not found.");

            var jobExists = await _context.Jobs.AnyAsync(j => j.JobId == jobId);
            if (!jobExists)
                throw new Exception("Job not found.");

            // check if applied
            bool alreadyApplied = await _context.JobApplications
                .AnyAsync(a => a.CandidateProfileId == candidateProfile.CandidateProfileId && a.JobId == jobId);

            if (alreadyApplied)
                throw new Exception("Already applied to this job.");

            // make new job application
            var newApplication = new JobApplication
            {
                JobApplicationId = Guid.NewGuid(),
                CandidateProfileId = candidateProfile.CandidateProfileId,
                JobId = jobId,
                ApplicationDate = DateTime.UtcNow,
                CurrentStatus = "Pending"
            };

            // saving commiting
            _context.JobApplications.Add(newApplication);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<ReviewSkillDto>> GetReviewSkillsAsync(Guid applicationId, Guid userId)
        {
            // getting the application with job skills
            var application = await _context.JobApplications
                .Include(a => a.Job)
                    .ThenInclude(j => j.JobSkills)
                        .ThenInclude(js => js.Skill)
                .FirstAsync(a => a.JobApplicationId == applicationId);

            // check if user is actually assigned
            var isAssigned = await _context.AssignedReviewers
                .AnyAsync(ar => ar.JobApplicationId == applicationId
                                && ar.Uid == userId
                                && ar.isActive);

            if (!isAssigned)
                return new List<ReviewSkillDto>();

            // getting already reviewed skills
            var reviewedSkills = await _context.ApplicationSkills
                .Where(x => x.JobApplicationId == applicationId && x.ReviewerId == userId)
                .ToListAsync();


            return application.Job.JobSkills.Select(js =>
            {
                var review = reviewedSkills.FirstOrDefault(r => r.SkillId == js.SkillId);

                return new ReviewSkillDto
                {
                    SkillId = js.SkillId,
                    SkillName = js.Skill.Name,
                    MinExperienceYears = js.MinExperienceYears,
                    HasSkill = review?.HasSkill,
                    YearsOfExperience = review?.ExperienceYears
                };
            }).ToList();
        }


        public async Task UpdateReviewSkillsAsync(Guid applicationId, Guid reviewerId, List<UpdateReviewSkillDto> skills)
        {
            // check if reviewer is assigned and active
            var isAssigned = await _context.AssignedReviewers
                .AnyAsync(ar => ar.JobApplicationId == applicationId
                                && ar.Uid == reviewerId
                                && ar.isActive);

            if (!isAssigned)
                throw new InvalidOperationException("You are not assigned to review this application.");

            foreach (var skill in skills)
            {
                var existing = await _context.ApplicationSkills.FirstOrDefaultAsync(x =>
                    x.JobApplicationId == applicationId &&
                    x.SkillId == skill.SkillId &&
                    x.ReviewerId == reviewerId
                );

                if (existing == null)
                {
                    _context.ApplicationSkills.Add(new ApplicationSkill
                    {
                        ApplicationSkillId = Guid.NewGuid(),
                        JobApplicationId = applicationId,
                        SkillId = skill.SkillId,
                        ReviewerId = reviewerId,
                        HasSkill = skill.HasSkill,
                        ExperienceYears = skill.YearsOfExperience
                    });
                }
                else
                {
                    existing.HasSkill = skill.HasSkill;
                    existing.ExperienceYears = skill.YearsOfExperience;
                }
            }

            // Commit changes to the database
            await _context.SaveChangesAsync();
        }



        public async Task<List<RecruiterReviewDto>> GetAllReviewsAsync(Guid applicationId)
        {
            // getin all asigend users-id to the application
            var reviewers = await _context.AssignedReviewers
                .Include(ar => ar.Reviewer)
                .Where(ar => ar.JobApplicationId == applicationId && ar.isActive)
                .ToListAsync();
            var reviewerIds = reviewers.Select(r => r.Uid).ToList();

            // getting there review comments
            var comments = await _context.ReviewComments
                .Where(c => c.JobApplicationId == applicationId &&
                            reviewerIds.Contains(c.CommentedByUid))
                .Select(c => new ReviewCommentDto
                {
                    ReviewCommentId = c.ReviewCommentId,
                    CommentedByUid = c.CommentedByUid,
                    CommentedByName = c.CommentedBy.Fname + " " + c.CommentedBy.Lname,
                    CommentText = c.CommentText,
                    CommentDate = c.CommentDate
                })
                .ToListAsync();


            // gettin there skill reviews
            var skills = await _context.ApplicationSkills
                .Where(s => s.JobApplicationId == applicationId &&
                            reviewerIds.Contains(s.ReviewerId)
                            )
                .Select(s => new ReviewSkillDto
                {
                    SkillId = s.SkillId,
                    SkillName = s.Skill.Name,
                    HasSkill = s.HasSkill,
                    YearsOfExperience = s.ExperienceYears,
                    ReviewerId = s.ReviewerId
                })
                .ToListAsync();

            // making dto
            // making dto
            var result = reviewers
                .Select(r => new RecruiterReviewDto
                {
                    UserId = r.Uid,
                    UserName = r.Reviewer.Fname + " " + r.Reviewer.Lname,
                    Comments = comments
                        .Where(c => c.CommentedByUid == r.Uid)
                        .ToList(),
                    Skills = skills
                        .Where(s => s.ReviewerId == r.Uid)
                        .ToList(),
                    ReviewCompleted = r.IsReviewCompleted
                })
                .ToList();


            return result;
        }

        public async Task<List<ReviewCommentDto>> GetMyCommentsAsync(Guid applicationId, Guid userId)
        {
            return await _context.ReviewComments
                .Include(c => c.JobApplication)
                    .ThenInclude(ja => ja.AssignedReviewers)
                .Include(c => c.CommentedBy)
                .Where(c => c.JobApplicationId == applicationId
                            && c.CommentedByUid == userId
                            && c.JobApplication.AssignedReviewers.Any(ar => ar.Uid == userId)) // used any as multiple navs
                .OrderByDescending(c => c.CommentDate)
                .Select(c => new ReviewCommentDto
                {
                    ReviewCommentId = c.ReviewCommentId,
                    CommentedByUid = c.CommentedByUid,
                    CommentedByName = c.CommentedBy.Fname + " " + c.CommentedBy.Lname,
                    CommentText = c.CommentText,
                    CommentDate = c.CommentDate
                })
                .ToListAsync();
        }


        public async Task<bool> UpdateMyCommentsAsync(Guid applicationId, Guid userId, List<UpdateReviewCommentDto> comments)
        {
            //tried add,update, delete in one

            var assignedReviewer = await _context.AssignedReviewers
                .FirstOrDefaultAsync(ar =>
                    ar.JobApplicationId == applicationId &&
                    ar.Uid == userId &&
                    ar.isActive);

            if (assignedReviewer == null) return false;

            // first check if there are any already store review notes on application
            //also check if they are by the sender
            var existing = await _context.ReviewComments
                .Where(c => c.JobApplicationId == applicationId
                         && c.CommentedByUid == userId)
                .ToListAsync();

            // filter out all old reviews
            var incomingIds = comments
                .Where(c => c.ReviewCommentId.HasValue)
                .Select(c => c.ReviewCommentId!.Value)
                .ToHashSet();

            // existing - incoming are delete
            var toDelete = existing
                .Where(e => !incomingIds.Contains(e.ReviewCommentId))
                .ToList();

            _context.ReviewComments.RemoveRange(toDelete);

            //now loop thru list
            foreach (var dto in comments)
            {
                // add coed
                if (dto.ReviewCommentId == null)
                {
                    _context.ReviewComments.Add(new ReviewComment
                    {
                        ReviewCommentId = Guid.NewGuid(),
                        JobApplicationId = applicationId,
                        CommentedByUid = userId,
                        CommentText = dto.CommentText,
                        CommentDate = DateTime.UtcNow
                    });
                    continue;
                }

                // update code
                var existingComment = existing
                    .FirstOrDefault(e => e.ReviewCommentId == dto.ReviewCommentId);

                if (existingComment != null)
                {
                    existingComment.CommentText = dto.CommentText;
                    existingComment.CommentDate = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        //get reviw status 
        public async Task<AssignedReviewer> GetAssignedReviewerAsync(Guid applicationId, Guid reviewerId)
        {
            var assignedReviewer = await _context.AssignedReviewers
                .FirstOrDefaultAsync(ar =>
                    ar.JobApplicationId == applicationId &&
                    ar.Uid == reviewerId &&
                    ar.isActive);

            return assignedReviewer;
        }

        // submit and lock review
        public async Task SubmitReviewAsync(Guid applicationId, Guid reviewerId)
        {
            // check if the reviewer was actually assigned or not
            var assignedReviewer = await _context.AssignedReviewers
                .FirstOrDefaultAsync(ar =>
                    ar.JobApplicationId == applicationId &&
                    ar.Uid == reviewerId &&
                    ar.isActive);

            if (assignedReviewer == null)
                throw new InvalidOperationException("Reviewer not assigned to this application.");

            // mark review as completed set tru and time
            assignedReviewer.IsReviewCompleted = true;
            assignedReviewer.ReviewCompletedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }


    }

}
