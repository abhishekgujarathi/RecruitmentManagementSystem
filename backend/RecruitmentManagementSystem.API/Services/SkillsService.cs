using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS;

namespace RecruitmentManagementSystem.API.Services
{
    public interface ISkillsService
    {
        Task<IEnumerable<SkillDto>> GetAllSkillsAsync();
        Task<SkillDto?> GetSkillByIdAsync(Guid skillId);
    }

    public class SkillsService : ISkillsService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SkillsService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillDto>> GetAllSkillsAsync()
        {
            var skills = await _context.Skills
                .OrderBy(s => s.Name)
                .ToListAsync();

            return _mapper.Map<IEnumerable<SkillDto>>(skills);
        }

        public async Task<SkillDto?> GetSkillByIdAsync(Guid skillId)
        {
            var skill = await _context.Skills
                .FirstOrDefaultAsync(s => s.SkillId == skillId);

            return skill == null ? null : _mapper.Map<SkillDto>(skill);
        }
    }

}
