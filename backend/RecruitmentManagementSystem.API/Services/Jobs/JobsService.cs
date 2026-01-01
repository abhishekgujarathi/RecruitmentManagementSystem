using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Common.Enums;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.Services.Jobs
{
    public interface IJobsService
    {
        Task<ICollection<JobResponseDto>> GetJobsAsync(Guid userId, UserRoleType userRoleType);
        Task<JobResponseDto?> GetJobAsync(Guid jobID, Guid userId, UserRoleType userRoleType);


    }
    public class JobsService : IJobsService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public JobsService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ICollection<JobResponseDto>> GetJobsAsync(Guid userId, UserRoleType userRoleType)
        {
            Guid? candidateProfileId = null;

            if (userRoleType == UserRoleType.Candidate && userId != Guid.Empty)
            {
                var candidateProfile = await _context.CandidateProfiles.FirstOrDefaultAsync(c => c.UserId == userId);
                candidateProfileId = candidateProfile.CandidateProfileId;
            }

            var jobs = await _context.Jobs
                .Include(job => job.JobDescription)
                .ThenInclude(jd => jd.JobType)
                .Include(jod => jod.CreatedByUser)
                .Select(job => new JobResponseDto()
                {
                    JobId = job.JobId,
                    OpeningsCount = job.OpeningsCount,
                    CreatedDate = job.CreatedDate,
                    DeadlineDate = job.DeadlineDate,
                    JobDescription = new JobDescriptionDto
                    {
                        JobDescriptionId = job.JobDescription.JobDescriptionId,
                        Title = job.JobDescription.Title,
                        Details = job.JobDescription.Details,
                        Location = job.JobDescription.Location,
                        MinimumExperienceReq = job.JobDescription.MinimumExperienceReq,
                        JobType = job.JobDescription.JobType.TypeName,
                        Responsibilities = job.JobDescription.Responsibilty

                    },
                    CreatedByUserId = job.CreatedByUserId,
                    IsApplied = candidateProfileId != null
                    ? job.Applications.Any(appli => appli.CandidateProfileId == candidateProfileId.Value)
                    : null,
                })
                .ToListAsync();

            //if (userRoleType == UserRoleType.Candidate)
            //{

            //}

            return jobs;
        }

        public async Task<JobResponseDto?> GetJobAsync(Guid jobID, Guid userId, UserRoleType userRoleType)
        {
            Guid? candidateProfileId = null;

            // geting andidate profile to check if applied
            if (userRoleType == UserRoleType.Candidate && userId != Guid.Empty)
            {
                var candidateProfile = await _context.CandidateProfiles
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (candidateProfile is not null)
                {
                    candidateProfileId = candidateProfile.CandidateProfileId;
                }

            }


            //var job = await _context.Jobs
            //    .Where(job => job.JobId == jobID)
            //    .ProjectTo<JobResponseDto>(_mapper.ConfigurationProvider) // projects is better than normal method
            //    .FirstOrDefaultAsync();

            //// already mapped by mappper
            //return job;


            // same but slow 
            var job = await _context.Jobs
                .Where(job => job.JobId == jobID)
                .Select(job => new JobResponseDto
                {
                    JobId = job.JobId,
                    OpeningsCount = job.OpeningsCount,
                    DeadlineDate = job.DeadlineDate,
                    CreatedDate = job.CreatedDate,
                    LastModifiedDate = job.LastModifiedDate,
                    CreatedByUserId = job.CreatedByUserId,
                    IsApplied = candidateProfileId != null
                    ? job.Applications.Any(appli => appli.CandidateProfileId == candidateProfileId.Value)
                    : null,

                    JobDescription = new JobDescriptionDto
                    {
                        JobDescriptionId = job.JobDescriptionId,
                        Title = job.JobDescription.Title,
                        Location = job.JobDescription.Location,
                        JobType = job.JobDescription.JobType.TypeName,
                        Details = job.JobDescription.Details,
                        Responsibilities = job.JobDescription.Responsibilty,
                        MinimumExperienceReq = job.JobDescription.MinimumExperienceReq
                    }
                })
                .FirstOrDefaultAsync();

            return job;



        }

    };

}

