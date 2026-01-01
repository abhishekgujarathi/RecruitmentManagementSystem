using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        // --- users ---
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        // --- users ---

        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<Job> Jobs { get; set; }


        // --- candidate ---
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<SocialPlatform> SocialPlatforms { get; set; }
        public DbSet<CandidateSocial> CandidateSocials { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }
        public DbSet<CVStorage> CVStorages { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        // --- candidate ---
        public DbSet<AssignedReviewer> AssignedReviewers { get; set; }
        public DbSet<CVReviewStage> CVReviewStages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // --- user --
            var adminRoleId = Guid.Parse("b57751e8-24af-473b-a7aa-ff30ddfc0d49");
            var recruiterRoleId = Guid.Parse("66a24f39-2e0a-46fd-81b5-13d6bddb8c5c");
            var candidateRoleId = Guid.Parse("c016dbd1-11c4-444b-8b3e-84095706fc60");

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserRoleId = adminRoleId, RoleName = "Admin", active = true },
                new UserRole { UserRoleId = recruiterRoleId, RoleName = "Recruiter", active = true },
                new UserRole { UserRoleId = candidateRoleId, RoleName = "Candidate", active = true }
            );

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasOne(u => u.CandidateProfile)
                    .WithOne(cp => cp.User)
                    .HasForeignKey<CandidateProfile>(cp => cp.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.UserRole)
                    .WithMany(ur => ur.Users)
                    .HasForeignKey(u => u.UserRoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.Email).IsUnique();
            });


            var passwordHasher = new PasswordHasher<User>();
            var adminUser = new User
            {
                UserId = Guid.Parse("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                Fname = "Admin",
                Lname = "User",
                Email = "admin@exp.com",
                MobileNumber = "1234567890",
                CreatedDate = DateTime.UtcNow,
                DOB = new DateTime(1990, 1, 1),
                Gender = "Male",
                IsActive = true,
                UserRoleId = adminRoleId
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "1234567890");

            var recruiterUser = new User
            {
                UserId = Guid.Parse("331a9809-54d9-43c3-883a-493e8787f97a"),
                Fname = "Peter",
                Lname = "Parker",
                Email = "peter@exp.com",
                MobileNumber = "0987654321",
                CreatedDate = DateTime.UtcNow,
                DOB = new DateTime(1995, 5, 10),
                Gender = "Male",
                IsActive = true,
                UserRoleId = recruiterRoleId
            };
            recruiterUser.PasswordHash = passwordHasher.HashPassword(recruiterUser, "1234567890");

            var candidateUserId = Guid.Parse("0a33c200-c9f2-4547-810a-b3337a72d733");
            var candidate = new User
            {
                UserId = candidateUserId,
                Fname = "Abhi",
                Lname = "G",
                Email = "abhi@exp.com",
                MobileNumber = "1111111111",
                CreatedDate = DateTime.UtcNow,
                DOB = new DateTime(1998, 8, 25),
                Gender = "Male",
                IsActive = true,
                UserRoleId = candidateRoleId
            };
            candidate.PasswordHash = passwordHasher.HashPassword(candidate, "1234567890");

            modelBuilder.Entity<User>().HasData(adminUser, recruiterUser, candidate);
            // --- user ---


            // --- candidate profile ---
            modelBuilder.Entity<CandidateProfile>(entity =>
            {
                entity.HasKey(e => e.CandidateProfileId);

                entity.HasMany(cp => cp.Educations)
                    .WithOne(e => e.CandidateProfile)
                    .HasForeignKey(e => e.CandidateProfileId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(cp => cp.Experiences)
                    .WithOne(e => e.CandidateProfile)
                    .HasForeignKey(e => e.CandidateProfileId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(cp => cp.CandidateSkills)
                    .WithOne(cs => cs.CandidateProfile)
                    .HasForeignKey(cs => cs.CandidateProfileId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(cp => cp.CandidateSocials)
                    .WithOne(cs => cs.CandidateProfile)
                    .HasForeignKey(cs => cs.CandidateProfileId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(cp => cp.CVStorages)
                    .WithOne(cv => cv.CandidateProfile)
                    .HasForeignKey(cv => cv.CandidateProfileId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            var candidateProfileId = Guid.Parse("29d665b6-7013-4170-a8eb-844f2d79d356");
            modelBuilder.Entity<CandidateProfile>().HasData(
                new CandidateProfile
                {
                    CandidateProfileId = candidateProfileId,
                    UserId = candidateUserId,
                    Address = "123 Main Street, Apartment 4B",
                    City = "Mumbai",
                    State = "Maharashtra",
                    Country = "India",
                    PostalCode = "400001"
                }
            );
            // --- candidate profile ---

            // --- socials ---
            modelBuilder.Entity<SocialPlatform>(entity =>
            {
                entity.HasKey(e => e.SocialPlatformId);
                entity.HasIndex(e => e.Name).IsUnique();
            });

            var linkedInId = Guid.NewGuid();
            var githubId = Guid.NewGuid();
            var portfolioId = Guid.NewGuid();
            var twitterId = Guid.NewGuid();
            var stackOverflowId = Guid.NewGuid();

            modelBuilder.Entity<SocialPlatform>().HasData(
                new SocialPlatform { SocialPlatformId = linkedInId, Name = "LinkedIn" },
                new SocialPlatform { SocialPlatformId = githubId, Name = "GitHub" },
                new SocialPlatform { SocialPlatformId = portfolioId, Name = "Portfolio" },
                new SocialPlatform { SocialPlatformId = twitterId, Name = "Twitter" },
                new SocialPlatform { SocialPlatformId = stackOverflowId, Name = "Stack Overflow" }
            );

            modelBuilder.Entity<CandidateSocial>(entity =>
            {
                entity.HasKey(e => e.CandidateSocialsId);
                entity.HasIndex(e => new { e.CandidateProfileId, e.SocialPlatformId }).IsUnique();

                entity.HasOne(cs => cs.SocialPlatform)
                    .WithMany()
                    .HasForeignKey(cs => cs.SocialPlatformId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            // --- socials ---

            // --- education ---
            var edu1Id = Guid.Parse("b3f2c0e1-6f2a-4a6c-9f8a-1a2b3c4d5e01");
            var edu2Id = Guid.Parse("c4d3f1a2-7b3c-4d8e-9a0b-2c3d4e5f6a02");

            modelBuilder.Entity<Education>().HasData(
                new Education
                {
                    EducationId = edu1Id,
                    CandidateProfileId = candidateProfileId,
                    InstituteName = "St. Xavier's College, Mumbai",
                    DegreeType = "B.Tech",
                    FieldOfStudy = "Computer Science",
                    PercentageScore = 78.45m,
                    StartDate = new DateTime(2016, 7, 1),
                    EndDate = new DateTime(2020, 5, 31),
                    IsCurrent = false
                },
                new Education
                {
                    EducationId = edu2Id,
                    CandidateProfileId = candidateProfileId,
                    InstituteName = "Mumbai Central Higher Secondary School",
                    DegreeType = "Higher Secondary (12th)",
                    FieldOfStudy = "Science",
                    PercentageScore = 86.20m,
                    StartDate = new DateTime(2014, 6, 1),
                    EndDate = new DateTime(2016, 4, 30),
                    IsCurrent = false
                }
            );
            // --- education ---

            // --- experience ---
            var exp1Id = Guid.Parse("d5e4f3b2-8c4d-4e9f-0a1b-3c4d5e6f7a03");
            var exp2Id = Guid.Parse("e6f5a4c3-9d5e-4f0a-1b2c-4d5e6f7a8b04");

            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    ExperienceId = exp1Id,
                    CandidateProfileId = candidateProfileId,
                    CompanyName = "InnoTech Solutions Pvt. Ltd.",
                    Position = "Software Engineer",
                    DurationYears = 2.50m,
                    StartDate = new DateTime(2020, 7, 1),
                    EndDate = new DateTime(2022, 6, 30),
                    IsCurrent = false,
                    JobDescription = "Worked on backend APIs using .NET Core, implemented authentication and REST endpoints, wrote unit tests and integrated CI/CD pipelines."
                },
                new Experience
                {
                    ExperienceId = exp2Id,
                    CandidateProfileId = candidateProfileId,
                    CompanyName = "QuickStart Internships",
                    Position = "Software Intern",
                    DurationYears = 0.50m,
                    StartDate = new DateTime(2019, 6, 1),
                    EndDate = new DateTime(2019, 11, 30),
                    IsCurrent = false,
                    JobDescription = "Assisted in developing small features, bug fixes and wrote documentation. Gained exposure to agile practices."
                }
            );
            // --- experience ---


            // --- skills ---
            var skill1Id = Guid.NewGuid();
            var skill2Id = Guid.NewGuid();
            var skill3Id = Guid.NewGuid();
            var skill4Id = Guid.NewGuid();
            var skill5Id = Guid.NewGuid();
            var skill6Id = Guid.NewGuid();

            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = skill1Id, Name = "C#" },
                new Skill { SkillId = skill2Id, Name = "ASP.NET Core" },
                new Skill { SkillId = skill3Id, Name = "Entity Framework Core" },
                new Skill { SkillId = skill4Id, Name = "SQL Server" },
                new Skill { SkillId = skill5Id, Name = "JavaScript" },
                new Skill { SkillId = skill6Id, Name = "React" }
            );

            modelBuilder.Entity<CandidateSkill>().HasData(
                new CandidateSkill { CandidateSkillId = Guid.NewGuid(), CandidateProfileId = candidateProfileId, SkillId = skill1Id },
                new CandidateSkill { CandidateSkillId = Guid.NewGuid(), CandidateProfileId = candidateProfileId, SkillId = skill2Id },
                new CandidateSkill { CandidateSkillId = Guid.NewGuid(), CandidateProfileId = candidateProfileId, SkillId = skill6Id }
            );
            // --- skills ---



            // --- jobs ---
            var fullTimeTypeId = Guid.NewGuid();
            var partTimeTypeId = Guid.NewGuid();
            var contractTypeId = Guid.NewGuid();

            modelBuilder.Entity<JobType>().HasData(
                new JobType
                {
                    JobTypeId = fullTimeTypeId,
                    TypeName = "Full-Time"
                },
                new JobType
                {
                    JobTypeId = partTimeTypeId,
                    TypeName = "Part-Time"
                },
                new JobType
                {
                    JobTypeId = contractTypeId,
                    TypeName = "Contract"
                }
            );

            // seed JobDescriptions
            var jd1Id = Guid.NewGuid();
            var jd2Id = Guid.NewGuid();
            var jd3Id = Guid.NewGuid();
            var jd4Id = Guid.NewGuid();

            modelBuilder.Entity<JobDescription>().HasData(
                new JobDescription
                {
                    JobDescriptionId = jd1Id,
                    Title = "Senior .NET Developer",
                    Details = "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.",
                    Responsibilty = "Develop and maintain web applications, code reviews, mentor junior developers",
                    Location = "Mumbai, India",
                    MinimumExperienceReq = 5,
                    JobTypeId = fullTimeTypeId
                },
                new JobDescription
                {
                    JobDescriptionId = jd2Id,
                    Title = "Frontend React Developer",
                    Details = "Join our frontend team to build modern web applications using React and TypeScript.",
                    Responsibilty = "Build responsive UIs, optimize performance, collaborate with designers",
                    Location = "Bangalore, India",
                    MinimumExperienceReq = 3,
                    JobTypeId = fullTimeTypeId
                },
                new JobDescription
                {
                    JobDescriptionId = jd3Id,
                    Title = "DevOps Engineer",
                    Details = "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.",
                    Responsibilty = "Maintain AWS infrastructure, automate deployments, monitor systems",
                    Location = "Remote",
                    MinimumExperienceReq = 4,
                    JobTypeId = contractTypeId
                },
                new JobDescription
                {
                    JobDescriptionId = jd4Id,
                    Title = "Junior Python Developer",
                    Details = "Entry-level position for fresh graduates passionate about Python and data science.",
                    Responsibilty = "Write clean code, learn from seniors, contribute to data pipelines",
                    Location = "Pune, India",
                    MinimumExperienceReq = 0,
                    JobTypeId = partTimeTypeId
                }
            );

            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    JobId = Guid.NewGuid(),
                    JobDescriptionId = jd1Id,
                    OpeningsCount = 3,
                    CreatedByUserId = Guid.Parse("331a9809-54d9-43c3-883a-493e8787f97a"), // peter userid [recruit]
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                    DeadlineDate = DateTime.UtcNow.AddDays(20)
                },
                new Job
                {
                    JobId = Guid.NewGuid(),
                    JobDescriptionId = jd2Id,
                    OpeningsCount = 2,
                    CreatedByUserId = Guid.Parse("331a9809-54d9-43c3-883a-493e8787f97a"),
                    CreatedDate = DateTime.UtcNow.AddDays(-7),
                    DeadlineDate = DateTime.UtcNow.AddDays(23)
                },
                new Job
                {
                    JobId = Guid.NewGuid(),
                    JobDescriptionId = jd3Id,
                    OpeningsCount = 1,
                    CreatedByUserId = Guid.Parse("331a9809-54d9-43c3-883a-493e8787f97a"),
                    CreatedDate = DateTime.UtcNow.AddDays(-5),
                    DeadlineDate = DateTime.UtcNow.AddDays(25)
                },
                new Job
                {
                    JobId = Guid.NewGuid(),
                    JobDescriptionId = jd4Id,
                    OpeningsCount = 5,
                    CreatedByUserId = Guid.Parse("331a9809-54d9-43c3-883a-493e8787f97a"),
                    CreatedDate = DateTime.UtcNow.AddDays(-3),
                    DeadlineDate = DateTime.UtcNow.AddDays(30)
                }
            );
            // --- jobs ---

            // AssignedReviewer -> Reviewer (User)
            modelBuilder.Entity<AssignedReviewer>()
                .HasOne(ar => ar.Reviewer)
                .WithMany()
                .HasForeignKey(ar => ar.Uid)
                .OnDelete(DeleteBehavior.NoAction);

            // CVReviewStage -> Reviewer (User)
            modelBuilder.Entity<CVReviewStage>()
                .HasOne(c => c.Reviewer)
                .WithMany()
                .HasForeignKey(c => c.ReviewedByUid)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CVReviewStage>(entity =>
            {
                entity.HasKey(c => c.CVReviewStageSid);

                //entity.HasOne(c => c.JobApplication)
                //      .WithMany(j => j.CVReviewStages)
                //      .HasForeignKey(c => c.JobApplicationId)
                //      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Reviewer)
                      .WithMany() // or WithMany(r => r.CVReviewStages) if needed
                      .HasForeignKey(c => c.ReviewedByUid)
                      .OnDelete(DeleteBehavior.NoAction); // <-- important fix

                //entity.HasOne(c => c.AssignedReviewer)
                //      .WithMany()
                //      .HasForeignKey(c => c.AssignedReviewersId)
                //      .OnDelete(DeleteBehavior.NoAction); // <-- prevents multi-path cascade
            });

        }
    }
}
