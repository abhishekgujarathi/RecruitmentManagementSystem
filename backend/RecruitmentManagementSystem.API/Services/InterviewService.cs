using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Common;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;
using System;
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
        // panel members
        Task UpdateInterviewRoundAsync(Guid roundId, Guid recruiterId, UpdateInterviewRoundDto dto);
        Task NotifyInterviewRoundAsync(Guid roundId);


        // feedbacks comments
        Task<List<ApplicationInterviewsDto>> GetInterviewerAssignedRoundsAsync(Guid interviewerId);
        Task<List<InterviewRoundSummaryDto?>> GetInterviewRoundSummariesAsync(Guid applicationId, Guid interviewerId);
        Task<List<InterviewRoundSummaryDto?>> GetInterviewAllRoundSummariesAsync(Guid applicationId);
        Task UpsertInterviewFeedbackAsync(Guid roundId, Guid interviewerId, UpdateInterviewFeedbackDto dto);

        Task RejectInterviewRoundAsync(Guid roundId);
        Task CompleteInterviewRoundAsync(Guid roundId);


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

        public async Task UpdateInterviewRoundAsync(Guid roundId, Guid recruiterId, UpdateInterviewRoundDto dto)
        {
            var round = await _context.ApplicationInterviewRounds
                .FirstOrDefaultAsync(r => r.ApplicationInterviewRoundId == roundId);

            if (round == null)
                throw new ArgumentException("Round not found");

            round.ScheduledAt = dto.ScheduledAt;
            round.MeetLink = dto.MeetLink;
            round.Status = InterviewRoundStatus.Scheduled;

            var existingMembers = await _context.InterviewPanelMembers
                .Where(pm => pm.ApplicationInterviewRoundId == roundId)
                .ToListAsync();

            foreach (var interviewerId in dto.PanelMembers)
            {
                var existingMember = existingMembers
                    .FirstOrDefault(pm => pm.InterviewerId == interviewerId);

                if (existingMember == null)
                {
                    //not existing
                    var newMember = new InterviewPanelMember
                    {
                        InterviewPanelMemberId = Guid.NewGuid(),
                        ApplicationInterviewRoundId = roundId,
                        InterviewerId = interviewerId,
                        AssignedAt = DateTime.UtcNow,
                        AssignedByUserId = recruiterId
                    };
                    _context.InterviewPanelMembers.Add(newMember);
                }
            }

            foreach (var existingMember in existingMembers)
            {
                // checking if existing id is in incoming ids
                if (!dto.PanelMembers.Contains(existingMember.InterviewerId))
                {
                    _context.InterviewPanelMembers.Remove(existingMember);
                }
            }

            var application = await _context.JobApplications
                .FirstOrDefaultAsync(ja => ja.JobApplicationId == round.JobApplicationId);
            application.CurrentStatus = ApplicationStatus.InterviewInProgress;
            application.StatusUpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }



        public async Task NotifyInterviewRoundAsync(Guid roundId)
        {
            var round = await _context.ApplicationInterviewRounds
                .Include(r => r.PanelMembers)
                .ThenInclude(pm => pm.Interviewer)
                .FirstOrDefaultAsync(r => r.ApplicationInterviewRoundId == roundId);

            if (round == null)
                throw new ArgumentException("Round not found");


            // later email here;


        }


        // get all interviews assigned to the person
        public async Task<List<ApplicationInterviewsDto>> GetInterviewerAssignedRoundsAsync(Guid interviewerId)
        {
            if (interviewerId == Guid.Empty)
                throw new ArgumentException("interviewerId is required");

            var rounds = await _context.ApplicationInterviewRounds
                .Where(r => r.PanelMembers.Any(pm => pm.InterviewerId == interviewerId))
                .Include(r => r.PanelMembers)
                    .ThenInclude(pm => pm.Interviewer)
                .Include(r => r.JobApplication)
                    .ThenInclude(a => a.CandidateProfile)
                .ToListAsync();

            return _mapper.Map<List<ApplicationInterviewsDto>>(rounds);
        }

        public async Task<List<InterviewRoundSummaryDto>> GetInterviewRoundSummariesAsync(Guid applicationId, Guid interviewerId)
        {
            var rounds = await _context.ApplicationInterviewRounds
                .Include(r => r.Feedbacks)
                    .ThenInclude(f => f.SkillRatings)
                    .ThenInclude(sr => sr.Skill)
                .Where(r =>
                    r.JobApplicationId == applicationId &&
                    r.PanelMembers.Any(pm => pm.InterviewerId == interviewerId))
                .OrderBy(r => r.ScheduledAt)
                .ToListAsync();

            var jobSkills = await _context.JobApplications
                .Where(ja => ja.JobApplicationId == applicationId)
                .SelectMany(ja => ja.Job.JobSkills)
                .Select(js => new
                {
                    SkillId = js.Skill.SkillId,
                    SkillName = js.Skill.Name
                })
                .ToListAsync();

            foreach (var round in rounds)
            {
                // get only the feedback of the current interviewer
                var feedback = round.Feedbacks.FirstOrDefault(f => f.InterviewerId == interviewerId);

                if (feedback == null)
                {
                    feedback = new InterviewFeedback
                    {
                        InterviewerId = interviewerId,
                        ApplicationInterviewRoundId = round.ApplicationInterviewRoundId,
                        SkillRatings = new List<InterviewSkillRating>()
                    };
                    round.Feedbacks.Add(feedback);
                }

                // if no skill ratings yet
                // init skills
                if (!feedback.SkillRatings.Any())
                {
                    feedback.SkillRatings = jobSkills.Select(skill => new InterviewSkillRating
                    {
                        SkillId = skill.SkillId,
                        Skill = new Skill { SkillId = skill.SkillId, Name = skill.SkillName },
                        Rating = 0
                    }).ToList();
                }

                // keep only this interviewers feedback
                round.Feedbacks = new List<InterviewFeedback> { feedback };
            }

            return _mapper.Map<List<InterviewRoundSummaryDto>>(rounds);
        }


        public async Task UpsertInterviewFeedbackAsync(Guid roundId, Guid interviewerId, UpdateInterviewFeedbackDto dto)
        {
            var feedback = await _context.InterviewFeedbacks
                .Include(f => f.SkillRatings)
                .FirstOrDefaultAsync(f =>
                    f.ApplicationInterviewRoundId == roundId &&
                    f.InterviewerId == interviewerId);

            if (feedback == null)
            {
                feedback = new InterviewFeedback
                {
                    ApplicationInterviewRoundId = roundId,
                    InterviewerId = interviewerId,
                    CreatedAt = DateTime.UtcNow,
                    SkillRatings = new List<InterviewSkillRating>()
                };

                _context.InterviewFeedbacks.Add(feedback);
            }

            // update comment
            feedback.Comments = dto.Comments;

            //loop thru skill
            foreach (var dtoRating in dto.SkillRatings)
            {
                var existingRating = feedback.SkillRatings
                    .FirstOrDefault(sr => sr.SkillId == dtoRating.SkillId);

                if (existingRating == null)
                {
                    // new 
                    feedback.SkillRatings.Add(new InterviewSkillRating
                    {
                        SkillId = dtoRating.SkillId,
                        Rating = dtoRating.Rating
                    });
                }
                else
                {
                    // update
                    existingRating.Rating = dtoRating.Rating;
                }
            }

            
            // Recalculate overall rating
            feedback.OverallRating = feedback.SkillRatings.Any()
                ? feedback.SkillRatings.Average(s => s.Rating)
                : null;

            await _context.SaveChangesAsync();
        }

        public async Task<List<InterviewRoundSummaryDto?>> GetInterviewAllRoundSummariesAsync(Guid applicationId)
        {
            var rounds = await _context.ApplicationInterviewRounds
                .Where(r => r.JobApplicationId == applicationId)
                .Include(r => r.Feedbacks)
                    .ThenInclude(f => f.Interviewer)
                .Include(r => r.Feedbacks)
                    .ThenInclude(f => f.SkillRatings)
                        .ThenInclude(sr => sr.Skill)
                .OrderBy(r => r.RoundNumber)
                .ToListAsync();

            return _mapper.Map<List<InterviewRoundSummaryDto?>>(rounds);
        }


        public async Task RejectInterviewRoundAsync(Guid roundId)
        {

            var round = await _context.ApplicationInterviewRounds
                .FirstOrDefaultAsync(r => r.ApplicationInterviewRoundId == roundId);

            if (round == null)
                throw new Exception("Round not found");

            round.Status = "Rejected";

            var application = await _context.JobApplications
                .FirstOrDefaultAsync(ja => ja.JobApplicationId == round.JobApplicationId);
            application.CurrentStatus = ApplicationStatus.Rejected;
            application.StatusUpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async Task CompleteInterviewRoundAsync(Guid roundId)
        {
            var round = await _context.ApplicationInterviewRounds
                .FirstOrDefaultAsync(r => r.ApplicationInterviewRoundId == roundId);

            if (round == null)
                throw new Exception("Round not found");

            round.Status = "Completed";
            var application = await _context.JobApplications
                .FirstOrDefaultAsync(ja => ja.JobApplicationId == round.JobApplicationId);
            application.CurrentStatus = ApplicationStatus.InterviewCompleted;
            application.StatusUpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }


    }
}
