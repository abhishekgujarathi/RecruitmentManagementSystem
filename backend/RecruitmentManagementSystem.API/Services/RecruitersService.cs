using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;
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
        public Task<bool?> DeleteJobAsync(Guid jobId, Guid recruiterId);
        //return true if deleted 

        // check-applications


    }


    public class RecruitersService : IRecruitersService
    {
        private readonly AppDbContext _context;
        public RecruitersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JobResponseDto?> CreateJobAsync(JobCreateRequestDto request, Guid recruiterId)
        {
            // get jobtypes first
            var jobType = await _context.JobTypes
            .FirstOrDefaultAsync(jt => jt.TypeName == request.TypeName);

            // return if jobtype is invalid 
            if (jobType == null)
            { return null; }

            //creating job description
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


            // creating job itself
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


            // saving changes in db
            await _context.SaveChangesAsync();

            return new JobResponseDto
            {
                JobId = job.JobId,
                JobDescription = new JobDescriptionDto()
                {
                    Title = jobDescription.Title,
                    Location = jobDescription.Location,
                    JobType = jobType.TypeName,
                    Details = jobDescription.Details,
                },
                OpeningsCount = job.OpeningsCount,
                DeadlineDate = job.DeadlineDate,
                CreatedDate = job.CreatedDate,
                CreatedByUserId = recruiterId
            };
        }

        public Task<bool?> DeleteJobAsync(Guid jobId, Guid recruiterId)
        {
            throw new NotImplementedException();
        }

        public Task<JobResponseDto?> UpdateJobAsync(Guid jobId, JobUpdateRequestDto request, Guid recruiterId)
        {
            throw new NotImplementedException();
        }

    }
}
