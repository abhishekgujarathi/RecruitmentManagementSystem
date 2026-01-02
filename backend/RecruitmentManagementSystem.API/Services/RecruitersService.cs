using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.Services
{

    public interface IRecruitersService
    {
        // recruiters can
        // create-job
        public Task<JobResponseDto?> CreateJobAsync(JobCreateRequestDto request, Guid recruiterId);
        //return created job
        // update-job
        public Task<JobResponseDto?> UpdateJobAsync(Guid jobId, JobUpdateRequestDto request, Guid recruiterId);
        //return updated job

        // delete-job
        Task<bool> DeleteJobAsync(Guid jobId, Guid recruiterId);

        //return true if deleted 

        // check-applications
        Task<IEnumerable<JobApplicationDto>> GetJobApplicationsAsync(Guid jobId);

        //get application info
        Task<ApplicationSummaryDto> GetApplicationSummaryAsync(Guid applicationId);
        Task<(byte[] FileBytes, string FileName)?> GetApplicationCVAsync(Guid applicationId);


        // reviewer 
        Task<List<ReviewerDto>> GetAssignedReviewersAsync(Guid applicationId);
        Task<bool> AssignReviewerAsync(Guid applicationId, Guid reviewerId, Guid assignedById);

        // unused
        Task<RecruiterCandidateProfileDto> GetRecruiterCandidate(Guid candidateId);
        // unused

    }


    public class RecruitersService : IRecruitersService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileUploadService _fileUploadService;

        public RecruitersService(AppDbContext context, IMapper mapper, IFileUploadService fileUploadService)
        {
            _context = context;
            _mapper = mapper;
            _fileUploadService = fileUploadService;

        }

        public async Task<JobResponseDto?> CreateJobAsync(JobCreateRequestDto request, Guid recruiterId)
        {
            var jobType = await _context.JobTypes
                .FirstOrDefaultAsync(jt => jt.TypeName == request.TypeName);

            if (jobType == null)
            {
                return null;
            }

            var jobDescription = new JobDescription
            {
                JobDescriptionId = Guid.NewGuid(),
                Title = request.Title,
                Details = request.Details,
                Responsibilty = request.Responsibilities,
                Location = request.Location,
                MinimumExperienceReq = request.MinimumExperienceReq,
                JobTypeId = jobType.JobTypeId,
            };
            _context.JobDescriptions.Add(jobDescription);

            var job = new Job
            {
                JobId = Guid.NewGuid(),
                OpeningsCount = request.OpeningsCount,
                CreatedDate = DateTime.UtcNow,
                DeadlineDate = request.DeadlineDate,
                JobDescriptionId = jobDescription.JobDescriptionId,
                CreatedByUserId = recruiterId
            };
            _context.Jobs.Add(job);

            await _context.SaveChangesAsync();

            return new JobResponseDto
            {
                JobId = job.JobId,
                JobDescription = new JobDescriptionDto
                {
                    Title = jobDescription.Title,
                    Location = jobDescription.Location,
                    JobType = jobType.TypeName,
                    Details = jobDescription.Details,
                    Responsibilities = jobDescription.Responsibilty,
                    MinimumExperienceReq = jobDescription.MinimumExperienceReq
                },
                OpeningsCount = job.OpeningsCount,
                DeadlineDate = job.DeadlineDate,
                CreatedDate = job.CreatedDate,
                LastModifiedDate = job.LastModifiedDate,
                CreatedByUserId = recruiterId
            };
        }

        public async Task<bool> DeleteJobAsync(Guid jobId, Guid recruiterId)
        {
            var job = await _context.Jobs
                .Include(j => j.JobDescription)
                .FirstOrDefaultAsync(j => j.JobId == jobId);

            if (job == null)
            {
                return false;
            }

            // check if the recruiter owns this job
            if (job.CreatedByUserId != recruiterId)
            {
                throw new UnauthorizedAccessException("You can only delete your own jobs");
            }

            // delete JobDescription first (if not used by other jobs)
            var isJobDescUsedElsewhere = await _context.Jobs
                .AnyAsync(j => j.JobDescriptionId == job.JobDescriptionId && j.JobId != jobId);

            if (!isJobDescUsedElsewhere)
            {
                _context.JobDescriptions.Remove(job.JobDescription);
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<JobResponseDto?> UpdateJobAsync(Guid jobId, JobUpdateRequestDto request, Guid recruiterId)
        {
            var job = await _context.Jobs
                .Include(j => j.JobDescription)
                    .ThenInclude(jd => jd.JobType)
                .FirstOrDefaultAsync(j => j.JobId == jobId);

            if (job == null)
            {
                return null;
            }

            // check if the recruiter owns this job
            if (job.CreatedByUserId != recruiterId)
            {
                throw new UnauthorizedAccessException("You can only update your own jobs");
            }

            // update JobDescription fields
            if (!string.IsNullOrWhiteSpace(request.Title))
                job.JobDescription.Title = request.Title;

            if (!string.IsNullOrWhiteSpace(request.Details))
                job.JobDescription.Details = request.Details;

            if (request.Responsibilities != null)
                job.JobDescription.Responsibilty = request.Responsibilities;

            if (!string.IsNullOrWhiteSpace(request.Location))
                job.JobDescription.Location = request.Location;

            if (request.MinimumExperienceReq.HasValue)
                job.JobDescription.MinimumExperienceReq = request.MinimumExperienceReq.Value;

            // update JobType if provided
            if (!string.IsNullOrWhiteSpace(request.TypeName))
            {
                var jobType = await _context.JobTypes
                    .FirstOrDefaultAsync(jt => jt.TypeName == request.TypeName);

                if (jobType == null)
                {
                    return null; 
                }

                job.JobDescription.JobTypeId = jobType.JobTypeId;
            }

            // update Job fields 
            if (request.OpeningsCount.HasValue)
                job.OpeningsCount = request.OpeningsCount.Value;

            if (request.DeadlineDate.HasValue)
                job.DeadlineDate = request.DeadlineDate.Value;

            job.LastModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // reload to get the updated JobType
            await _context.Entry(job.JobDescription).Reference(jd => jd.JobType).LoadAsync();

            return MapToResponseDto(job);
        }


        private JobResponseDto MapToResponseDto(Job job)
        {
            return new JobResponseDto
            {
                JobId = job.JobId,
                JobDescription = new JobDescriptionDto
                {
                    Title = job.JobDescription.Title,
                    Location = job.JobDescription.Location,
                    JobType = job.JobDescription.JobType.TypeName,
                    Details = job.JobDescription.Details,
                    Responsibilities = job.JobDescription.Responsibilty,
                    MinimumExperienceReq = job.JobDescription.MinimumExperienceReq
                },
                OpeningsCount = job.OpeningsCount,
                DeadlineDate = job.DeadlineDate,
                CreatedDate = job.CreatedDate,
                LastModifiedDate = job.LastModifiedDate,
                CreatedByUserId = job.CreatedByUserId
            };
        }

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


        // --- review ---
        public async Task<List<ReviewerDto>> GetAssignedReviewersAsync(Guid applicationId)
        {
            var reviewers = await _context.AssignedReviewers
                .Include(ar => ar.Reviewer)           
                .Include(ar => ar.CVReviewStages)     
                .Where(ar => ar.JobApplicationId == applicationId && ar.isActive)
                .ToListAsync();

            var result = reviewers.Select(ar =>
            {
                var reviewStage = ar.CVReviewStages
                    .FirstOrDefault(cvs => cvs.JobApplicationId == applicationId && cvs.ReviewedByUid == ar.Uid);

                return new ReviewerDto
                {
                    ReviewerId = ar.Uid,
                    Name = $"{ar.Reviewer.Fname} {ar.Reviewer.Lname}",
                    AssignedDate = ar.AssignedDate,
                    Status = reviewStage != null ? "Completed" : "Pending",
                    ReviewedOn = reviewStage?.ReviewDate
                };
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

        // --- review ---


        //not used now
        public async Task<RecruiterCandidateProfileDto> GetRecruiterCandidate(Guid candidateId)
        {

            var profile = await _context.CandidateProfiles
                .Include(cp => cp.User)
                .Include(cp => cp.Educations)
                .Include(cp => cp.Experiences)
                .Include(cp => cp.CandidateSkills)
                    .ThenInclude(cs => cs.Skill)
                .FirstOrDefaultAsync(cp => cp.CandidateProfileId == candidateId);

            if (profile == null)
                return null;

            var resultDto = _mapper.Map<RecruiterCandidateProfileDto>(profile);

            return resultDto;
        }
        //not used now



    }
}