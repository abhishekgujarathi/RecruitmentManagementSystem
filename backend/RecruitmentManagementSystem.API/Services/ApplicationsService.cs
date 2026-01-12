using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Common;
using RecruitmentManagementSystem.API.Common.Enums;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;
using System;

namespace RecruitmentManagementSystem.API.Services
{
    public interface IApplicationsService
    {
        // updating status [now all status are coverd]
        Task UpdateApplicationStatusAsync(Guid applicationId, Guid recruiterId, UpdateApplicationStatusDto dto);

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

        // for bulk status changes
        Task<bool> UpdateBulkApplicationStatusAsync(List<Guid> applicationIds, Guid recruiterId, string newStatus, string note = null);
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
                .Where(a =>
                    a.AssignedReviewers.Any(ar => ar.ReviewerUserId == reviewerId))
                .Select(a => new JobApplicationDto
                {
                    JobApplicationId = a.JobApplicationId,

                    CandidateName =
                        a.CandidateProfile.User.Fname + " " +
                        a.CandidateProfile.User.Lname,

                    ApplicationDate = a.ApplicationDate,
                    CurrentStatus = a.CurrentStatus,
                    CandidateProfileId = a.CandidateProfileId,
                    StatusUpdatedAt = a.StatusUpdatedAt,

                    ReviewCompleted = a.AssignedReviewers.Any(ar =>
                        ar.ReviewerUserId == reviewerId &&
                        ar.IsReviewCompleted)
                })
                .ToListAsync();

            var a = applications;

            return applications;
        }


