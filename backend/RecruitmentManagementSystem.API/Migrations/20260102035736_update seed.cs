using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class updateseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("3bfc928e-4947-4f76-8563-ea0f189038b8"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("7be3a82e-ba12-488d-b54e-0bfd44462e6a"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("9f772b92-102c-44e0-9106-7c5424a68ab6"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("7d84eaf8-69c6-4834-814d-da00526742cf"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("8c4370c4-612f-4143-a80f-f55b3176bd21"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("efc5a077-41c2-4cb4-a9df-c83adddcb488"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("f9bc1306-c54b-42ce-b72f-6589655b4556"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("282aeaef-8e8b-41ca-aee4-cbaaa760de5d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("468d121d-314b-427b-9f3c-f9be7598fc5c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("a543770d-8a86-4d1b-8cbc-01ae2227230f"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("3a0d087a-7308-48e8-bf90-4eb226d67ab3"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("4640f1a9-412f-46e0-aeef-75fe2142cca5"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("68524b1c-e5e0-4443-86f5-b7963d7a45e1"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("74da672e-cc55-481a-ba9c-594020ea8ace"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("e3f8f659-f131-4e3b-a0a5-4b4beeccc04e"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("017a4e72-10e4-464f-8d35-b83603836326"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("11f94ccb-3d1d-4797-981d-8d97db99e403"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("36003a3a-1a51-40a7-b859-7a612d8ac7e6"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("3fbef0ed-3bb8-4031-8f2b-b2b14c9dc9b5"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("114c4704-7d5d-4ac6-be24-e1def51fd8d3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("3bc7d00a-43c6-4097-854e-89361c81004f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("595a4d11-9349-4724-b8cd-fd1b68b67832"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("c469e906-4ad1-4bdd-a69f-0eb24a1f53a0"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("c9d1f89b-4321-47af-b184-6b6393eba208"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("d8005cf4-b5d9-4a6c-989f-ff8bbdafa686"));

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("5422a1a8-2976-48d5-8560-852a08b889bc"), "Full-Time" },
                    { new Guid("6d988fd0-889a-4275-b538-45772d7b408f"), "Contract" },
                    { new Guid("c0f276b1-d13a-4597-aa13-77ec5e3491eb"), "Part-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("54b1a3ea-3a84-4da7-9e80-cb934fa2351b"), true, "ASP.NET Core" },
                    { new Guid("6f555963-a040-413f-8fdd-13383f9d825b"), true, "JavaScript" },
                    { new Guid("b230e5bb-59ac-4a6b-8702-452e5eb35ae0"), true, "Entity Framework Core" },
                    { new Guid("eb278ba1-7b80-40c2-a489-23bb68c1b7c5"), true, "React" },
                    { new Guid("eb69f6c7-1999-4eee-a389-7cdf63bcee4b"), true, "C#" },
                    { new Guid("f51dae79-5edd-429b-af6c-c9a27ae94720"), true, "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("13e110fc-90f8-49f7-afc2-48141833c75b"), "GitHub" },
                    { new Guid("26b9f6f5-d041-435e-99d5-a3483e9394bd"), "Twitter" },
                    { new Guid("36916ed0-575c-4ef3-aa79-a3058e932276"), "LinkedIn" },
                    { new Guid("92dce8fc-8c0b-4a78-b7c4-6bca3bb8fed9"), "Portfolio" },
                    { new Guid("c980b092-79e9-42b0-a1e7-7ca39b446af9"), "Stack Overflow" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 57, 35, 687, DateTimeKind.Utc).AddTicks(6984), "AQAAAAIAAYagAAAAEJyqSfh/qiaK3SOjWo4EeDcp42sTBoXJLZS1zepxEKSsdTab0rkie+uGK4jUuA607A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 57, 35, 601, DateTimeKind.Utc).AddTicks(4515), "AQAAAAIAAYagAAAAEKDWS/RYgNcxg5zLcfAYCcPW8OcspLiZfFK5VcPMp3tPP3cC3oC7r3Uh4BxieqhyCg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"),
                columns: new[] { "CreatedDate", "PasswordHash", "UserRoleId" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 57, 35, 777, DateTimeKind.Utc).AddTicks(6122), "AQAAAAIAAYagAAAAEAZYAEtcKg9B/pDgeH18KgwgeefFsDLrlRxIrgTiIOGH4l19PHtlsSZeX8TjxBUjiw==", new Guid("c016dbd1-11c4-444b-8b3e-84095706fc65") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"),
                columns: new[] { "CreatedDate", "PasswordHash", "UserRoleId" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 57, 35, 873, DateTimeKind.Utc).AddTicks(145), "AQAAAAIAAYagAAAAEKYd7dMPaVajKGpzd1c6E9Xu0KN5hIB9pLZElx4IIVaYrGnuK7Lho6MUj2d+Y9y2Cw==", new Guid("c016dbd1-11c4-444b-8b3e-84095706fc66") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 57, 35, 520, DateTimeKind.Utc).AddTicks(459), "AQAAAAIAAYagAAAAEGDD5Rtx+Jq76jogG0wmXTv/CZH3DnxhGCwXmq0NZHptcRWw76SAGFbpk87TZ9ns/A==" });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("0c1164cb-1249-4d08-bb6e-f4b5f7d3b473"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("54b1a3ea-3a84-4da7-9e80-cb934fa2351b") },
                    { new Guid("91785c95-2478-461a-9fee-224f74e55097"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("eb278ba1-7b80-40c2-a489-23bb68c1b7c5") },
                    { new Guid("c76ef1f7-97cb-4498-8f93-f5f360dbe58d"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("eb69f6c7-1999-4eee-a389-7cdf63bcee4b") }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("198cad1e-709f-48b5-a91e-952f9e27370c"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("c0f276b1-d13a-4597-aa13-77ec5e3491eb"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("40c80f60-a85e-440f-8864-408d8413e11f"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("6d988fd0-889a-4275-b538-45772d7b408f"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" },
                    { new Guid("6fc101eb-ffa3-4d3b-8d6c-f693df819c47"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("5422a1a8-2976-48d5-8560-852a08b889bc"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("d542b0e8-54b9-4e34-9531-2b3f478058ae"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("5422a1a8-2976-48d5-8560-852a08b889bc"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("38c7f97d-a42c-45d3-8e4f-e732ff5d8843"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 30, 3, 57, 35, 966, DateTimeKind.Utc).AddTicks(5799), new DateTime(2026, 2, 1, 3, 57, 35, 966, DateTimeKind.Utc).AddTicks(5800), new Guid("198cad1e-709f-48b5-a91e-952f9e27370c"), null, 5 },
                    { new Guid("649b2847-c705-4f31-8ee0-497d1da8eb6c"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 23, 3, 57, 35, 966, DateTimeKind.Utc).AddTicks(5775), new DateTime(2026, 1, 22, 3, 57, 35, 966, DateTimeKind.Utc).AddTicks(5783), new Guid("6fc101eb-ffa3-4d3b-8d6c-f693df819c47"), null, 3 },
                    { new Guid("71d7f80f-f3ce-45ce-9e8a-65d50559b115"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 26, 3, 57, 35, 966, DateTimeKind.Utc).AddTicks(5786), new DateTime(2026, 1, 25, 3, 57, 35, 966, DateTimeKind.Utc).AddTicks(5787), new Guid("d542b0e8-54b9-4e34-9531-2b3f478058ae"), null, 2 },
                    { new Guid("87aee47a-c2e8-4b13-aff1-b6bcbd88ca05"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 28, 3, 57, 35, 966, DateTimeKind.Utc).AddTicks(5790), new DateTime(2026, 1, 27, 3, 57, 35, 966, DateTimeKind.Utc).AddTicks(5790), new Guid("40c80f60-a85e-440f-8864-408d8413e11f"), null, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("0c1164cb-1249-4d08-bb6e-f4b5f7d3b473"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("91785c95-2478-461a-9fee-224f74e55097"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("c76ef1f7-97cb-4498-8f93-f5f360dbe58d"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("38c7f97d-a42c-45d3-8e4f-e732ff5d8843"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("649b2847-c705-4f31-8ee0-497d1da8eb6c"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("71d7f80f-f3ce-45ce-9e8a-65d50559b115"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("87aee47a-c2e8-4b13-aff1-b6bcbd88ca05"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("6f555963-a040-413f-8fdd-13383f9d825b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("b230e5bb-59ac-4a6b-8702-452e5eb35ae0"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("f51dae79-5edd-429b-af6c-c9a27ae94720"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("13e110fc-90f8-49f7-afc2-48141833c75b"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("26b9f6f5-d041-435e-99d5-a3483e9394bd"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("36916ed0-575c-4ef3-aa79-a3058e932276"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("92dce8fc-8c0b-4a78-b7c4-6bca3bb8fed9"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("c980b092-79e9-42b0-a1e7-7ca39b446af9"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("198cad1e-709f-48b5-a91e-952f9e27370c"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("40c80f60-a85e-440f-8864-408d8413e11f"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("6fc101eb-ffa3-4d3b-8d6c-f693df819c47"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("d542b0e8-54b9-4e34-9531-2b3f478058ae"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("54b1a3ea-3a84-4da7-9e80-cb934fa2351b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("eb278ba1-7b80-40c2-a489-23bb68c1b7c5"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("eb69f6c7-1999-4eee-a389-7cdf63bcee4b"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("5422a1a8-2976-48d5-8560-852a08b889bc"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("6d988fd0-889a-4275-b538-45772d7b408f"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("c0f276b1-d13a-4597-aa13-77ec5e3491eb"));

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("c469e906-4ad1-4bdd-a69f-0eb24a1f53a0"), "Contract" },
                    { new Guid("c9d1f89b-4321-47af-b184-6b6393eba208"), "Part-Time" },
                    { new Guid("d8005cf4-b5d9-4a6c-989f-ff8bbdafa686"), "Full-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("114c4704-7d5d-4ac6-be24-e1def51fd8d3"), true, "React" },
                    { new Guid("282aeaef-8e8b-41ca-aee4-cbaaa760de5d"), true, "SQL Server" },
                    { new Guid("3bc7d00a-43c6-4097-854e-89361c81004f"), true, "ASP.NET Core" },
                    { new Guid("468d121d-314b-427b-9f3c-f9be7598fc5c"), true, "JavaScript" },
                    { new Guid("595a4d11-9349-4724-b8cd-fd1b68b67832"), true, "C#" },
                    { new Guid("a543770d-8a86-4d1b-8cbc-01ae2227230f"), true, "Entity Framework Core" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("3a0d087a-7308-48e8-bf90-4eb226d67ab3"), "GitHub" },
                    { new Guid("4640f1a9-412f-46e0-aeef-75fe2142cca5"), "Portfolio" },
                    { new Guid("68524b1c-e5e0-4443-86f5-b7963d7a45e1"), "Twitter" },
                    { new Guid("74da672e-cc55-481a-ba9c-594020ea8ace"), "LinkedIn" },
                    { new Guid("e3f8f659-f131-4e3b-a0a5-4b4beeccc04e"), "Stack Overflow" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 33, 30, 494, DateTimeKind.Utc).AddTicks(6978), "AQAAAAIAAYagAAAAEG+zfgF+DagewdKkFhESwUn9bCW7nc5LNx6FNqNiV0Ax+9rcVWcgezjlt9/wADuddg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 33, 30, 396, DateTimeKind.Utc).AddTicks(8191), "AQAAAAIAAYagAAAAEDVsPTlb66IklRntnUDKz5G+oMuZ4zOiyXwdD1RQNEfKWMTKggSmXFAi/oCF4su7eg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"),
                columns: new[] { "CreatedDate", "PasswordHash", "UserRoleId" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 33, 30, 598, DateTimeKind.Utc).AddTicks(325), "AQAAAAIAAYagAAAAELDa2EROBORw4n9O0FNtB3skom9ehOXPJTzE6GfxncSRoz+Fz8B7BlPl76Lzns7coQ==", new Guid("66a24f39-2e0a-46fd-81b5-13d6bddb8c5c") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"),
                columns: new[] { "CreatedDate", "PasswordHash", "UserRoleId" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 33, 30, 684, DateTimeKind.Utc).AddTicks(9469), "AQAAAAIAAYagAAAAEI1Rq+WU3X73p3SspiU91I3r3ttdjzYxjKPUl4LUip4+aKyiBEU7oJDOm6rbPXkNsQ==", new Guid("66a24f39-2e0a-46fd-81b5-13d6bddb8c5c") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 33, 30, 313, DateTimeKind.Utc).AddTicks(2772), "AQAAAAIAAYagAAAAEG4gdKYt+Ii3hp62ZdxBM2PkjFsF2ByQPx4yP1e3Q5+XNkheWBcT82tym2hz2H0Bcw==" });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("3bfc928e-4947-4f76-8563-ea0f189038b8"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("3bc7d00a-43c6-4097-854e-89361c81004f") },
                    { new Guid("7be3a82e-ba12-488d-b54e-0bfd44462e6a"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("114c4704-7d5d-4ac6-be24-e1def51fd8d3") },
                    { new Guid("9f772b92-102c-44e0-9106-7c5424a68ab6"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("595a4d11-9349-4724-b8cd-fd1b68b67832") }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("017a4e72-10e4-464f-8d35-b83603836326"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("d8005cf4-b5d9-4a6c-989f-ff8bbdafa686"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" },
                    { new Guid("11f94ccb-3d1d-4797-981d-8d97db99e403"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("c9d1f89b-4321-47af-b184-6b6393eba208"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("36003a3a-1a51-40a7-b859-7a612d8ac7e6"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("d8005cf4-b5d9-4a6c-989f-ff8bbdafa686"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("3fbef0ed-3bb8-4031-8f2b-b2b14c9dc9b5"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("c469e906-4ad1-4bdd-a69f-0eb24a1f53a0"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("7d84eaf8-69c6-4834-814d-da00526742cf"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 23, 3, 33, 30, 778, DateTimeKind.Utc).AddTicks(8598), new DateTime(2026, 1, 22, 3, 33, 30, 778, DateTimeKind.Utc).AddTicks(8605), new Guid("36003a3a-1a51-40a7-b859-7a612d8ac7e6"), null, 3 },
                    { new Guid("8c4370c4-612f-4143-a80f-f55b3176bd21"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 30, 3, 33, 30, 778, DateTimeKind.Utc).AddTicks(8621), new DateTime(2026, 2, 1, 3, 33, 30, 778, DateTimeKind.Utc).AddTicks(8622), new Guid("11f94ccb-3d1d-4797-981d-8d97db99e403"), null, 5 },
                    { new Guid("efc5a077-41c2-4cb4-a9df-c83adddcb488"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 26, 3, 33, 30, 778, DateTimeKind.Utc).AddTicks(8609), new DateTime(2026, 1, 25, 3, 33, 30, 778, DateTimeKind.Utc).AddTicks(8610), new Guid("017a4e72-10e4-464f-8d35-b83603836326"), null, 2 },
                    { new Guid("f9bc1306-c54b-42ce-b72f-6589655b4556"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 28, 3, 33, 30, 778, DateTimeKind.Utc).AddTicks(8614), new DateTime(2026, 1, 27, 3, 33, 30, 778, DateTimeKind.Utc).AddTicks(8615), new Guid("3fbef0ed-3bb8-4031-8f2b-b2b14c9dc9b5"), null, 1 }
                });
        }
    }
}
