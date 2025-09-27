using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
