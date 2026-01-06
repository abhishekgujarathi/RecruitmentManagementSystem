using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Common;
using RecruitmentManagementSystem.API.Models;

namespace RecruitmentManagementSystem.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        // --- users ---
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }


        // --- users ---

        // --- employye ---
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<EmployeeUserRole> EmployeeUserRoles { get; set; }
        // --- employye ---

        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }
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


        // --- review ---
        // public DbSet<JobReviewer> JobReviewers { get; set; }
        public DbSet<AssignedReviewer> AssignedReviewers { get; set; }
        public DbSet<ApplicationSkill> ApplicationSkills { get; set; }
        public DbSet<ReviewComment> ReviewComments { get; set; }
        // --- review ---


        // --- interview ---
        public DbSet<JobInterviewRound> JobInterviewRounds { get; set; }
        public DbSet<ApplicationInterviewRound> ApplicationInterviewRounds { get; set; }
        public DbSet<InterviewPanelMember> InterviewPanelMembers { get; set; }

        // --- interview ---

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // --- user --

            //var candidateTypeId = Guid.Parse("E91D74B9-67CB-41B5-9581-338A64A45122");
            //var employeeTypeId = Guid.Parse("3B5143AA-62F9-49B8-BA06-3AE28505528E");

            //modelBuilder.Entity<UserType>().HasData(
            //    new UserType { UserTypeId = candidateTypeId, TypeName = "Candidate", active = true },
            //    new UserType { UserTypeId = employeeTypeId, TypeName = "Employee", active = true }
            //);



            // -- employ roles --- 
            //var recruiterRoleId = Guid.Parse("A12961CE-53D2-4294-99CB-B7916DBCEC24");
            //var reviewerRoleId = Guid.Parse("9C0D0137-9B2E-47D5-8DAC-8BC00BFD6E49");
            //var interviewerRoleId = Guid.Parse("041C97A7-8CB7-4476-B7B3-5FF64BBBA57F");

            //modelBuilder.Entity<EmployeeRole>().HasData(
            //    new EmployeeRole { EmployeeRoleId = recruiterRoleId, RoleName = "Recruiter", IsActive = true },
            //    new EmployeeRole { EmployeeRoleId = reviewerRoleId, RoleName = "Reviewer", IsActive = true },
            //    new EmployeeRole { EmployeeRoleId = interviewerRoleId, RoleName = "Interviewer", IsActive = true }
            //);

            // -- employ roles --- 


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasOne(u => u.CandidateProfile)
                    .WithOne(cp => cp.User)
                    .HasForeignKey<CandidateProfile>(cp => cp.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.UserType)
                  .WithMany(ut => ut.Users)
                  .HasForeignKey(u => u.UserTypeId)
                  .OnDelete(DeleteBehavior.Restrict);


                entity.HasIndex(e => e.Email).IsUnique();
            });


            //var passwordHasher = new PasswordHasher<User>();
            //var adminUser = new User
            //{
            //    UserId = Guid.Parse("a01a33a1-10c5-4424-a74b-0130a086b96e"),
            //    Fname = "Admin",
            //    Lname = "User",
            //    Email = "admin@exp.com",
            //    MobileNumber = "1234567890",
            //    CreatedDate = DateTime.UtcNow,
            //    DOB = new DateTime(1990, 1, 1),
            //    Gender = "Male",
            //    IsActive = true,
            //    UserTypeId = employeeTypeId
            //};
            //adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "1234567890");

            //var recruiterUser = new User
            //{
            //    UserId = Guid.Parse("331a9809-54d9-43c3-883a-493e8787f97a"),
            //    Fname = "Peter",
            //    Lname = "Parker",
            //    Email = "peter@exp.com",
            //    MobileNumber = "0987654321",
            //    CreatedDate = DateTime.UtcNow,
            //    DOB = new DateTime(1995, 5, 10),
            //    Gender = "Male",
            //    IsActive = true,
            //    UserTypeId = employeeTypeId
            //};
            //recruiterUser.PasswordHash = passwordHasher.HashPassword(recruiterUser, "1234567890");




            //var reviewerUserId = Guid.Parse("7c6a8f5b-9b2e-4e4a-a1a1-111111111111");
            //var reviewerUser = new User
            //{
            //    UserId = reviewerUserId,
            //    Fname = "Bruce",
            //    Lname = "Wayne",
            //    Email = "reviewer@exp.com",
            //    MobileNumber = "2222222222",
            //    CreatedDate = DateTime.UtcNow,
            //    DOB = new DateTime(1992, 3, 15),
            //    Gender = "Male",
            //    IsActive = true,
            //    UserTypeId = employeeTypeId
            //};
            //reviewerUser.PasswordHash = passwordHasher.HashPassword(reviewerUser, "1234567890");

            //var interviewerUserId = Guid.Parse("8d7b9a6c-4c3f-4b5d-b2b2-222222222222");
            //var interviewerUser = new User
            //{
            //    UserId = interviewerUserId,
            //    Fname = "Tony",
            //    Lname = "Stark",
            //    Email = "interviewer@exp.com",
            //    MobileNumber = "3333333333",
            //    CreatedDate = DateTime.UtcNow,
            //    DOB = new DateTime(1988, 5, 29),
            //    Gender = "Male",
            //    IsActive = true,
            //    UserTypeId = employeeTypeId
            //};
            //interviewerUser.PasswordHash = passwordHasher.HashPassword(interviewerUser, "1234567890");




            //var candidate1UserId = Guid.NewGuid();
            //var candidate1 = new User
            //{
            //    UserId = candidate1UserId,
            //    Fname = "Priya",
            //    Lname = "Sharma",
            //    Email = "priya.sharma@email.com",
            //    MobileNumber = "9876543210",
            //    CreatedDate = DateTime.UtcNow.AddMonths(-6),
            //    DOB = new DateTime(1995, 3, 15),
            //    Gender = "Female",
            //    IsActive = true,
            //    UserTypeId = candidateTypeId
            //};
            //candidate1.PasswordHash = passwordHasher.HashPassword(candidate1, "1234567890");

            //var candidate2UserId = Guid.NewGuid();
            //var candidate2 = new User
            //{
            //    UserId = candidate2UserId,
            //    Fname = "Rajesh",
            //    Lname = "Kumar",
            //    Email = "rajesh.kumar@email.com",
            //    MobileNumber = "9876543211",
            //    CreatedDate = DateTime.UtcNow.AddMonths(-4),
            //    DOB = new DateTime(1997, 7, 22),
            //    Gender = "Male",
            //    IsActive = true,
            //    UserTypeId = candidateTypeId
            //};
            //candidate2.PasswordHash = passwordHasher.HashPassword(candidate2, "1234567890");

            //var candidate3UserId = Guid.Parse("0a33c200-c9f2-4547-810a-b3337a72d733");
            //var candidate3 = new User
            //{
            //    UserId = candidate3UserId,
            //    Fname = "Abhi",
            //    Lname = "G",
            //    Email = "abhi@exp.com",
            //    MobileNumber = "1111111111",
            //    CreatedDate = DateTime.UtcNow,
            //    DOB = new DateTime(1998, 8, 25),
            //    Gender = "Male",
            //    IsActive = true,
            //    UserTypeId = candidateTypeId
            //};
            //candidate3.PasswordHash = passwordHasher.HashPassword(candidate3, "1234567890");

            //modelBuilder.Entity<User>().HasData(
            //    adminUser,
            //    recruiterUser,
            //    reviewerUser,
            //    interviewerUser
            //);
            //modelBuilder.Entity<User>().HasData(
            //    candidate1,
            //    candidate2,
            //    candidate3
            //);


            //// list of generated employees
            //// --- additional employee users ---
            //var employee1 = new User
            //{
            //    UserId = Guid.NewGuid(),
            //    Fname = "Rahul",
            //    Lname = "Sharma",
            //    Email = "rahul@exp.com",
            //    MobileNumber = "9000000001",
            //    CreatedDate = DateTime.UtcNow,
            //    DOB = new DateTime(1990, 2, 12),
            //    Gender = "Male",
            //    IsActive = true,
            //    UserTypeId = employeeTypeId
            //};
            //employee1.PasswordHash = passwordHasher.HashPassword(employee1, "1234567890");

            //var employee2 = new User
            //{
            //    UserId = Guid.NewGuid(),
            //    Fname = "Priya",
            //    Lname = "Verma",
            //    Email = "priya@exp.com",
            //    MobileNumber = "9000000002",
            //    CreatedDate = DateTime.UtcNow,
            //    DOB = new DateTime(1992, 7, 8),
            //    Gender = "Female",
            //    IsActive = true,
            //    UserTypeId = employeeTypeId
            //};
            //employee2.PasswordHash = passwordHasher.HashPassword(employee2, "1234567890");

            //var employee3 = new User
            //{
            //    UserId = Guid.NewGuid(),
            //    Fname = "Amit",
            //    Lname = "Kumar",
            //    Email = "amit@exp.com",
            //    MobileNumber = "9000000003",
            //    CreatedDate = DateTime.UtcNow,
            //    DOB = new DateTime(1989, 11, 20),
            //    Gender = "Male",
            //    IsActive = true,
            //    UserTypeId = employeeTypeId
            //};
            //employee3.PasswordHash = passwordHasher.HashPassword(employee3, "1234567890");

            //var employee4 = new User
            //{
            //    UserId = Guid.NewGuid(),
            //    Fname = "Sneha",
            //    Lname = "Reddy",
            //    Email = "sneha@exp.com",
            //    MobileNumber = "9000000004",
            //    CreatedDate = DateTime.UtcNow,
            //    DOB = new DateTime(1994, 5, 5),
            //    Gender = "Female",
            //    IsActive = true,
            //    UserTypeId = employeeTypeId
            //};
            //employee4.PasswordHash = passwordHasher.HashPassword(employee4, "1234567890");

            //// --- add them to modelBuilder ---
            //modelBuilder.Entity<User>().HasData(
            //    employee1,
            //    employee2,
            //    employee3,
            //    employee4
            //);

            // list of generated employees


            // --- assigninroles to m-t-m --- 

            // definnin composite key due to m-t-m
            modelBuilder.Entity<EmployeeUserRole>()
                .HasKey(eur => new { eur.UserId, eur.EmployeeRoleId });


            modelBuilder.Entity<EmployeeUserRole>()
                .HasOne(eur => eur.User) //every employe userrole has one user
                .WithMany(u => u.EmployeeUserRoles)
                .HasForeignKey(eur => eur.UserId);

            modelBuilder.Entity<EmployeeUserRole>()
                .HasOne(eur => eur.EmployeeRole)
                .WithMany(er => er.EmployeeUserRoles)
                .HasForeignKey(eur => eur.EmployeeRoleId);

            // --- assigninroles to m-t-m --- 


            // --- adding roles to users ---
            //modelBuilder.Entity<EmployeeUserRole>().HasData(
            //    new EmployeeUserRole
            //    {
            //        UserId = recruiterUser.UserId,
            //        EmployeeRoleId = recruiterRoleId,
            //        AssignedOn = DateTime.UtcNow
            //    },
            //    new EmployeeUserRole
            //    {
            //        UserId = reviewerUser.UserId,
            //        EmployeeRoleId = reviewerRoleId,
            //        AssignedOn = DateTime.UtcNow
            //    },
            //    new EmployeeUserRole
            //    {
            //        UserId = interviewerUser.UserId,
            //        EmployeeRoleId = interviewerRoleId,
            //        AssignedOn = DateTime.UtcNow
            //    }
            //);

            // --- adding roles to users ---


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

            //var candidateProfile1Id = Guid.NewGuid();
            //modelBuilder.Entity<CandidateProfile>().HasData(
            //    new CandidateProfile
            //    {
            //        CandidateProfileId = candidateProfile1Id,
            //        UserId = candidate1UserId,
            //        Address = "A-304, Sunrise Apartments, Koramangala",
            //        City = "Bangalore",
            //        State = "Karnataka",
            //        Country = "India",
            //        PostalCode = "560034"
            //    }
            //);

            //var candidateProfile2Id = Guid.NewGuid();
            //modelBuilder.Entity<CandidateProfile>().HasData(
            //    new CandidateProfile
            //    {
            //        CandidateProfileId = candidateProfile2Id,
            //        UserId = candidate2UserId,
            //        Address = "B-12, Green Valley Society, Bandra West",
            //        City = "Mumbai",
            //        State = "Maharashtra",
            //        Country = "India",
            //        PostalCode = "400050"
            //    }
            //);

            //var candidateProfile3Id = Guid.Parse("29d665b6-7013-4170-a8eb-844f2d79d356");
            //modelBuilder.Entity<CandidateProfile>().HasData(
            //    new CandidateProfile
            //    {
            //        CandidateProfileId = candidateProfile3Id,
            //        UserId = candidate3UserId,
            //        Address = "123 Main Street, Apartment 4B",
            //        City = "Mumbai",
            //        State = "Maharashtra",
            //        Country = "India",
            //        PostalCode = "400001"
            //    }
            //);

            // --- candidate profile ---

            // --- socials ---
            modelBuilder.Entity<SocialPlatform>(entity =>
            {
                entity.HasKey(e => e.SocialPlatformId);
                entity.HasIndex(e => e.Name).IsUnique();
            });

            //var linkedInId = Guid.NewGuid();
            //var githubId = Guid.NewGuid();
            //var portfolioId = Guid.NewGuid();
            //var twitterId = Guid.NewGuid();
            //var stackOverflowId = Guid.NewGuid();

            //modelBuilder.Entity<SocialPlatform>().HasData(
            //    new SocialPlatform { SocialPlatformId = linkedInId, Name = "LinkedIn" },
            //    new SocialPlatform { SocialPlatformId = githubId, Name = "GitHub" },
            //    new SocialPlatform { SocialPlatformId = portfolioId, Name = "Portfolio" },
            //    new SocialPlatform { SocialPlatformId = twitterId, Name = "Twitter" },
            //    new SocialPlatform { SocialPlatformId = stackOverflowId, Name = "Stack Overflow" }
            //);

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
            //var edu1Id = Guid.Parse("b3f2c0e1-6f2a-4a6c-9f8a-1a2b3c4d5e01");
            //var edu2Id = Guid.Parse("c4d3f1a2-7b3c-4d8e-9a0b-2c3d4e5f6a02");


            //modelBuilder.Entity<Education>().HasData(
            //new Education
            //{
            //    EducationId = Guid.NewGuid(),
            //    CandidateProfileId = candidateProfile1Id,
            //    InstituteName = "RV College of Engineering, Bangalore",
            //    DegreeType = "B.E",
            //    FieldOfStudy = "Computer Science and Engineering",
            //    PercentageScore = 82.50m,
            //    StartDate = new DateTime(2013, 8, 1),
            //    EndDate = new DateTime(2017, 6, 30),
            //    IsCurrent = false
            //},
            //new Education
            //{
            //    EducationId = Guid.NewGuid(),
            //    CandidateProfileId = candidateProfile1Id,
            //    InstituteName = "National Public School, Bangalore",
            //    DegreeType = "12th Grade",
            //    FieldOfStudy = "Science (PCMC)",
            //    PercentageScore = 89.00m,
            //    StartDate = new DateTime(2011, 6, 1),
            //    EndDate = new DateTime(2013, 5, 31),
            //    IsCurrent = false
            //}
