using AutoMapper;
using RecruitmentManagementSystem.API.Dtos;
using RecruitmentManagementSystem.API.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // --- candidateProfile ---
        CreateMap<CreateCandidateProfileDto, CandidateProfile>();

        // --- nested collections ---
        CreateMap<CreateCandidateSocialDto, CandidateSocial>();
        CreateMap<CreateEducationDto, Education>();
        CreateMap<CreateExperienceDto, Experience>();
        CreateMap<CreateCandidateSkillDto, CandidateSkill>();

        // --- pdate DTOs ---
        // this makes partial updates, ignores null fields to be updated.
        CreateMap<UpdateCandidateProfileDto, CandidateProfile>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UpdateCandidateSocialDto, CandidateSocial>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UpdateEducationDto, Education>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UpdateExperienceDto, Experience>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UpdateCandidateSkillDto, CandidateSkill>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // --- reverse maps ---
        CreateMap<CandidateProfile, CandidateProfileDto>();
        CreateMap<CandidateSocial, CandidateSocialDto>();
        CreateMap<Education, EducationDto>();
        CreateMap<Experience, ExperienceDto>();
        CreateMap<CandidateSkill, CandidateSkillDto>();
    }
}
