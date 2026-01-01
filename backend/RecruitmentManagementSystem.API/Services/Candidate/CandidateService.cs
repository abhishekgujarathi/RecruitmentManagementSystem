using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.Services.Candidate
{
    public interface ICandidateService

    {
        // --- PROFILE ---

        //Task<List<CandidateProfile>> GetProfileByUserIdAsync(Guid userId);
        Task<CandidateProfileDto?> GetProfileByUserIdAsync(Guid userId);
        Task<CandidateProfileDto?> GetProfileByIdAsync(Guid candidateProfileId);

        Task<CandidateProfileDto> CreateProfileAsync(Guid userId, CreateCandidateProfileDto dto);
        Task<CandidateProfileDto> UpdateProfileAsync(Guid userId, UpdateCandidateProfileDto dto);

        Task<bool> DeleteProfileAsync(Guid candidateProfileId);
        Task<bool> HasProfileAsync(Guid userId);

        // --- APPLY ---
        Task<bool> ApplyToJobAsync(Guid userId, Guid jobId);

        // ??? for later toseperate everythin
    }


    public class CandidateService : ICandidateService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CandidateService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Profile Methods
        public async Task<CandidateProfileDto?> GetProfileByUserIdAsync(Guid userId)
        {
            var profile = await _context.CandidateProfiles
                .Include(cp => cp.User)
                .Include(cp => cp.Educations)
                .Include(cp => cp.Experiences)
                .Include(cp => cp.CandidateSocials)
                    .ThenInclude(cs => cs.SocialPlatform)
                .Include(cp => cp.CandidateSkills)
                    .ThenInclude(cs => cs.Skill)
                .Include(cp => cp.CVStorages)
                .FirstOrDefaultAsync(cp => cp.UserId == userId);

            if (profile == null)
                return null;

            var resultDto = _mapper.Map<CandidateProfileDto>(profile);

            return resultDto;
        }
        public async Task<CandidateProfileDto?> GetProfileByIdAsync(Guid candidateProfileId)
        {
            // not used anywhere
            var profile = await _context.CandidateProfiles
                .Include(cp => cp.Educations)
                .Include(cp => cp.Experiences)
                .Include(cp => cp.CandidateSocials)
                .Include(cp => cp.CandidateSkills)
                .Include(cp => cp.CVStorages)
                .FirstOrDefaultAsync(cp => cp.CandidateProfileId == candidateProfileId);

            if (profile == null)
                return null;

            Console.WriteLine("=== DEBUG SKILLS ===");

            if (profile?.CandidateSkills != null)
            {
                foreach (var s in profile.CandidateSkills)
                {
                    Console.WriteLine($"SkillId: {s.SkillId}");
                    Console.WriteLine($"Skill Navigation Null?: {s.Skill == null}");
                    if (s.Skill != null)
                    {
                        Console.WriteLine($"Skill.Name: {s.Skill.Name}");
                    }
                }
            }

            return _mapper.Map<CandidateProfileDto>(profile);
        }

        public async Task<CandidateProfileDto> CreateProfileAsync(Guid userId, CreateCandidateProfileDto dto)
        {
            var profile = _mapper.Map<CandidateProfile>(dto);
            profile.UserId = userId;

            _context.CandidateProfiles.Add(profile);

            await _context.SaveChangesAsync();

            return _mapper.Map<CandidateProfileDto>(profile);
        }

        public async Task<bool> DeleteProfileAsync(Guid candidateProfileId)
        {
            var profile = await _context.CandidateProfiles
                .Include(cp => cp.Educations)
                .Include(cp => cp.Experiences)
                .Include(cp => cp.CandidateSkills)
                .Include(cp => cp.CandidateSocials)
                .Include(cp => cp.CVStorages)
                .FirstOrDefaultAsync(cp => cp.CandidateProfileId == candidateProfileId);

            if (profile == null)
                return false;

            _context.CandidateProfiles.Remove(profile);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<CandidateProfileDto> UpdateProfileAsync(Guid userId, UpdateCandidateProfileDto dto)
        {
            var profile = await _context.CandidateProfiles
                .Include(cp => cp.Educations)
                .Include(cp => cp.Experiences)
                .Include(cp => cp.CandidateSkills)
                .Include(cp => cp.CandidateSocials)
                .Include(cp => cp.CVStorages)
                .FirstOrDefaultAsync(cp => cp.UserId == userId);

            if (profile == null)
                throw new KeyNotFoundException("Profile not found");

            // Begin transaction for atomic updates
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Update basic profile fields
                profile.Address = dto.Address;
                profile.City = dto.City;
                profile.State = dto.State;
                profile.Country = dto.Country;
                profile.PostalCode = dto.PostalCode;

                // --- Replace collections safely ---

                profile.Educations.Clear();
                if (dto.Educations?.Any() == true)

                    profile.Educations = dto.Educations.Select(e => _mapper.Map<Education>(e)).ToList();

                profile.Experiences.Clear();
                if (dto.Experiences?.Any() == true)
                    profile.Experiences = dto.Experiences.Select(e => _mapper.Map<Experience>(e)).ToList();

                profile.CandidateSkills.Clear();
                if (dto.CandidateSkills?.Any() == true)
                    profile.CandidateSkills = dto.CandidateSkills.Select(s => _mapper.Map<CandidateSkill>(s)).ToList();

                profile.CandidateSocials.Clear();
                if (dto.CandidateSocials?.Any() == true)
                    profile.CandidateSocials = dto.CandidateSocials.Select(s => _mapper.Map<CandidateSocial>(s)).ToList();


                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return _mapper.Map<CandidateProfileDto>(profile);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public Task<bool> HasProfileAsync(Guid userId)
        {
            // ??? need to implement this later
            throw new NotImplementedException();
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

    }

}
