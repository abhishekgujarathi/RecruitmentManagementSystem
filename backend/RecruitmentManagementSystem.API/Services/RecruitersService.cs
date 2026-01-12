using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Common;
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
        public Task<bool?> UpdateJobAsync(Guid jobId, JobUpdateRequestDto request, Guid recruiterId);
        //return updated job

        // delete-job
        Task<bool> DeleteJobAsync(Guid jobId, Guid recruiterId);

        //return true if deleted 

        //list of emplyees return
        Task<List<KeyValuePair<Guid, string>>> GetAllEmployeesForReviewAsync(Guid applicationId);
        Task<List<KeyValuePair<Guid, string>>> AllReviewersAsync();

        Task<bool> AssignDefaultJobReviewerAsync(Guid jobId, Guid reviewerId, Guid assignedByUserId);
        Task<bool> RemoveDefaultJobReviewerAsync(Guid jobId, Guid reviewerId, Guid recruiterId);
        Task<List<KeyValuePair<Guid, string>>> GetDefaultJobReviewerAsync(Guid jobId);

        Task<bool> CloseJobAsync(Guid jobId, Guid recruiterId, string reason);

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

            _context.JobInterviewRounds.AddRange(
                new JobInterviewRound { JobInterviewRoundId = Guid.NewGuid(), JobId = job.JobId, RoundNumber = 1, RoundType = InterviewRoundType.Technical },
                new JobInterviewRound { JobInterviewRoundId = Guid.NewGuid(), JobId = job.JobId, RoundNumber = 2, RoundType = InterviewRoundType.Technical },
                new JobInterviewRound { JobInterviewRoundId = Guid.NewGuid(), JobId = job.JobId, RoundNumber = 3, RoundType = InterviewRoundType.HR }

                );

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
                CreatedByUserId = recruiterId,
                JobSkills = job.JobSkills
                        .Select(js => new JobSkillDto
                        {
                            SkillId = js.SkillId,
                            SkillName = js.Skill.Name
                        })
                        .ToList(),
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

        public async Task<bool?> UpdateJobAsync(Guid jobId, JobUpdateRequestDto request, Guid recruiterId)
        {
            var job = await _context.Jobs
                .Include(j => j.JobDescription)
                    .ThenInclude(jd => jd.JobType)
                .Include(j => j.JobSkills)
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

            if (request.SkillIds != null)
            {
                // remove existing skills
                _context.JobSkills.RemoveRange(job.JobSkills);

                // validate skills exist
                var validSkillIds = await _context.Skills
                    .Where(s => request.SkillIds.Contains(s.SkillId))
                    .Select(s => s.SkillId)
                    .ToListAsync();

                if (validSkillIds.Count != request.SkillIds.Count)
                    throw new ArgumentException("One or more skills are invalid");

                // add new skills
                job.JobSkills = validSkillIds
                    .Select(skillId => new JobSkill
                    {
                        JobId = job.JobId,
                        SkillId = skillId
                    })
                    .ToList();
            }

            await _context.SaveChangesAsync();

            // reload to get the updated JobType
            //await _context.Entry(job.JobDescription).Reference(jd => jd.JobType).LoadAsync();

            //return MapToResponseDto(job);
            return false;
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
                CreatedByUserId = job.CreatedByUserId,
                JobSkills = job.JobSkills
                        .Select(js => new JobSkillDto
                        {
                            SkillId = js.SkillId,
                            SkillName = js.Skill.Name
                        })
                        .ToList(),
            };
        }

        // return list of all employees
        public async Task<List<KeyValuePair<Guid, string>>> GetAllEmployeesForReviewAsync(Guid applicationId)
        {

            // getting alredy assigned reviewers
            var assignedReviewerIds = await _context.AssignedReviewers
               .Where(ar => ar.JobApplicationId == applicationId)
               .Select(ar => ar.ReviewerUserId)
               .ToListAsync();

            var result = await _context.Users
                .Where(u =>
                    u.IsActive &&
                    u.UserType.TypeName == "Employee"

                // returning all employees
                // && u.EmployeeUserRoles.Any(eur =>
                //    //eur.EmployeeRole.RoleName == "Reviewer"
                //) 
                //&&
                // filltring alredy assigned to the applicatwion id
                //!assignedReviewerIds.Contains(u.UserId)
                )
                .Select(u => new KeyValuePair<Guid, string>(
                    u.UserId,
                    u.Fname + " " + u.Lname
                ))
                .ToListAsync();

            return result;
        }
        public async Task<List<KeyValuePair<Guid, string>>> AllReviewersAsync()
        {

            // getting alredy assigned reviewers
            var assignedReviewerIds = await _context.AssignedReviewers
               //.Where(ar => ar.JobApplicationId == applicationId)
               .Select(ar => ar.ReviewerUserId)
               .ToListAsync();

            var result = await _context.Users
                .Where(u =>
                    u.IsActive &&
                    u.UserType.TypeName == "Employee"

                // returning all employees
                 && u.EmployeeUserRoles.Any(eur =>
                    eur.EmployeeRole.RoleName == "Reviewer"
                )
                //&&
                // filltring alredy assigned to the application id
                //!assignedReviewerIds.Contains(u.UserId)
                )
                .Select(u => new KeyValuePair<Guid, string>(
                    u.UserId,
                    u.Fname + " " + u.Lname
                ))
                .ToListAsync();

            return result;
        }


        public async Task<bool> AssignDefaultJobReviewerAsync(Guid jobId, Guid reviewerId, Guid assignedByUserId)
        {
            var jobExists = await _context.Jobs.AnyAsync(j => j.JobId == jobId);
            if (!jobExists) return false;

            var alreadyAssigned = await _context.JobReviewers.AnyAsync(jr =>
                jr.JobId == jobId &&
                jr.ReviewerId == reviewerId &&
                jr.IsActive);

            if (alreadyAssigned)
                return true;

            var jobReviewer = new JobReviewer
            {
                JobReviewerId = Guid.NewGuid(),
                JobId = jobId,
                ReviewerId = reviewerId,
                AssignedBy = assignedByUserId,
                IsActive = true
            };

            _context.JobReviewers.Add(jobReviewer);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> RemoveDefaultJobReviewerAsync(Guid jobId, Guid reviewerId, Guid recruiterId)
        {
            var jobReviewer = await _context.JobReviewers
                .FirstOrDefaultAsync(jr =>
                    jr.JobId == jobId &&
                    jr.ReviewerId == reviewerId &&
                    jr.IsActive);

            if (jobReviewer == null)
                return false;

            jobReviewer.IsActive = false;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<KeyValuePair<Guid, string>>> GetDefaultJobReviewerAsync(Guid jobId)
        {
            var reviewers = await _context.JobReviewers
                .Include(jr => jr.Reviewer)
                .Where(jr => jr.JobId == jobId && jr.IsActive)
                .Select(jr => new KeyValuePair<Guid, string>(
                    jr.ReviewerId,
                    jr.Reviewer.Fname + " " + jr.Reviewer.Lname
                ))
                .ToListAsync();

            return reviewers;
        }
        public async Task<bool> CloseJobAsync(Guid jobId, Guid recruiterId, string reason)
        {
            var job = await _context.Jobs
                .FirstOrDefaultAsync(j => j.JobId == jobId);

            if (job == null)
                return false;

            // prevent double close
            if (job.IsClosed == "Closed")
                return false;

            job.IsClosed = "Closed";
            job.ClosedDate = DateTime.UtcNow;
            job.CloseReason = reason;

            await _context.SaveChangesAsync();
            return true;
        }


    }
}