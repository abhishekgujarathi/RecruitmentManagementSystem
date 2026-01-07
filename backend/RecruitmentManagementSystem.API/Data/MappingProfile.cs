using AutoMapper;
using RecruitmentManagementSystem.API.DTOS;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // --- candidateProfile ---
        CreateMap<CreateCandidateProfileDto, CandidateProfile>();


        // --- skills ---
        CreateMap<SkillDto, Skill>().ReverseMap();



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
        CreateMap<CandidateProfile, CandidateProfileDto>()
            .ForMember(dest => dest.UserDetails, opt => opt.MapFrom(src => src.User)); // need to map here becose name is different User!=UserDetails
        CreateMap<User, UserDetailsDto>();
        CreateMap<Education, EducationDto>();
        CreateMap<Experience, ExperienceDto>();
        CreateMap<CandidateSkill, CandidateSkillDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Skill.Name))
            .ForMember(dest => dest.SkillId, opt => opt.MapFrom(src => src.SkillId));

        CreateMap<CandidateSocial, CandidateSocialDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SocialPlatform.Name))
            .ForMember(dest => dest.SocialPlatformId, opt => opt.MapFrom(src => src.SocialPlatformId));


        // --- jobs maps ---
        CreateMap<Job, JobResponseDto>()
            .ForMember(dest => dest.JobDescription, opt => opt.MapFrom(src => src.JobDescription)); // this step done due to nested dto
        CreateMap<JobDescription, JobDescriptionDto>()
            .ForMember(dest => dest.JobType, opt => opt.MapFrom(src => src.JobType)); // done due to JobType is Nav prop
                                                                                      // --- jobs maps ---


        // --- recruiter ---
        CreateMap<CandidateProfile, RecruiterCandidateProfileDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.Fname + " " + src.User.Lname))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.MobileNumber, opt => opt.MapFrom(src => src.User.MobileNumber));
        CreateMap<Education, EducationDto>();
        CreateMap<Experience, ExperienceDto>();
        CreateMap<CandidateSkill, CandidateSkillDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Skill.Name));
        //.ForMember(dest => dest.SkillId, opt => opt.MapFrom(src => src.SkillId));
        // --- recruiter ---



        // --- interview ---
        CreateMap<JobInterviewRound,JobInterviewsDto>();
        CreateMap<ApplicationInterviewRound,ApplicationInterviewsDto>();
        // --- interview ---
    }
}
