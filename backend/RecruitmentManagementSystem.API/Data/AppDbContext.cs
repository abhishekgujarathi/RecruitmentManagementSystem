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
         public DbSet<JobReviewer> JobReviewers { get; set; }
        public DbSet<AssignedReviewer> AssignedReviewers { get; set; }
        public DbSet<ApplicationSkill> ApplicationSkills { get; set; }
        public DbSet<ReviewComment> ReviewComments { get; set; }
        // --- review ---


        // --- interview ---
        public DbSet<JobInterviewRound> JobInterviewRounds { get; set; }
        public DbSet<ApplicationInterviewRound> ApplicationInterviewRounds { get; set; }
        public DbSet<InterviewPanelMember> InterviewPanelMembers { get; set; }
        public DbSet<InterviewFeedback> InterviewFeedbacks { get; set; }
        public DbSet<InterviewSkillRating> InterviewSkillRatings { get; set; }

        // --- interview ---

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ====== NOTE ======
            //MOVED SEEDING VALUES TO DBSeeeder.cs AS THERE WAS ISSUE OF TRANSACTION NOT COMITIING AND HIGH LEVEL OF JOINS
            // ====== NOTE ======



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

            // --- socials ---
            modelBuilder.Entity<SocialPlatform>(entity =>
            {
                entity.HasKey(e => e.SocialPlatformId);
                entity.HasIndex(e => e.Name).IsUnique();
            });


            var linkedInId = Guid.Parse("D88D5DDB-E422-465C-B7CE-C1DA88F187AF");
            var githubId = Guid.Parse("BB043454-9CF5-4CA0-840F-93A1FFC758FB");
            var portfolioId = Guid.Parse("5F220026-119D-49B0-BC3D-973A222B7776");
            var twitterId = Guid.Parse("ADFC092E-EC21-46D2-81BA-B1D5FAD53FB5");
            var stackOverflowId = Guid.Parse("59819938-51E9-45F6-8B09-4E48F524F33B");

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



            // --- jobs ---
            var fullTimeTypeId = Guid.Parse("56B52F5C-4231-4C97-AB5F-D614B0276A97");
            var partTimeTypeId = Guid.Parse("2DCAE4CE-EDC0-4E8C-8250-ADDB75ED4B4B");
            var contractTypeId = Guid.Parse("57832921-0CD2-4EF1-92E9-E59371E5A210");

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


            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.CandidateProfile)
                .WithMany(cp => cp.Applications)
                .HasForeignKey(ja => ja.CandidateProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(ja => ja.JobId)
                .OnDelete(DeleteBehavior.Restrict);




            // AssignedReviewer -> Reviewer (User)
            modelBuilder.Entity<AssignedReviewer>()
                .HasOne(ar => ar.Reviewer)
                .WithMany()
                .HasForeignKey(ar => ar.ReviewerUserId)
                .OnDelete(DeleteBehavior.NoAction);


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

            modelBuilder.Entity<JobReviewer>()
               .HasOne(jr => jr.Reviewer)
               .WithMany()
               .HasForeignKey(jr => jr.ReviewerId)
               .OnDelete(DeleteBehavior.NoAction);
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


            // configuring application skilss [assessment by reviewer]
            modelBuilder.Entity<ApplicationSkill>()
                .HasOne(a => a.Skill)
                .WithMany()
                .HasForeignKey(a => a.SkillId)
                .OnDelete(DeleteBehavior.Restrict);


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
