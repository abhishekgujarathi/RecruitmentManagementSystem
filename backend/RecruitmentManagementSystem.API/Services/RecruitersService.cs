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

        //list of emplyees return
        Task<List<KeyValuePair<Guid, string>>> GetAllEmployeesForReviewAsync(Guid applicationId);
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

        // return list of all employees
        public async Task<List<KeyValuePair<Guid, string>>> GetAllEmployeesForReviewAsync(Guid applicationId)
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
    }
}