//);

            //modelBuilder.Entity<Education>().HasData(
            //    new Education
            //    {
            //        EducationId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile2Id,
            //        InstituteName = "Mumbai University - DJ Sanghvi College",
            //        DegreeType = "B.Tech",
            //        FieldOfStudy = "Information Technology",
            //        PercentageScore = 75.20m,
            //        StartDate = new DateTime(2015, 7, 1),
            //        EndDate = new DateTime(2019, 5, 31),
            //        IsCurrent = false
            //    },
            //    new Education
            //    {
            //        EducationId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile2Id,
            //        InstituteName = "St. Xavier's High School, Mumbai",
            //        DegreeType = "HSC (12th)",
            //        FieldOfStudy = "Science",
            //        PercentageScore = 81.50m,
            //        StartDate = new DateTime(2013, 6, 1),
            //        EndDate = new DateTime(2015, 4, 30),
            //        IsCurrent = false
            //    }
            //);


            //modelBuilder.Entity<Education>().HasData(
            //    new Education
            //    {
            //        EducationId = edu1Id,
            //        CandidateProfileId = candidateProfile3Id,
            //        InstituteName = "St. Xavier's College, Mumbai",
            //        DegreeType = "B.Tech",
            //        FieldOfStudy = "Computer Science",
            //        PercentageScore = 78.45m,
            //        StartDate = new DateTime(2016, 7, 1),
            //        EndDate = new DateTime(2020, 5, 31),
            //        IsCurrent = false
            //    },
            //    new Education
            //    {
            //        EducationId = edu2Id,
            //        CandidateProfileId = candidateProfile3Id,
            //        InstituteName = "Mumbai Central Higher Secondary School",
            //        DegreeType = "Higher Secondary (12th)",
            //        FieldOfStudy = "Science",
            //        PercentageScore = 86.20m,
            //        StartDate = new DateTime(2014, 6, 1),
            //        EndDate = new DateTime(2016, 4, 30),
            //        IsCurrent = false
            //    }
            //);
            //// --- education ---

            //// --- experience ---
            //var exp1Id = Guid.Parse("d5e4f3b2-8c4d-4e9f-0a1b-3c4d5e6f7a03");
            //var exp2Id = Guid.Parse("e6f5a4c3-9d5e-4f0a-1b2c-4d5e6f7a8b04");

            //modelBuilder.Entity<Experience>().HasData(
            //    new Experience
            //    {
            //        ExperienceId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile1Id,
            //        CompanyName = "Infosys Technologies Ltd",
            //        Position = "Senior Software Engineer",
            //        DurationYears = 3.50m,
            //        StartDate = new DateTime(2020, 7, 1),
            //        EndDate = new DateTime(2024, 1, 31),
            //        IsCurrent = false,
            //        JobDescription = "Led a team of 4 developers in building enterprise applications using .NET Core and Angular. Implemented microservices architecture, optimized database queries, and mentored junior developers."
            //    },
            //    new Experience
            //    {
            //        ExperienceId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile1Id,
            //        CompanyName = "TCS Digital",
            //        Position = "Software Developer",
            //        DurationYears = 3.00m,
            //        StartDate = new DateTime(2017, 7, 1),
            //        EndDate = new DateTime(2020, 6, 30),
            //        IsCurrent = false,
            //        JobDescription = "Developed and maintained web applications using ASP.NET MVC and SQL Server. Participated in code reviews, unit testing, and agile ceremonies."
            //    }
            //);

            //modelBuilder.Entity<Experience>().HasData(
            //    new Experience
            //    {
            //        ExperienceId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile2Id,
            //        CompanyName = "Wipro Digital",
            //        Position = "Frontend Developer",
            //        DurationYears = 2.50m,
            //        StartDate = new DateTime(2021, 8, 1),
            //        EndDate = new DateTime(2024, 2, 28),
            //        IsCurrent = false,
            //        JobDescription = "Built responsive web applications using React, Redux, and TypeScript. Collaborated with UX designers and backend teams to deliver pixel-perfect interfaces. Improved page load times by 40%."
            //    },
            //    new Experience
            //    {
            //        ExperienceId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile2Id,
            //        CompanyName = "Cognizant",
            //        Position = "Junior Frontend Developer",
            //        DurationYears = 1.50m,
            //        StartDate = new DateTime(2019, 7, 1),
            //        EndDate = new DateTime(2021, 1, 31),
            //        IsCurrent = false,
            //        JobDescription = "Worked on client projects using HTML, CSS, JavaScript, and basic React. Fixed bugs, implemented new features, and learned modern frontend development practices."
            //    }
            //);

            //modelBuilder.Entity<Experience>().HasData(
            //    new Experience
            //    {
            //        ExperienceId = exp1Id,
            //        CandidateProfileId = candidateProfile3Id,
            //        CompanyName = "InnoTech Solutions Pvt. Ltd.",
            //        Position = "Software Engineer",
            //        DurationYears = 2.50m,
            //        StartDate = new DateTime(2020, 7, 1),
            //        EndDate = new DateTime(2022, 6, 30),
            //        IsCurrent = false,
            //        JobDescription = "Worked on backend APIs using .NET Core, implemented authentication and REST endpoints, wrote unit tests and integrated CI/CD pipelines."
            //    },
            //    new Experience
            //    {
            //        ExperienceId = exp2Id,
            //        CandidateProfileId = candidateProfile3Id,
            //        CompanyName = "QuickStart Internships",
            //        Position = "Software Intern",
            //        DurationYears = 0.50m,
            //        StartDate = new DateTime(2019, 6, 1),
            //        EndDate = new DateTime(2019, 11, 30),
            //        IsCurrent = false,
            //        JobDescription = "Assisted in developing small features, bug fixes and wrote documentation. Gained exposure to agile practices."
            //    }
            //);
            //// --- experience ---


            //// --- skills ---
            //var skill1Id = Guid.Parse("43FF8410-B479-4846-956A-DF3C56FFD882");
            //var skill2Id = Guid.Parse("CC858B5F-73D0-4933-880D-3CA36CDFD2C6");
            //var skill3Id = Guid.Parse("355E3B35-1706-480C-B5AB-6BE7707B49E0");
            //var skill4Id = Guid.Parse("D161A587-31D4-45EA-A184-80495BDF6895");
            //var skill5Id = Guid.Parse("07A14CDE-7266-405A-9FA8-8A71554C7868");
            //var skill6Id = Guid.Parse("1798CDA1-F1EF-45E6-9BBC-E9CA5970C5C0");
            //var skill7Id = Guid.Parse("4C487BBC-6FA9-4643-9D9E-A88E5BEA917E");
            //var skill8Id = Guid.Parse("92DC292B-9DF8-419A-8424-8939F94F3C98");
            

            //modelBuilder.Entity<Skill>().HasData(
            //    new Skill { SkillId = skill1Id, Name = "C#" },
            //    new Skill { SkillId = skill2Id, Name = "ASP.NET Core" },
            //    new Skill { SkillId = skill3Id, Name = "Entity Framework Core" },
            //    new Skill { SkillId = skill4Id, Name = "SQL Server" },
            //    new Skill { SkillId = skill5Id, Name = "JavaScript" },
            //    new Skill { SkillId = skill6Id, Name = "React" },
            //    new Skill { SkillId = skill7Id, Name = "Python", IsActive = true },
            //    new Skill { SkillId = skill8Id, Name = "Java", IsActive = true }
            //);

            //modelBuilder.Entity<CandidateSkill>().HasData(
            //    new CandidateSkill { CandidateSkillId = Guid.NewGuid(), CandidateProfileId = candidateProfile3Id, SkillId = skill1Id, ExperienceYears = 5, ProficiencyLevel = "Beginner" },
            //    new CandidateSkill { CandidateSkillId = Guid.NewGuid(), CandidateProfileId = candidateProfile3Id, SkillId = skill2Id, ExperienceYears = 4, ProficiencyLevel = "Beginner" },
            //    new CandidateSkill { CandidateSkillId = Guid.NewGuid(), CandidateProfileId = candidateProfile3Id, SkillId = skill6Id, ExperienceYears = 5, ProficiencyLevel = "Beginner" },
            //    new CandidateSkill { CandidateSkillId = Guid.NewGuid(), CandidateProfileId = candidateProfile3Id, SkillId = skill4Id, ExperienceYears = 4, ProficiencyLevel = "Beginner" },
            //    new CandidateSkill { CandidateSkillId = Guid.NewGuid(), CandidateProfileId = candidateProfile1Id, SkillId = skill3Id, ExperienceYears = 4, ProficiencyLevel = "Advanced" },
            //    new CandidateSkill { CandidateSkillId = Guid.NewGuid(), CandidateProfileId = candidateProfile1Id, SkillId = skill4Id, ExperienceYears = 6, ProficiencyLevel = "Advanced" },
            //    new CandidateSkill { CandidateSkillId = Guid.NewGuid(), CandidateProfileId = candidateProfile2Id, SkillId = skill5Id, ExperienceYears = 5, ProficiencyLevel = "Advanced" }
            // );
            //// --- skills ---

            //// --- socials  ---

            //modelBuilder.Entity<CandidateSocial>().HasData(
            //    new CandidateSocial
            //    {
            //        CandidateSocialsId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile1Id,
            //        SocialPlatformId = linkedInId,
            //        Link = "https://linkedin.com/in/priya-sharma-dev"
            //    },
            //    new CandidateSocial
            //    {
            //        CandidateSocialsId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile1Id,
            //        SocialPlatformId = githubId,
            //        Link = "https://github.com/priyasharma"
            //    }
            //);

            //modelBuilder.Entity<CandidateSocial>().HasData(
            //    new CandidateSocial
            //    {
            //        CandidateSocialsId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile2Id,
            //        SocialPlatformId = linkedInId,
            //        Link = "https://linkedin.com/in/rajesh-kumar-frontend"
            //    },
            //    new CandidateSocial
            //    {
            //        CandidateSocialsId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile2Id,
            //        SocialPlatformId = githubId,
            //        Link = "https://github.com/rajeshkumar-dev"
            //    },
            //    new CandidateSocial
            //    {
            //        CandidateSocialsId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile2Id,
            //        SocialPlatformId = portfolioId,
            //        Link = "https://rajeshkumar.dev"
            //    }
            //);

            //modelBuilder.Entity<CandidateSocial>().HasData(
            //    new CandidateSocial
            //    {
            //        CandidateSocialsId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile3Id,
            //        SocialPlatformId = linkedInId,
            //        Link = "https://linkedin.com/in/test-user"
            //    },
            //    new CandidateSocial
            //    {
            //        CandidateSocialsId = Guid.NewGuid(),
            //        CandidateProfileId = candidateProfile3Id,
            //        SocialPlatformId = githubId,
            //        Link = "https://github.com/testuser"
            //    }
            //);
            //// --- socials  ---



            //// --- jobs ---
            //var fullTimeTypeId = Guid.NewGuid();
            //var partTimeTypeId = Guid.NewGuid();
            //var contractTypeId = Guid.NewGuid();

            //modelBuilder.Entity<JobType>().HasData(
            //    new JobType
            //    {
            //        JobTypeId = fullTimeTypeId,
            //        TypeName = "Full-Time"
            //    },
            //    new JobType
            //    {
            //        JobTypeId = partTimeTypeId,
            //        TypeName = "Part-Time"
            //    },
            //    new JobType
            //    {
            //        JobTypeId = contractTypeId,
            //        TypeName = "Contract"
            //    }
            //);

            //// seed JobDescriptions
            //var jd1Id = Guid.NewGuid();
            //var jd2Id = Guid.NewGuid();
            //var jd3Id = Guid.NewGuid();
            //var jd4Id = Guid.NewGuid();

            //modelBuilder.Entity<JobDescription>().HasData(
            //    new JobDescription
            //    {
            //        JobDescriptionId = jd1Id,
            //        Title = "Senior .NET Developer",
            //        Details = "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.",
            //        Responsibilty = "Develop and maintain web applications, code reviews, mentor junior developers",
            //        Location = "Mumbai, India",
            //        MinimumExperienceReq = 5,
            //        JobTypeId = fullTimeTypeId
            //    },
            //    new JobDescription
            //    {
            //        JobDescriptionId = jd2Id,
            //        Title = "Frontend React Developer",
            //        Details = "Join our frontend team to build modern web applications using React and TypeScript.",
            //        Responsibilty = "Build responsive UIs, optimize performance, collaborate with designers",
            //        Location = "Bangalore, India",
            //        MinimumExperienceReq = 3,
            //        JobTypeId = fullTimeTypeId
            //    },
            //    new JobDescription
            //    {
            //        JobDescriptionId = jd3Id,
            //        Title = "DevOps Engineer",
            //        Details = "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.",
            //        Responsibilty = "Maintain AWS infrastructure, automate deployments, monitor systems",
            //        Location = "Remote",
            //        MinimumExperienceReq = 4,
            //        JobTypeId = contractTypeId
            //    },
            //    new JobDescription
            //    {
            //        JobDescriptionId = jd4Id,
            //        Title = "Junior Python Developer",
            //        Details = "Entry-level position for fresh graduates passionate about Python and data science.",
            //        Responsibilty = "Write clean code, learn from seniors, contribute to data pipelines",
            //        Location = "Pune, India",
            //        MinimumExperienceReq = 0,
            //        JobTypeId = partTimeTypeId
            //    }
            //);

            //// job idss
            //var job1Id = Guid.Parse("A83A2E30-7D33-4829-BF86-E9CCE7462B53");
            //var job2Id = Guid.Parse("AF6B7D6B-2128-4E5F-8804-D5209A38E443");
            //var job3Id = Guid.Parse("F9651A24-9357-4AF0-A9F0-96F5736E8EB6");
            //var job4Id = Guid.Parse("15697654-2E8E-412B-B35E-8226CF911237");

            //// createing jobs
            //modelBuilder.Entity<Job>().HasData(
            //    new Job
            //    {
            //        JobId = job1Id,
            //        JobDescriptionId = jd1Id,
            //        OpeningsCount = 3,
            //        CreatedByUserId = Guid.Parse("331a9809-54d9-43c3-883a-493e8787f97a"), // peter userid [recruit]
            //        CreatedDate = DateTime.UtcNow.AddDays(-10),
            //        DeadlineDate = DateTime.UtcNow.AddDays(20)
            //    },
            //    new Job
            //    {
            //        JobId = job2Id,
            //        JobDescriptionId = jd2Id,
            //        OpeningsCount = 2,
            //        CreatedByUserId = Guid.Parse("331a9809-54d9-43c3-883a-493e8787f97a"),
            //        CreatedDate = DateTime.UtcNow.AddDays(-7),
            //        DeadlineDate = DateTime.UtcNow.AddDays(23)
            //    },
            //    new Job
            //    {
            //        JobId = job3Id,
            //        JobDescriptionId = jd3Id,
            //        OpeningsCount = 1,
            //        CreatedByUserId = Guid.Parse("331a9809-54d9-43c3-883a-493e8787f97a"),
            //        CreatedDate = DateTime.UtcNow.AddDays(-5),
            //        DeadlineDate = DateTime.UtcNow.AddDays(25)
            //    },
            //    new Job
            //    {
            //        JobId = job4Id,
            //        JobDescriptionId = jd4Id,
            //        OpeningsCount = 5,
            //        CreatedByUserId = Guid.Parse("331a9809-54d9-43c3-883a-493e8787f97a"),
            //        CreatedDate = DateTime.UtcNow.AddDays(-3),
            //        DeadlineDate = DateTime.UtcNow.AddDays(30)
            //    }
            //);

            //// job 1
            //modelBuilder.Entity<JobSkill>().HasData(
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job1Id, SkillId = skill1Id, MinExperienceYears = 5 },  
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job1Id, SkillId = skill2Id, MinExperienceYears = 4 },  
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job1Id, SkillId = skill3Id, MinExperienceYears = 3 },  
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job1Id, SkillId = skill4Id, MinExperienceYears = 4 },  
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job1Id, SkillId = skill5Id, MinExperienceYears = 4 }  
            //);

            //// job 2
            //modelBuilder.Entity<JobSkill>().HasData(
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job2Id, SkillId = skill6Id, MinExperienceYears = 3 },
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job2Id, SkillId = skill5Id, MinExperienceYears = 3 },
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job2Id, SkillId = skill1Id, MinExperienceYears = 2 },
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job2Id, SkillId = skill3Id, MinExperienceYears = 2 }
            //);

            //// job 3
            //modelBuilder.Entity<JobSkill>().HasData(
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job3Id, SkillId = skill1Id, MinExperienceYears = 4 },
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job3Id, SkillId = skill2Id, MinExperienceYears = 3 },
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job3Id, SkillId = skill3Id, MinExperienceYears = 2 },
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job3Id, SkillId = skill7Id, MinExperienceYears = 3 },
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job3Id, SkillId = skill6Id, MinExperienceYears = 3 }
            //);

            //// job 4
            //modelBuilder.Entity<JobSkill>().HasData(
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job4Id, SkillId = skill7Id, MinExperienceYears = 0 },
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job4Id, SkillId = skill4Id, MinExperienceYears = 0 },
            //    new JobSkill { JobSkillId = Guid.NewGuid(), JobId = job4Id, SkillId = skill6Id, MinExperienceYears = 0 }
            //);
            //// --- jobs ---


            //// --- INTERVIEW ---
            //var intr1 = Guid.NewGuid();
            //var intr2 = Guid.NewGuid();
            //var intr3 = Guid.NewGuid();
            //modelBuilder.Entity<JobInterviewRound>().HasData(
            //    new JobInterviewRound { JobInterviewRoundId = intr1, JobId = job1Id, RoundNumber = 1, RoundType = InterviewRoundType.Technical },
            //    new JobInterviewRound { JobInterviewRoundId = intr2, JobId = job1Id, RoundNumber = 2, RoundType = InterviewRoundType.Technical },
            //    new JobInterviewRound { JobInterviewRoundId = intr3, JobId = job1Id, RoundNumber = 3, RoundType = InterviewRoundType.HR }
            //    );
            // --- INTERVIEW ---



            // AssignedReviewer -> Reviewer (User)
            modelBuilder.Entity<AssignedReviewer>()
                .HasOne(ar => ar.Reviewer)
                .WithMany()
                .HasForeignKey(ar => ar.ReviewerUserId)
                .OnDelete(DeleteBehavior.NoAction);




            modelBuilder.Entity<AssignedReviewer>(entity =>
            {
                entity.HasOne(ar => ar.Reviewer)
                      .WithMany()
                      .HasForeignKey(ar => ar.ReviewerUserId)
                      .OnDelete(DeleteBehavior.NoAction);
            });



            // job application and review
            modelBuilder.Entity<JobApplication>()
                .HasMany(j => j.ReviewComments)
                .WithOne(c => c.JobApplication)
                .HasForeignKey(c => c.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<JobApplication>()
                .HasMany(j => j.ApplicationSkills)
                .WithOne(s => s.JobApplication)
                .HasForeignKey(s => s.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReviewComment>()
               .HasOne(rc => rc.CommentedBy)
               .WithMany()
               .HasForeignKey(rc => rc.CommentedByUid)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReviewComment>()
                .HasOne(rc => rc.JobApplication)
                .WithMany(ja => ja.ReviewComments)
                .HasForeignKey(rc => rc.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
            // job application and review


            //adding job skills
            modelBuilder.Entity<JobSkill>()
                .HasOne(js => js.Job)
                .WithMany(j => j.JobSkills)
                .HasForeignKey(js => js.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobSkill>()
                .HasOne(js => js.Skill)
                .WithMany()
                .HasForeignKey(js => js.SkillId)
                .OnDelete(DeleteBehavior.Restrict);
            //adding job skills


            // --- job application ---
            //var app1Id = Guid.NewGuid();
            //modelBuilder.Entity<JobApplication>().HasData(
            //    new JobApplication
            //    {
            //        JobApplicationId = app1Id,
            //        CandidateProfileId = candidateProfile1Id,
            //        JobId = job2Id,
            //        ApplicationDate = DateTime.UtcNow.AddDays(-8),
            //        CurrentStatus = ApplicationStatus.Applied,
            //        StatusUpdatedAt = DateTime.UtcNow.AddDays(-8)
            //    }
            //);

            //var app2Id = Guid.NewGuid();
            //modelBuilder.Entity<JobApplication>().HasData(
            //    new JobApplication
            //    {
            //        JobApplicationId = app2Id,
            //        CandidateProfileId = candidateProfile2Id,
            //        JobId = job2Id,
            //        ApplicationDate = DateTime.UtcNow.AddDays(-7),
            //        CurrentStatus = ApplicationStatus.Applied,
            //        StatusUpdatedAt = DateTime.UtcNow.AddDays(-7)
            //    }
            //);

            //var app3Id = Guid.NewGuid();
            //modelBuilder.Entity<JobApplication>().HasData(
            //    new JobApplication
            //    {
            //        JobApplicationId = app3Id,
            //        CandidateProfileId = candidateProfile3Id,
            //        JobId = job2Id,
            //        ApplicationDate = DateTime.UtcNow.AddDays(-6),
            //        CurrentStatus = "Applied",
            //        StatusNote = "Application received",
            //        StatusUpdatedAt = DateTime.UtcNow.AddDays(-6)
            //    }
            //);
            // --- job application ---

            // --- interview --- 
           
            modelBuilder.Entity<InterviewPanelMember>()
                .HasOne(p => p.Interviewer)
                .WithMany()
                .HasForeignKey(p => p.InterviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InterviewPanelMember>()
                .HasOne(p => p.AssignedByUser)
                .WithMany()
                .HasForeignKey(p => p.AssignedByUserId)
                .OnDelete(DeleteBehavior.Restrict);


            // --- interview--- 


        }
    }
}
