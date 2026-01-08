using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Common;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;
namespace RecruitmentManagementSystem.API.Services
{
    public interface IInterviewService
    {

        // get job default interviews
        Task<List<JobInterviewsDto>> GetJobInterviewRoundsAsync(Guid jobId);
        Task<List<ApplicationInterviewsDto>> GetApplicationInterviewRoundsAsync(Guid applicationId);


        // update rounds
        Task UpdateJobInterviewRoundsAsync(Guid jobId, List<JobInterviewsUpsertDto> rounds);
        Task UpdateApplicationInterviewRoundsAsync(Guid applicationId, List<ApplicationInterviewsUpsertDto> rounds);

        // schdeuling 
        Task ScheduleInterviewAsync(Guid roundId, DateTime scheduledAt);

        Task AssignMeetLinkAsync(Guid roundId, string meetLink);

        // panel members
        Task AddPanelMemberAsync(Guid roundId, Guid interviewerId, Guid recruiterId);
        Task RemovePanelMemberAsync(Guid panelMemberId);


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
            if (applicationId == Guid.Empty)
                throw new ArgumentException("applicationId cant be null");

            var appliExists = await _context.JobApplications
                .AnyAsync(j => j.JobApplicationId == applicationId);

            if (!appliExists)
                throw new ArgumentException("job not found");

            var interviewRounds = await _context.ApplicationInterviewRounds
                .Where(r => r.JobApplicationId == applicationId)
                .Include(r => r.PanelMembers)
                    .ThenInclude(pm => pm.Interviewer)
                .OrderBy(r => r.RoundNumber)
                .ToListAsync();

            return _mapper.Map<List<ApplicationInterviewsDto>>(interviewRounds);
        }


        public async Task UpdateJobInterviewRoundsAsync(Guid jobId, List<JobInterviewsUpsertDto> rounds)
        {
            if (jobId == Guid.Empty)
                throw new ArgumentException("jobId cant be null");

            var jobExists = await _context.Jobs.AnyAsync(j => j.JobId == jobId);
            if (!jobExists)
                throw new ArgumentException("job not found");

            var existingRounds = await _context.JobInterviewRounds
                .Where(r => r.JobId == jobId)
                .ToListAsync();

            // already there
            var toUpdateIds = rounds
                .Where(r => r.JobInterviewRoundId != Guid.Empty)
                .Select(r => r.JobInterviewRoundId)
                // puting in hash so i can check if exists
                .ToHashSet();

            // cros check with alredy there rounds
            var toDelete = existingRounds
                .Where(r => !toUpdateIds.Contains(r.JobInterviewRoundId))
                .ToList();

            // removing those 
            _context.JobInterviewRounds.RemoveRange(toDelete);


            foreach (var dto in rounds)
            {
                // adding
                if (!dto.JobInterviewRoundId.HasValue)
                {
                    var newRound = new JobInterviewRound
                    {
                        JobInterviewRoundId = Guid.NewGuid(),
                        JobId = jobId,
                        RoundType = dto.RoundType,
                        RoundNumber = dto.RoundNumber
                    };
                    _context.JobInterviewRounds.Add(newRound);
                }
                // updating
                else
                {
                    var existing = existingRounds
                        .FirstOrDefault(r => r.JobInterviewRoundId == dto.JobInterviewRoundId);

                    if (existing == null)
                        continue;

                    existing.RoundType = dto.RoundType;
                    existing.RoundNumber = dto.RoundNumber;
                }
            }

            await _context.SaveChangesAsync();
        }


        public async Task UpdateApplicationInterviewRoundsAsync(Guid applicationId, List<ApplicationInterviewsUpsertDto> rounds)
        {
            if (applicationId == Guid.Empty)
                throw new ArgumentException("applicationId cant be null");

            var appExists = await _context.JobApplications
                .AnyAsync(a => a.JobApplicationId == applicationId);

            if (!appExists)
                throw new ArgumentException("application not found");

            // already there
            var existingRounds = await _context.ApplicationInterviewRounds
                .Where(r => r.JobApplicationId == applicationId)
                .ToListAsync();

            // cros check with alredy there rounds
            var incomingIds = rounds
                .Where(r => r.ApplicationInterviewRoundId != Guid.Empty)
                .Select(r => r.ApplicationInterviewRoundId)
                // puting in hash so i can check if exists
                .ToHashSet();

            var toDelete = existingRounds
                .Where(r => !incomingIds.Contains(r.ApplicationInterviewRoundId))
                .ToList();

            _context.ApplicationInterviewRounds.RemoveRange(toDelete);

            // add/update
            foreach (var dto in rounds)
            {
                if (!dto.ApplicationInterviewRoundId.HasValue)
                {
                    var newRound = new ApplicationInterviewRound
                    {
                        ApplicationInterviewRoundId = Guid.NewGuid(),
                        JobApplicationId = applicationId,
                        RoundType = dto.RoundType,
                        RoundNumber = dto.RoundNumber
                    };
                    _context.ApplicationInterviewRounds.Add(newRound);
                }
                else
                {
                    var existing = existingRounds
                        .FirstOrDefault(r => r.ApplicationInterviewRoundId == dto.ApplicationInterviewRoundId);

                    if (existing == null)
                        continue;

                    existing.RoundType = dto.RoundType;
                    existing.RoundNumber = dto.RoundNumber;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task ScheduleInterviewAsync(Guid roundId, DateTime scheduledAt)
        {
            var round = await _context.ApplicationInterviewRounds
                .FirstOrDefaultAsync(r => r.ApplicationInterviewRoundId == roundId);

            if (round == null)
                throw new ArgumentException("Round not found");

            round.ScheduledAt = scheduledAt;
            round.Status = InterviewRoundStatus.Scheduled;

            await _context.SaveChangesAsync();
        }



        // panel memeber functions
        public async Task AddPanelMemberAsync(Guid roundId, Guid interviewerId, Guid recruiterId)
        {
            var round = await _context.ApplicationInterviewRounds
                .Include(r => r.PanelMembers)
                .FirstOrDefaultAsync(r => r.ApplicationInterviewRoundId == roundId);

            if (round == null)
                throw new ArgumentException("Interview round not found");

            var exists = round.PanelMembers
                .Any(pm => pm.InterviewerId == interviewerId);

            if (exists)
                throw new ArgumentException("Interviewer already assigned");

            _context.InterviewPanelMembers.Add(new InterviewPanelMember
            {
                InterviewPanelMemberId = Guid.NewGuid(),
                ApplicationInterviewRoundId = roundId,
                InterviewerId = interviewerId,
                AssignedByUserId = recruiterId,
            });

            await _context.SaveChangesAsync();
        }

        public async Task RemovePanelMemberAsync(Guid panelMemberId)
        {
            var member = await _context.InterviewPanelMembers.FindAsync(panelMemberId);
            if (member == null)
                return;

            _context.InterviewPanelMembers.Remove(member);
            await _context.SaveChangesAsync();
        }
        // panel memeber functions


        // patch meet links put will also wor
        public async Task AssignMeetLinkAsync(Guid roundId, string meetLink)
        {
            var round = await _context.ApplicationInterviewRounds
                .FirstOrDefaultAsync(r => r.ApplicationInterviewRoundId == roundId);

            if (round == null)
                throw new ArgumentException("Round not found");

            round.MeetLink = meetLink;
            await _context.SaveChangesAsync();
        }

    }
}