        // get all applications on job
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
                    ApplicationId = a.JobApplicationId,
                    StatusUpdatedAt = a.StatusUpdatedAt
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
                ReviewerId = ar.ReviewerUserId,
                Name = $"{ar.Reviewer.Fname} {ar.Reviewer.Lname}",
                AssignedDate = ar.AssignedDate,
                Status = ar.IsReviewCompleted ? "Completed" : "Pending",
                ReviewedOn = ar.ReviewCompletedAt
            }).ToList();

            return result;
        }



        public async Task<bool> AssignReviewerAsync(Guid applicationId, Guid reviewerId, Guid assignedById)
        {
            // chek if reviewer exists
            var reviewerExists = await _context.Users.AnyAsync(u => u.UserId == reviewerId);
            if (!reviewerExists)
                throw new Exception("Reviewer does not exist.");

            // check if assigning recruiter exists
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
                ReviewerUserId = reviewerId,
                AssignedByUid = assignedById,
                AssignedDate = DateTime.UtcNow,
                isActive = true
            };

            var application = await _context.JobApplications.FirstOrDefaultAsync(ja => ja.JobApplicationId == applicationId);

            application.CurrentStatus = ApplicationStatus.UnderReview;
            application.StatusUpdatedAt = DateTime.UtcNow;

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

             var jobReviewers = await _context.JobReviewers.Where(jr => jr.JobId == jobId).ToListAsync();

            // make new job application
            var newApplication = new JobApplication
            {
                JobApplicationId = Guid.NewGuid(),
                CandidateProfileId = candidateProfile.CandidateProfileId,
                JobId = jobId,
                ApplicationDate = DateTime.UtcNow,
                CurrentStatus = ApplicationStatus.Applied,
                AssignedReviewers = new List<AssignedReviewer>()
            };

            // mapping each alrdy assigned reviewer to position to application
            foreach (var jr in jobReviewers)
            {
                newApplication.AssignedReviewers.Add(new AssignedReviewer
                {
                    AssignedReviewersId = Guid.NewGuid(),
                    JobApplicationId = newApplication.JobApplicationId,
                    ReviewerUserId = jr.ReviewerId,
                    AssignedDate = DateTime.UtcNow,
                    AssignedByUid = jr.AssignedBy,
                    isActive = true
                });
            }



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
                                && ar.ReviewerUserId == userId
                                && ar.isActive);

            if (!isAssigned)
                return new List<ReviewSkillDto>();

            // getting already reviewed skills
            var reviewedSkills = await _context.ApplicationSkills
                .Where(x => x.JobApplicationId == applicationId && x.ReviewerId == userId)
                .ToListAsync();

            var res = application.Job.JobSkills.Select(js =>
            {
                // check if already reviewed and if get the review
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

            return res;
        }


        public async Task UpdateReviewSkillsAsync(Guid applicationId, Guid reviewerId, List<UpdateReviewSkillDto> skills)
        {
            // check if reviewer is assigned and active
            var isAssigned = await _context.AssignedReviewers
                .AnyAsync(ar => ar.JobApplicationId == applicationId
                                && ar.ReviewerUserId == reviewerId
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
                    var aplSkill = new ApplicationSkill
                    {
                        ApplicationSkillId = Guid.NewGuid(),
                        JobApplicationId = applicationId,
                        SkillId = skill.SkillId,
                        ReviewerId = reviewerId,
                        HasSkill = skill.HasSkill,
                        ExperienceYears = skill.YearsOfExperience
                    };
                    _context.ApplicationSkills.Add(aplSkill);
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
            var reviewerIds = reviewers.Select(r => r.ReviewerUserId).ToList();

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
                    UserId = r.ReviewerUserId,
                    UserName = r.Reviewer.Fname + " " + r.Reviewer.Lname,
                    Comments = comments
                        .Where(c => c.CommentedByUid == r.ReviewerUserId)
                        .ToList(),
                    Skills = skills
                        .Where(s => s.ReviewerId == r.ReviewerUserId)
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
                            && c.JobApplication.AssignedReviewers.Any(ar => ar.ReviewerUserId == userId)) 
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
                    ar.ReviewerUserId == userId &&
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
                .Select(c => c.ReviewCommentId.Value)
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
                    var rComment = new ReviewComment
                    {
                        ReviewCommentId = Guid.NewGuid(),
                        JobApplicationId = applicationId,
                        CommentedByUid = userId,
                        CommentText = dto.CommentText,
                        CommentDate = DateTime.UtcNow
                    };

                    _context.ReviewComments.Add(rComment);
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
                    ar.ReviewerUserId == reviewerId &&
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
                    ar.ReviewerUserId == reviewerId &&
                    ar.isActive);

            if (assignedReviewer == null)
                throw new InvalidOperationException("Reviewer not assigned to this application.");

            // mark review as completed set tru and time
            assignedReviewer.IsReviewCompleted = true;
            assignedReviewer.ReviewCompletedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateApplicationStatusAsync(Guid applicationId, Guid recruiterId, UpdateApplicationStatusDto dto)
        {
            // ??? check for onHold - where to go from onHold?

            // vallidating if status is null
            if (string.IsNullOrWhiteSpace(dto.NewStatus))
                throw new InvalidOperationException("New status is required.");


            // chek application
            var application = await _context.JobApplications
                .Include(a => a.Job)
                .Include(a => a.AssignedReviewers)
                .FirstOrDefaultAsync(a => a.JobApplicationId == applicationId);
            if (application == null)
                throw new InvalidOperationException("Application not found.");


            // getting status
            var currentStatus = application.CurrentStatus ?? ApplicationStatus.Applied;
            var newStatus = dto.NewStatus;

            // checkin for final status
            if (ApplicationStatus.FinalStatuses.Contains(currentStatus))
                throw new InvalidOperationException(
                    $"Cannot change status once application is {currentStatus}."
                );

            // usin rules of changing status
            if (!ApplicationStatus.AllowedTransitions.TryGetValue(currentStatus, out var allowedNext) ||
                !allowedNext.Contains(newStatus))
            {
                throw new InvalidOperationException(
                    $"Invalid status transition from {currentStatus} to {newStatus}."
                );
            }

            // specific checking for note on hold
            if (newStatus == ApplicationStatus.OnHold &&
                string.IsNullOrWhiteSpace(dto.Note))
            {
                throw new InvalidOperationException(
                    "OnHold status requires a note."
                );
            }

            if (newStatus == ApplicationStatus.Shortlisted)
            {
                var hasPendingReviews = application.AssignedReviewers
                    .Any(r => r.isActive && !r.IsReviewCompleted);

                if (hasPendingReviews)
                    throw new InvalidOperationException(
                        "All reviewers must complete their reviews before shortlisting."
                    );
            }

            // check for test
            if (newStatus == ApplicationStatus.TestPassed &&
                currentStatus != ApplicationStatus.TestScheduled)
            {
                throw new InvalidOperationException(
                    "Test must be scheduled before marking it as passed."
                );
            }

            // check for interview
            if (newStatus == ApplicationStatus.InterviewCompleted &&
                currentStatus != ApplicationStatus.InterviewInProgress)
            {
                throw new InvalidOperationException(
                    "Interview must be scheduled before marking it as passed."
                );
            }


            // updating status of application
            application.CurrentStatus = newStatus;
            application.StatusUpdatedAt = DateTime.UtcNow;

            // note
            if (newStatus == ApplicationStatus.OnHold)
                application.StatusNote = dto.Note;
            else
                application.StatusNote = null;


            // inserting interview rounds for application from default job rounds
            if (newStatus == ApplicationStatus.InterviewInProgress)
            {
                // reuse above jobid
                var jobId = application.JobId;
                var intrwRounds = await _context.JobInterviewRounds
                    .Where(ir => ir.JobId == jobId)
                    .ToListAsync();

                // check if already interview rounds are applied if applied dont apply
                if (!_context.ApplicationInterviewRounds.Any(a => a.JobApplicationId == applicationId))
                {
                    foreach (var ir in intrwRounds)
                    {
                        var round = new ApplicationInterviewRound
                        {
                            ApplicationInterviewRoundId = Guid.NewGuid(),
                            JobApplicationId = applicationId,
                            RoundNumber = ir.RoundNumber,
                            RoundType = ir.RoundType,
                            Status = InterviewRoundStatus.Pending
                        };
                        _context.ApplicationInterviewRounds.Add(round);
                    }
                }
            }


            // atlast savin changes
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateBulkApplicationStatusAsync(List<Guid> applicationIds, Guid recruiterId, string newStatus, string note = null)
        {
            // checking if new status 
            if (string.IsNullOrWhiteSpace(newStatus))
                throw new InvalidOperationException("New status is required.");

            // checking i hold note there
            if (newStatus == ApplicationStatus.OnHold && string.IsNullOrWhiteSpace(note))
                throw new InvalidOperationException("OnHold status requires a note.");

            // getting alll applications
            var applications = await _context.JobApplications
                .Include(a => a.Job)
                .Include(a => a.AssignedReviewers)
                .Where(a => applicationIds.Contains(a.JobApplicationId))
                .ToListAsync();

            var error = 0;
            // loopin thru all applications
            foreach (var application in applications)
            {
                try
                {
                    var currentStatus = application.CurrentStatus ?? ApplicationStatus.Applied;

                    if (ApplicationStatus.FinalStatuses.Contains(currentStatus))
                        continue; // cant change rejected or hired

                    if (!ApplicationStatus.AllowedTransitions.TryGetValue(currentStatus, out var allowedNext) ||
                        !allowedNext.Contains(newStatus))
                        continue; // check valid transition


                    // imp check all reviews complete
                    if (newStatus == ApplicationStatus.Shortlisted)
                    {
                        var hasPendingReviews = application.AssignedReviewers
                            .Any(r => r.isActive && !r.IsReviewCompleted);

                        if (hasPendingReviews)
                            continue;
                    }

                    // if test passed and test scheduled then move forward otherwise skip whole application
                    if (newStatus == ApplicationStatus.TestPassed &&
                        currentStatus != ApplicationStatus.TestScheduled)
                        continue;

                    // validate interview passed
                    if (newStatus == ApplicationStatus.InterviewCompleted &&
                        currentStatus != ApplicationStatus.InterviewInProgress)
                        continue;

                    // updating status
                    application.CurrentStatus = newStatus;
                    application.StatusUpdatedAt = DateTime.UtcNow;

                    if (newStatus == ApplicationStatus.OnHold)
                        application.StatusNote = note;
                    else
                        application.StatusNote = null;


                    // inserting interview rounds for application from default job rounds
                    if (newStatus == ApplicationStatus.InterviewInProgress)
                    {
                        // reuse above jobid
                        var jobId = application.JobId;
                        var intrwRounds = await _context.JobInterviewRounds
                            .Where(ir => ir.JobId == jobId)
                            .ToListAsync();

                        // check if already interview rounds are applied if applied dont apply
                        if (!_context.ApplicationInterviewRounds.Any(a => a.JobApplicationId == application.JobApplicationId))
                        {
                            foreach (var ir in intrwRounds)
                            {
                                var round = new ApplicationInterviewRound
                                {
                                    ApplicationInterviewRoundId = Guid.NewGuid(),
                                    JobApplicationId = application.JobApplicationId,
                                    RoundNumber = ir.RoundNumber,
                                    RoundType = ir.RoundType,
                                    Status = InterviewRoundStatus.Pending
                                };
                                _context.ApplicationInterviewRounds.Add(round);

                                // saved at last of method
                            }
                        }
                    }
                }
                catch
                {
                    error += 1;
                    continue;
                }
            }

            await _context.SaveChangesAsync();
            return error > 0;
        }

    }

}
