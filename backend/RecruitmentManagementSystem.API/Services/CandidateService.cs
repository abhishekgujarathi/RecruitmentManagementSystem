using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.Dtos;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;
using RecruitmentManagementSystem.API.Services;

namespace RecruitmentManagementSystem.API.Services
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


        // ??? for later toseperate everythin

        // // --- EDUCATION  ---
        // Task<List<EducationDto>> GetEducationsAsync(Guid candidateProfileId);
        // Task<EducationDto?> GetEducationByIdAsync(Guid educationId);
        // Task<EducationDto> AddEducationAsync(Guid candidateProfileId, CreateEducationDto dto);
        // Task<EducationDto> UpdateEducationAsync(Guid educationId, UpdateEducationDto dto);
        // Task<bool> DeleteEducationAsync(Guid educationId);
        // Task<bool> SetCurrentEducationAsync(Guid candidateProfileId, Guid educationId);

        // // --- EXPERIENCE  ---
        // Task<List<ExperienceDto>> GetExperiencesAsync(Guid candidateProfileId);
        // Task<ExperienceDto?> GetExperienceByIdAsync(Guid experienceId);
        // Task<ExperienceDto> AddExperienceAsync(Guid candidateProfileId, CreateExperienceDto dto);
        // Task<ExperienceDto> UpdateExperienceAsync(Guid experienceId, UpdateExperienceDto dto);
        // Task<bool> DeleteExperienceAsync(Guid experienceId);
        // Task<bool> SetCurrentExperienceAsync(Guid candidateProfileId, Guid experienceId);

        // // --- SKILLS  ---
        // Task<List<CandidateSkillDto>> GetSkillsAsync(Guid candidateProfileId);
        // Task<CandidateSkillDto?> GetSkillByIdAsync(Guid candidateSkillId);
        // Task<CandidateSkillDto> AddSkillAsync(Guid candidateProfileId, CreateCandidateSkillDto dto);
        // Task<CandidateSkillDto> UpdateSkillAsync(Guid candidateSkillId, UpdateCandidateSkillDto dto);
        // Task<bool> DeleteSkillAsync(Guid candidateSkillId);
        // Task<List<SkillDto>> GetAllAvailableSkillsAsync();

        // // --- CV/RESUME  ---
        // Task<List<CVStorageDto>> GetCVsAsync(Guid candidateProfileId);
        // Task<CVStorageDto?> GetCVByIdAsync(Guid cvStorageId);
        // Task<CVStorageDto> UploadCVAsync(Guid candidateProfileId, CreateCVStorageDto dto);
        // Task<bool> DeleteCVAsync(Guid cvStorageId);
        // Task<string?> GetCVFilePathAsync(Guid cvStorageId);
        // Task<bool> SetCVActiveStatusAsync(Guid cvStorageId, bool isActive);

        // // --- SOCIAL LINKS  ---
        // Task<List<CandidateSocialDto>> GetSocialLinksAsync(Guid candidateProfileId);
        // Task<CandidateSocialDto?> GetSocialLinkByIdAsync(Guid candidateSocialId);
        // Task<CandidateSocialDto> AddSocialLinkAsync(Guid candidateProfileId, CreateCandidateSocialDto dto);
        // Task<CandidateSocialDto> UpdateSocialLinkAsync(Guid candidateSocialId, UpdateCandidateSocialDto dto);
        // Task<bool> DeleteSocialLinkAsync(Guid candidateSocialId);
        // Task<List<SocialPlatformDto>> GetAllSocialPlatformsAsync();

        // // --- COMPLETE PROFILE OPERATIONS ---
        // Task<CompleteCandidateProfileDto?> GetCompleteProfileAsync(Guid candidateProfileId);
        // Task<int> GetProfileCompletionPercentageAsync(Guid candidateProfileId);


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
        //public async Task<List<CandidateProfile>> GetProfileByUserIdAsync(Guid userId)
        public async Task<CandidateProfileDto?> GetProfileByUserIdAsync(Guid userId)
        {
            var profile = await _context.CandidateProfiles
                .Include(cp => cp.Educations)
                .Include(cp => cp.Experiences)
                .Include(cp => cp.CandidateSocials)
                .Include(cp => cp.CandidateSkills)
                .Include(cp => cp.CVStorages)
                .FirstOrDefaultAsync(cp => cp.UserId == userId);

            if (profile == null)
                return null;

            var resultDto = _mapper.Map<CandidateProfileDto>(profile);

            return resultDto;
        }

        public async Task<CandidateProfileDto?> GetProfileByIdAsync(Guid candidateProfileId)
        {
            var profile = await _context.CandidateProfiles
                .Include(cp => cp.Educations)
                .Include(cp => cp.Experiences)
                .Include(cp => cp.CandidateSocials)
                .Include(cp => cp.CandidateSkills)
                .Include(cp => cp.CVStorages)
                .FirstOrDefaultAsync(cp => cp.CandidateProfileId == candidateProfileId);

            if (profile == null)
                return null;

            var resultDto = _mapper.Map<CandidateProfileDto>(profile);

            return resultDto;
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



        public Task<bool> HasProfileAsync(Guid userId)
        {
            // ??? need to implement this later
            throw new NotImplementedException();
        }

        public async Task<CandidateProfileDto> UpdateProfileAsync(Guid userId, UpdateCandidateProfileDto dto)
        {
            var profile = await _context.CandidateProfiles
                .Include(cp => cp.Educations)
                .Include(cp => cp.Experiences)
                .Include(cp => cp.CandidateSkills)
                .Include(cp => cp.CandidateSocials)
                .FirstOrDefaultAsync(cp => cp.UserId == userId);

            if (profile == null)
            {
                throw new KeyNotFoundException("Profile not found");
            }

            // Update basic fields (required)
            profile.Address = dto.Address;
            profile.City = dto.City;
            profile.State = dto.State;
            profile.Country = dto.Country;
            profile.PostalCode = dto.PostalCode;

            // Replace all collections completely
            profile.Educations.Clear();
            if (dto.Educations?.Any() == true)
            {
                foreach (var eduDto in dto.Educations)
                {
                    profile.Educations.Add(_mapper.Map<Education>(eduDto));
                }
            }

            profile.Experiences.Clear();
            if (dto.Experiences?.Any() == true)
            {
                foreach (var expDto in dto.Experiences)
                {
                    profile.Experiences.Add(_mapper.Map<Experience>(expDto));
                }
            }

            profile.CandidateSkills.Clear();
            if (dto.CandidateSkills?.Any() == true)
            {
                foreach (var skillDto in dto.CandidateSkills)
                {
                    profile.CandidateSkills.Add(_mapper.Map<CandidateSkill>(skillDto));
                }
            }

            profile.CandidateSocials.Clear();
            if (dto.CandidateSocials?.Any() == true)
            {
                foreach (var socialDto in dto.CandidateSocials)
                {
                    profile.CandidateSocials.Add(_mapper.Map<CandidateSocial>(socialDto));
                }
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<CandidateProfileDto>(profile);
        }
    }

}
