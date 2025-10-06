using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.DTOS.Response;

namespace RecruitmentManagementSystem.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetJobsAsync()
        {
            var jobs = await _context.Jobs
                .Include(job => job.JobDescription)
                .ThenInclude(jd => jd.JobType)
                .Include(jod => jod.CreatedByUser)
                .Select(job => new JobResponseDto()
                {
                    JobId = job.JobId,
                    OpeningsCount = job.OpeningsCount,
                    CreatedDate = job.CreatedDate,
                    DeadlineDate = job.DeadlineDate,
                    JobDescription = new JobDescriptionDto
                    {
                        JobDescriptionId = job.JobDescription.JobDescriptionId,
                        Title = job.JobDescription.Title,
                        Details = job.JobDescription.Details,
                        Location = job.JobDescription.Location,
                        MinimumExperienceReq = job.JobDescription.MinimumExperienceReq,
                        JobType = job.JobDescription.JobType.TypeName
                    },
                    CreatedByUserId = job.CreatedByUserId
                })
                .ToListAsync();

            return Ok(jobs);
        }

        [HttpGet("{jobID}")]
        public async Task<ActionResult> GetJobAsync([FromRoute] Guid jobID)
        {

            var job = await _context.Jobs
                .Include(job => job.JobDescription)
                .ThenInclude(jd => jd.JobType)
                .Include(jod => jod.CreatedByUser)
                .Where(job => job.JobId == jobID)
                .Select(job => new JobResponseDto()
                {
                    JobId = job.JobId,
                    OpeningsCount = job.OpeningsCount,
                    CreatedDate = job.CreatedDate,
                    DeadlineDate = job.DeadlineDate,
                    JobDescription = new JobDescriptionDto
                    {
                        JobDescriptionId = job.JobDescription.JobDescriptionId,
                        Title = job.JobDescription.Title,
                        Details = job.JobDescription.Details,
                        Location = job.JobDescription.Location,
                        MinimumExperienceReq = job.JobDescription.MinimumExperienceReq,
                        JobType = job.JobDescription.JobType.TypeName
                    },
                    CreatedByUserId = job.CreatedByUserId
                })
                .FirstOrDefaultAsync();

            if(job is null)
            {
                return BadRequest("Invalid job id");
            }


            return Ok(job);
        }

    }
}
