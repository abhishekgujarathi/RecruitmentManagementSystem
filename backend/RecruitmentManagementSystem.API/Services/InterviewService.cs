using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;
namespace RecruitmentManagementSystem.API.Services
{
    public interface IInterviewService
    {

        // get job default interviews
        Task<List<JobInterviewsDto>> GetJobInterviewRoundsAsync(Guid jobId);
        Task<List<ApplicationInterviewsDto>> GetApplicationInterviewRoundsAsync(Guid applicationId);

    }
    public class InterviewService : IInterviewService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public InterviewService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<JobInterviewsDto>> GetJobInterviewRoundsAsync(Guid jobId)
        {

            // checking job exists
            if (jobId == Guid.Empty)
                throw new ArgumentException("jobid cant be null");

            var jobExists = await _context.Jobs.AnyAsync(j => j.JobId == jobId);
            if (!jobExists)
                throw new ArgumentException("job not found");

            //// get all interview rounds for it
            var intrwRounds = await _context.JobInterviewRounds
                .Where(jir => jir.JobId == jobId)
                .ToListAsync();


            //return new List<JobInterviewsDto>();
            return _mapper.Map<List<JobInterviewsDto>>(intrwRounds);
        }
        public async Task<List<ApplicationInterviewsDto>> GetApplicationInterviewRoundsAsync(Guid applicationId)
        {

            // checking job exists
            if (applicationId == Guid.Empty)
                throw new ArgumentException("applicationId cant be null");

            var appliExists = await _context.JobApplications.AnyAsync(j => j.JobApplicationId == applicationId);
            if (!appliExists)
                throw new ArgumentException("job not found");

            //// get all interview rounds for it
            var intrwRounds = await _context.ApplicationInterviewRounds
                .Where(jir => jir.JobApplicationId == applicationId)
                .ToListAsync();


            //return new List<JobInterviewsDto>();
            return _mapper.Map<List<ApplicationInterviewsDto>>(intrwRounds);
        }

    }
}
