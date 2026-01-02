using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class addingEmployeeRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("40a40e91-403c-4fc0-9373-99ff0d5c6c1f"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("745aa98b-a0e2-489a-a864-9d936cac65d7"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("f206c05a-4779-4cee-9d00-97e6bcff5c74"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("71045a72-6ae1-43d0-89a0-4e0caa53a597"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("e9953f2d-139d-41f8-b129-cb9f173d7e5d"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("eba359ee-950d-46af-b117-5a6143917f97"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("fa4eca5d-37e0-4268-850b-350662bab26a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("169b381d-8113-479e-a41d-f07de569fa6e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("3bf4ad1d-8413-42f1-ac3e-5d9ca2e00dd9"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("c1968109-7636-47e6-a96a-10e2b6911e51"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("2d9ca6f7-e55f-4bbb-8be5-9a52e000312a"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("6e255adb-b956-453d-8c8e-b81102cad253"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("759de695-c58a-446b-8175-28c5f5729124"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("c7ec1c8f-e28e-472c-9ed0-ab23a9fa4715"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("e2525227-9970-4e71-8db2-4d49ca1e4aee"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("6699c80b-7a51-4692-b50c-16868ca92a86"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("69a02b57-75df-44ef-b3bd-3f77930216a2"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("aceb7c4e-bde7-4ed5-826a-9d9818389fad"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("ed89fadb-9f72-49fe-99ed-8a5e8a5204e0"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("6beb5328-3a15-4c0e-8428-fe7caee005f1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("ad62bdd8-534b-46d4-b66e-5bbfdb2abe56"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("d901631b-c3c9-45a3-bff9-9752e28e1ce1"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("367e8c91-bcec-4272-8c51-78fa76ec4338"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("cfc30780-4305-40ad-acd1-85c62402b54f"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("fbf7afb8-b812-4360-b73f-09bb9c046fc3"));

            migrationBuilder.InsertData(
                table: "EmployeeUserRoles",
                columns: new[] { "EmployeeRoleId", "UserId", "AssignedOn" },
                values: new object[,]
                {
                    { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 2, 8, 24, 37, 853, DateTimeKind.Utc).AddTicks(6572) },
                    { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"), new DateTime(2026, 1, 2, 8, 24, 37, 853, DateTimeKind.Utc).AddTicks(6576) },
                    { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"), new DateTime(2026, 1, 2, 8, 24, 37, 853, DateTimeKind.Utc).AddTicks(6578) }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("0d8e85c3-d297-45b2-94e7-8e8ebbce1338"), "Full-Time" },
                    { new Guid("c593ff3f-657b-454f-a02b-804a70ca5002"), "Contract" },
                    { new Guid("edc8b73c-e56b-4c6c-a52d-0f6f3f5a586c"), "Part-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("54295216-d09a-46c6-80ed-70981005796f"), true, "Entity Framework Core" },
                    { new Guid("5df4d929-4e16-4a46-9499-0ac0a111ca9c"), true, "JavaScript" },
                    { new Guid("77003aa0-71e3-4d47-8a66-02fc516d592b"), true, "C#" },
                    { new Guid("9002bf66-d8b6-4fac-a2cb-c4c89154523b"), true, "React" },
                    { new Guid("a96082de-a087-4a07-ad66-41cf21bc0de0"), true, "ASP.NET Core" },
                    { new Guid("af326a08-0a4e-4e3a-a6e8-1af239812c9e"), true, "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("5c7a4aa8-e5ed-412d-80e0-c4d2bd26445a"), "Twitter" },
                    { new Guid("a3d0b0e3-6692-48c1-b8b5-423b647f7dc8"), "LinkedIn" },
                    { new Guid("a417d28d-0897-42a3-9fef-c11d0def3654"), "Stack Overflow" },
                    { new Guid("b23a5f22-078d-4bc2-8127-16f5ae053175"), "Portfolio" },
                    { new Guid("b2f807c9-eec8-457d-b3f1-e13b1deaea87"), "GitHub" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 8, 24, 37, 539, DateTimeKind.Utc).AddTicks(9987), "AQAAAAIAAYagAAAAEK6w0seQIL1LU88y6mm1vSRnNpTBKG6tnrcqaVbU4IRXzfBrQa7kIwTM5hWDgPJHiA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 8, 24, 37, 444, DateTimeKind.Utc).AddTicks(7154), "AQAAAAIAAYagAAAAEHSebqvfSzZ/+bpLUvAtkcX6Fh8Ri8c9TEe8vqNQnfZWGEHHA7d1a3gVOaiGC3nH6A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 8, 24, 37, 634, DateTimeKind.Utc).AddTicks(3761), "AQAAAAIAAYagAAAAEHYsdqc5Effde2HJlGHipPWtOJVubhDFdp3G/H8LyrOp5cDd6+bhVjM6TJ5kOZIQNA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 8, 24, 37, 743, DateTimeKind.Utc).AddTicks(9380), "AQAAAAIAAYagAAAAEB1jA5Bb1K0cPV2aUgVSUWJNvyIuRZp5Z5dGU/QFlflxIBymVd24l+6p2wmMqxBSRg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 8, 24, 37, 334, DateTimeKind.Utc).AddTicks(1782), "AQAAAAIAAYagAAAAEMf6yR+nWq9hI5uRsG0wEYJDMriCWNQD6PJzi2eVAVrF3ePUZt1ukNpx2jimA50rDA==" });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("8eb67b8f-e701-4d3f-bfcc-7077c1af23b1"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("77003aa0-71e3-4d47-8a66-02fc516d592b") },
                    { new Guid("949bee13-a057-4f9c-bb22-8cd1a5443125"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("9002bf66-d8b6-4fac-a2cb-c4c89154523b") },
                    { new Guid("cb8d105a-3830-4100-89a1-19dd06cfa229"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("a96082de-a087-4a07-ad66-41cf21bc0de0") }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("159e6167-921a-4085-b071-05319d37bfe7"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("0d8e85c3-d297-45b2-94e7-8e8ebbce1338"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" },
                    { new Guid("4f607cd7-c8b8-4105-bbbb-c2d82c9513ae"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("c593ff3f-657b-454f-a02b-804a70ca5002"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" },
                    { new Guid("a7c0d174-9f9b-43a5-b8f7-cdf0f778ca85"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("0d8e85c3-d297-45b2-94e7-8e8ebbce1338"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("b6ea2408-190c-47bb-8ee7-6d4f63fcc234"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("edc8b73c-e56b-4c6c-a52d-0f6f3f5a586c"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("299b0df6-51d8-47cc-b294-7e70af97e70a"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 30, 8, 24, 37, 855, DateTimeKind.Utc).AddTicks(8004), new DateTime(2026, 2, 1, 8, 24, 37, 855, DateTimeKind.Utc).AddTicks(8005), new Guid("b6ea2408-190c-47bb-8ee7-6d4f63fcc234"), null, 5 },
                    { new Guid("9b93f7f2-5128-4b8c-a4d5-e589112acb51"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 26, 8, 24, 37, 855, DateTimeKind.Utc).AddTicks(7984), new DateTime(2026, 1, 25, 8, 24, 37, 855, DateTimeKind.Utc).AddTicks(7985), new Guid("159e6167-921a-4085-b071-05319d37bfe7"), null, 2 },
                    { new Guid("d1ddacbd-c46f-49c4-a58b-709f110d01cd"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 28, 8, 24, 37, 855, DateTimeKind.Utc).AddTicks(7989), new DateTime(2026, 1, 27, 8, 24, 37, 855, DateTimeKind.Utc).AddTicks(7989), new Guid("4f607cd7-c8b8-4105-bbbb-c2d82c9513ae"), null, 1 },
                    { new Guid("d8b78db7-22e1-4e05-b737-e6a73475746a"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 23, 8, 24, 37, 855, DateTimeKind.Utc).AddTicks(7969), new DateTime(2026, 1, 22, 8, 24, 37, 855, DateTimeKind.Utc).AddTicks(7977), new Guid("a7c0d174-9f9b-43a5-b8f7-cdf0f778ca85"), null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("8eb67b8f-e701-4d3f-bfcc-7077c1af23b1"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("949bee13-a057-4f9c-bb22-8cd1a5443125"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("cb8d105a-3830-4100-89a1-19dd06cfa229"));

            migrationBuilder.DeleteData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a") });

            migrationBuilder.DeleteData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111") });

            migrationBuilder.DeleteData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222") });

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("299b0df6-51d8-47cc-b294-7e70af97e70a"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("9b93f7f2-5128-4b8c-a4d5-e589112acb51"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("d1ddacbd-c46f-49c4-a58b-709f110d01cd"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("d8b78db7-22e1-4e05-b737-e6a73475746a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("54295216-d09a-46c6-80ed-70981005796f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("5df4d929-4e16-4a46-9499-0ac0a111ca9c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("af326a08-0a4e-4e3a-a6e8-1af239812c9e"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("5c7a4aa8-e5ed-412d-80e0-c4d2bd26445a"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("a3d0b0e3-6692-48c1-b8b5-423b647f7dc8"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("a417d28d-0897-42a3-9fef-c11d0def3654"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("b23a5f22-078d-4bc2-8127-16f5ae053175"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("b2f807c9-eec8-457d-b3f1-e13b1deaea87"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("159e6167-921a-4085-b071-05319d37bfe7"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("4f607cd7-c8b8-4105-bbbb-c2d82c9513ae"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("a7c0d174-9f9b-43a5-b8f7-cdf0f778ca85"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("b6ea2408-190c-47bb-8ee7-6d4f63fcc234"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("77003aa0-71e3-4d47-8a66-02fc516d592b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("9002bf66-d8b6-4fac-a2cb-c4c89154523b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("a96082de-a087-4a07-ad66-41cf21bc0de0"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("0d8e85c3-d297-45b2-94e7-8e8ebbce1338"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("c593ff3f-657b-454f-a02b-804a70ca5002"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("edc8b73c-e56b-4c6c-a52d-0f6f3f5a586c"));

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("367e8c91-bcec-4272-8c51-78fa76ec4338"), "Full-Time" },
                    { new Guid("cfc30780-4305-40ad-acd1-85c62402b54f"), "Contract" },
                    { new Guid("fbf7afb8-b812-4360-b73f-09bb9c046fc3"), "Part-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("169b381d-8113-479e-a41d-f07de569fa6e"), true, "SQL Server" },
                    { new Guid("3bf4ad1d-8413-42f1-ac3e-5d9ca2e00dd9"), true, "Entity Framework Core" },
                    { new Guid("6beb5328-3a15-4c0e-8428-fe7caee005f1"), true, "C#" },
                    { new Guid("ad62bdd8-534b-46d4-b66e-5bbfdb2abe56"), true, "React" },
                    { new Guid("c1968109-7636-47e6-a96a-10e2b6911e51"), true, "JavaScript" },
                    { new Guid("d901631b-c3c9-45a3-bff9-9752e28e1ce1"), true, "ASP.NET Core" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("2d9ca6f7-e55f-4bbb-8be5-9a52e000312a"), "LinkedIn" },
                    { new Guid("6e255adb-b956-453d-8c8e-b81102cad253"), "Stack Overflow" },
                    { new Guid("759de695-c58a-446b-8175-28c5f5729124"), "GitHub" },
                    { new Guid("c7ec1c8f-e28e-472c-9ed0-ab23a9fa4715"), "Portfolio" },
                    { new Guid("e2525227-9970-4e71-8db2-4d49ca1e4aee"), "Twitter" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 21, 47, 480, DateTimeKind.Utc).AddTicks(394), "AQAAAAIAAYagAAAAEJsPxTHncuSwFdCiZHlGllxK/RrS1t/yzc/tKQyg3vKybATUUDMOwY9sfslUEnAcrQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 21, 47, 393, DateTimeKind.Utc).AddTicks(7256), "AQAAAAIAAYagAAAAEDPQo1NQSvvJd0/Et3by0Um+Ki9GeC4NmXnKye5ocRlx9K42zfKnyXbJ7GcFIffmmg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 21, 47, 584, DateTimeKind.Utc).AddTicks(7273), "AQAAAAIAAYagAAAAEIP/1/EYDXbIZ6dgZsT2CmBn1A0iadiCMoqShTUF7NK75WbXH0hMNBrTgEv9LHcS5w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 21, 47, 674, DateTimeKind.Utc).AddTicks(7793), "AQAAAAIAAYagAAAAEDUpjB+UYzC9RydX5QyNhuXMVocnlqYPI3RuIX+yEkZG5Y4Cn8geuXBpG5A/brnaSg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 21, 47, 303, DateTimeKind.Utc).AddTicks(7949), "AQAAAAIAAYagAAAAEIvQdMWD/k37K1jtKEhizs7eez4po8FeKfI/t5e8f1xHpEiytqBeb35ZOoi+0gDrOw==" });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("40a40e91-403c-4fc0-9373-99ff0d5c6c1f"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("d901631b-c3c9-45a3-bff9-9752e28e1ce1") },
                    { new Guid("745aa98b-a0e2-489a-a864-9d936cac65d7"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("6beb5328-3a15-4c0e-8428-fe7caee005f1") },
                    { new Guid("f206c05a-4779-4cee-9d00-97e6bcff5c74"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("ad62bdd8-534b-46d4-b66e-5bbfdb2abe56") }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("6699c80b-7a51-4692-b50c-16868ca92a86"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("cfc30780-4305-40ad-acd1-85c62402b54f"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" },
                    { new Guid("69a02b57-75df-44ef-b3bd-3f77930216a2"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("fbf7afb8-b812-4360-b73f-09bb9c046fc3"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("aceb7c4e-bde7-4ed5-826a-9d9818389fad"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("367e8c91-bcec-4272-8c51-78fa76ec4338"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" },
                    { new Guid("ed89fadb-9f72-49fe-99ed-8a5e8a5204e0"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("367e8c91-bcec-4272-8c51-78fa76ec4338"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("71045a72-6ae1-43d0-89a0-4e0caa53a597"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 30, 7, 21, 47, 774, DateTimeKind.Utc).AddTicks(2892), new DateTime(2026, 2, 1, 7, 21, 47, 774, DateTimeKind.Utc).AddTicks(2893), new Guid("69a02b57-75df-44ef-b3bd-3f77930216a2"), null, 5 },
                    { new Guid("e9953f2d-139d-41f8-b129-cb9f173d7e5d"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 26, 7, 21, 47, 774, DateTimeKind.Utc).AddTicks(2869), new DateTime(2026, 1, 25, 7, 21, 47, 774, DateTimeKind.Utc).AddTicks(2870), new Guid("aceb7c4e-bde7-4ed5-826a-9d9818389fad"), null, 2 },
                    { new Guid("eba359ee-950d-46af-b117-5a6143917f97"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 28, 7, 21, 47, 774, DateTimeKind.Utc).AddTicks(2879), new DateTime(2026, 1, 27, 7, 21, 47, 774, DateTimeKind.Utc).AddTicks(2880), new Guid("6699c80b-7a51-4692-b50c-16868ca92a86"), null, 1 },
                    { new Guid("fa4eca5d-37e0-4268-850b-350662bab26a"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 23, 7, 21, 47, 774, DateTimeKind.Utc).AddTicks(2855), new DateTime(2026, 1, 22, 7, 21, 47, 774, DateTimeKind.Utc).AddTicks(2865), new Guid("ed89fadb-9f72-49fe-99ed-8a5e8a5204e0"), null, 3 }
                });
        }
    }
}
