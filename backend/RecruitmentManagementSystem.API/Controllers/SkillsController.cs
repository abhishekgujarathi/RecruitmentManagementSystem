using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.DTOS;
using RecruitmentManagementSystem.API.Services;

namespace RecruitmentManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService _skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetSkills()
        {
            var skills = await _skillsService.GetAllSkillsAsync();
            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDto>> GetSkill(Guid id)
        {
            var skill = await _skillsService.GetSkillByIdAsync(id);

            if (skill == null)
                return NotFound();

            return Ok(skill);
        }
    }

}
