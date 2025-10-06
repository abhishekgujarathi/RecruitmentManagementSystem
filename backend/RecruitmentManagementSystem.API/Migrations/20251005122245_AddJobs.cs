using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddJobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateProfiles_Users_UserId",
                table: "CandidateProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSocials_SocialPlatforms_SocialPlatformId",
                table: "CandidateSocials");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSocials_CandidateProfileId",
                table: "CandidateSocials");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SocialPlatforms",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("02e4be8b-15a9-4011-ae25-f73482ca4e8e"), "Full-Time" },
                    { new Guid("854d8de3-c784-4909-8da8-241b396c4010"), "Contract" },
                    { new Guid("c32c9516-c683-4625-9283-28ea9520580a"), "Part-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("088388ca-b8cf-4d94-90ee-c03562ce71ef"), true, "React" },
                    { new Guid("134303bf-b2be-4473-9706-71d23bfc7f3c"), true, "JavaScript" },
                    { new Guid("60f5ffd1-d4b7-4e72-9647-01b16646b95f"), true, "ASP.NET Core" },
                    { new Guid("87733bde-f2e7-40d3-97c4-464f4f27ef66"), true, "C#" },
                    { new Guid("87f06625-5b80-429e-8c04-7765e231d274"), true, "SQL Server" },
                    { new Guid("bff44ac1-3be4-4925-9497-0f8925a3fa0a"), true, "Entity Framework Core" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("21c31304-8287-4ad3-a0bf-23b40d766397"), "LinkedIn" },
                    { new Guid("23c9aca8-251d-4dbf-872f-133e1634cd23"), "Portfolio" },
                    { new Guid("939a6d0b-f7cd-4981-851f-16530fe5fa88"), "Stack Overflow" },
                    { new Guid("d9a179ad-4fc6-46cd-904d-acdd52419a14"), "GitHub" },
                    { new Guid("ecf71c95-f473-49ff-b685-c7ace212a833"), "Twitter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "RoleName", "active" },
                values: new object[,]
                {
                    { new Guid("8aba07c1-6de6-4713-97fc-3f4d648c34fd"), "Candidate", true },
                    { new Guid("927a290b-8499-40ca-8171-ce747bc7bf9c"), "Admin", true },
                    { new Guid("ff70f71b-ffaa-4567-8a7c-7f9958da162f"), "Recruiter", true }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("1a3d9590-3f60-4329-ae13-c5310ab2ca8a"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("02e4be8b-15a9-4011-ae25-f73482ca4e8e"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" },
                    { new Guid("2125f41d-e523-4766-be99-6546c617fdd3"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("02e4be8b-15a9-4011-ae25-f73482ca4e8e"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("5a82f40e-1871-4827-8a7c-01b6585fa01c"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("854d8de3-c784-4909-8da8-241b396c4010"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" },
                    { new Guid("70f7a9e4-7ae5-4ba1-9366-42ffef26c401"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("c32c9516-c683-4625-9283-28ea9520580a"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "DOB", "Email", "Fname", "Gender", "IsActive", "LastLogin", "Lname", "MobileNumber", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"), new DateTime(2025, 10, 5, 12, 22, 45, 173, DateTimeKind.Utc).AddTicks(8844), new DateTime(1998, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abhi@exp.com", "Abhi", "Male", true, null, "G", "1111111111", "AQAAAAIAAYagAAAAEDhwVuSJJFjivNrnSW2XEvzEnmtfiOw/C5vbg7qsvXDaC+ZzzIxg3vgV4duBzzZ4hw==", null, null, new Guid("8aba07c1-6de6-4713-97fc-3f4d648c34fd") },
                    { new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 10, 5, 12, 22, 45, 68, DateTimeKind.Utc).AddTicks(4954), new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "peter@exp.com", "Peter", "Male", true, null, "Parker", "0987654321", "AQAAAAIAAYagAAAAEBbX4pjbwlpZe/wSDqL30IrApMSXOMG8KqgzUP7rBtGshrtMUPgjCX50oQdKYQYqww==", null, null, new Guid("ff70f71b-ffaa-4567-8a7c-7f9958da162f") },
                    { new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"), new DateTime(2025, 10, 5, 12, 22, 44, 975, DateTimeKind.Utc).AddTicks(8319), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@exp.com", "Admin", "Male", true, null, "User", "1234567890", "AQAAAAIAAYagAAAAEPz58kU8s4KO8i5qZZ+3mN8/iUrZ28FJSgLzkzHigjQCSo2GCSDFa6P+7oDMhOjNiQ==", null, null, new Guid("927a290b-8499-40ca-8171-ce747bc7bf9c") }
                });

            migrationBuilder.InsertData(
                table: "CandidateProfiles",
                columns: new[] { "CandidateProfileId", "Address", "City", "Country", "PostalCode", "State", "UserId" },
                values: new object[] { new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "123 Main Street, Apartment 4B", "Mumbai", "India", "400001", "Maharashtra", new Guid("0a33c200-c9f2-4547-810a-b3337a72d733") });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("66e00fb5-2557-443f-9c15-90d33fee0d8e"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 9, 30, 12, 22, 45, 276, DateTimeKind.Utc).AddTicks(2660), new DateTime(2025, 10, 30, 12, 22, 45, 276, DateTimeKind.Utc).AddTicks(2661), new Guid("5a82f40e-1871-4827-8a7c-01b6585fa01c"), null, 1 },
                    { new Guid("7020c1b2-396f-46ca-8a64-4a36aed17a3c"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 9, 25, 12, 22, 45, 276, DateTimeKind.Utc).AddTicks(2644), new DateTime(2025, 10, 25, 12, 22, 45, 276, DateTimeKind.Utc).AddTicks(2652), new Guid("2125f41d-e523-4766-be99-6546c617fdd3"), null, 3 },
                    { new Guid("a7fdb57e-835a-4ff8-9109-c974c2731cdd"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 9, 28, 12, 22, 45, 276, DateTimeKind.Utc).AddTicks(2656), new DateTime(2025, 10, 28, 12, 22, 45, 276, DateTimeKind.Utc).AddTicks(2657), new Guid("1a3d9590-3f60-4329-ae13-c5310ab2ca8a"), null, 2 },
                    { new Guid("e7b7b31a-faf3-485e-86b5-441190ba01de"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 10, 2, 12, 22, 45, 276, DateTimeKind.Utc).AddTicks(2666), new DateTime(2025, 11, 4, 12, 22, 45, 276, DateTimeKind.Utc).AddTicks(2667), new Guid("70f7a9e4-7ae5-4ba1-9366-42ffef26c401"), null, 5 }
                });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("361a0b8e-67e8-476e-9468-f5bcbd8e492e"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("87733bde-f2e7-40d3-97c4-464f4f27ef66") },
                    { new Guid("98ead887-e855-41c1-b867-7e69ae9c5ab5"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("088388ca-b8cf-4d94-90ee-c03562ce71ef") },
                    { new Guid("e2dabaad-7283-4d14-b44d-38d3cb31a062"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("60f5ffd1-d4b7-4e72-9647-01b16646b95f") }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "CandidateProfileId", "DegreeType", "EndDate", "FieldOfStudy", "InstituteName", "IsCurrent", "PercentageScore", "StartDate" },
                values: new object[,]
                {
                    { new Guid("b3f2c0e1-6f2a-4a6c-9f8a-1a2b3c4d5e01"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "B.Tech", new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "St. Xavier's College, Mumbai", false, 78.45m, new DateTime(2016, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4d3f1a2-7b3c-4d8e-9a0b-2c3d4e5f6a02"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "Higher Secondary (12th)", new DateTime(2016, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Science", "Mumbai Central Higher Secondary School", false, 86.20m, new DateTime(2014, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "ExperienceId", "CandidateProfileId", "CompanyName", "DurationYears", "EndDate", "IsCurrent", "JobDescription", "Position", "StartDate" },
                values: new object[,]
                {
                    { new Guid("d5e4f3b2-8c4d-4e9f-0a1b-3c4d5e6f7a03"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "InnoTech Solutions Pvt. Ltd.", 2.50m, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Worked on backend APIs using .NET Core, implemented authentication and REST endpoints, wrote unit tests and integrated CI/CD pipelines.", "Software Engineer", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6f5a4c3-9d5e-4f0a-1b2c-4d5e6f7a8b04"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "QuickStart Internships", 0.50m, new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Assisted in developing small features, bug fixes and wrote documentation. Gained exposure to agile practices.", "Software Intern", new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialPlatforms_Name",
                table: "SocialPlatforms",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSocials_CandidateProfileId_SocialPlatformId",
                table: "CandidateSocials",
                columns: new[] { "CandidateProfileId", "SocialPlatformId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateProfiles_Users_UserId",
                table: "CandidateProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSocials_SocialPlatforms_SocialPlatformId",
                table: "CandidateSocials",
                column: "SocialPlatformId",
                principalTable: "SocialPlatforms",
                principalColumn: "SocialPlatformId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateProfiles_Users_UserId",
                table: "CandidateProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSocials_SocialPlatforms_SocialPlatformId",
                table: "CandidateSocials");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SocialPlatforms_Name",
                table: "SocialPlatforms");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSocials_CandidateProfileId_SocialPlatformId",
                table: "CandidateSocials");

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("361a0b8e-67e8-476e-9468-f5bcbd8e492e"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("98ead887-e855-41c1-b867-7e69ae9c5ab5"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("e2dabaad-7283-4d14-b44d-38d3cb31a062"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: new Guid("b3f2c0e1-6f2a-4a6c-9f8a-1a2b3c4d5e01"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: new Guid("c4d3f1a2-7b3c-4d8e-9a0b-2c3d4e5f6a02"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("d5e4f3b2-8c4d-4e9f-0a1b-3c4d5e6f7a03"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("e6f5a4c3-9d5e-4f0a-1b2c-4d5e6f7a8b04"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("66e00fb5-2557-443f-9c15-90d33fee0d8e"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("7020c1b2-396f-46ca-8a64-4a36aed17a3c"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("a7fdb57e-835a-4ff8-9109-c974c2731cdd"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("e7b7b31a-faf3-485e-86b5-441190ba01de"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("134303bf-b2be-4473-9706-71d23bfc7f3c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("87f06625-5b80-429e-8c04-7765e231d274"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("bff44ac1-3be4-4925-9497-0f8925a3fa0a"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("21c31304-8287-4ad3-a0bf-23b40d766397"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("23c9aca8-251d-4dbf-872f-133e1634cd23"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("939a6d0b-f7cd-4981-851f-16530fe5fa88"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("d9a179ad-4fc6-46cd-904d-acdd52419a14"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("ecf71c95-f473-49ff-b685-c7ace212a833"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"));

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "CandidateProfileId",
                keyValue: new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("1a3d9590-3f60-4329-ae13-c5310ab2ca8a"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("2125f41d-e523-4766-be99-6546c617fdd3"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("5a82f40e-1871-4827-8a7c-01b6585fa01c"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("70f7a9e4-7ae5-4ba1-9366-42ffef26c401"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("088388ca-b8cf-4d94-90ee-c03562ce71ef"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("60f5ffd1-d4b7-4e72-9647-01b16646b95f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("87733bde-f2e7-40d3-97c4-464f4f27ef66"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: new Guid("927a290b-8499-40ca-8171-ce747bc7bf9c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("02e4be8b-15a9-4011-ae25-f73482ca4e8e"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("854d8de3-c784-4909-8da8-241b396c4010"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("c32c9516-c683-4625-9283-28ea9520580a"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: new Guid("ff70f71b-ffaa-4567-8a7c-7f9958da162f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: new Guid("8aba07c1-6de6-4713-97fc-3f4d648c34fd"));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SocialPlatforms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSocials_CandidateProfileId",
                table: "CandidateSocials",
                column: "CandidateProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateProfiles_Users_UserId",
                table: "CandidateProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSocials_SocialPlatforms_SocialPlatformId",
                table: "CandidateSocials",
                column: "SocialPlatformId",
                principalTable: "SocialPlatforms",
                principalColumn: "SocialPlatformId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
