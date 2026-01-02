using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class seedvaluesupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("7f45299d-ecdc-4712-904b-832e70e6f993"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("b951b92e-4cb4-4b51-978b-5830335f53ea"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("c9264801-9ad6-4a0a-95a0-3cf7a9a23e13"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("388a20c2-15dc-4e8b-ae38-7a2031b02507"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("8d634e54-8b07-48db-acf7-7f8b10607920"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("c6ab91d6-755a-4440-8015-de43993c1c8c"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("d09714b6-5f0c-4682-a38c-9fac543d8f14"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("0a2ab5b9-edb0-4bfa-8e2c-f4f97232c1e4"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("b0b8bbf0-ff47-452d-9e2c-f8153f751155"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("ea3fd983-a5bb-43aa-a0d3-621036d72427"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("59e8a7b2-0529-4de4-a322-663498817ec1"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("711a7ffe-717b-466c-ba10-0b0cd44971f5"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("7c730849-68d0-4e58-a576-c191965a575d"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("bbd3c48c-3a8e-4d4f-896d-bb1db6944c17"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("e18905e3-4906-487d-8586-e3ccbc7028e4"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("001edd6b-70e4-47c5-a429-300ec0ab611d"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("293c1c1d-8e65-4c40-a814-aaeeaa428e61"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("54a7c166-bb73-4ec6-9816-4a6427e73706"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("877ae8f6-2188-4bb7-9b84-5ff322ac2d6c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("395e7296-18ef-4f25-987d-4630871034c9"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("483a3ec0-15fb-45ff-bbab-a070159c49ee"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("e2c5a0d6-de77-4234-861d-656fc07552d1"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("2a3af9ef-37ab-4052-948d-239cf13f4cb0"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("2f523d6f-e078-43c4-ab35-5522dd8f0362"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("c029af51-c008-4cee-a683-7c7b40a960d5"));

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

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "RoleName", "active" },
                values: new object[,]
                {
                    { new Guid("c016dbd1-11c4-444b-8b3e-84095706fc65"), "Reviewer", true },
                    { new Guid("c016dbd1-11c4-444b-8b3e-84095706fc66"), "Interviewer", true }
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
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 33, 30, 313, DateTimeKind.Utc).AddTicks(2772), "AQAAAAIAAYagAAAAEG4gdKYt+Ii3hp62ZdxBM2PkjFsF2ByQPx4yP1e3Q5+XNkheWBcT82tym2hz2H0Bcw==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "DOB", "Email", "Fname", "Gender", "IsActive", "LastLogin", "Lname", "MobileNumber", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"), new DateTime(2026, 1, 2, 3, 33, 30, 598, DateTimeKind.Utc).AddTicks(325), new DateTime(1992, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "reviewer@exp.com", "Bruce", "Male", true, null, "Wayne", "2222222222", "AQAAAAIAAYagAAAAELDa2EROBORw4n9O0FNtB3skom9ehOXPJTzE6GfxncSRoz+Fz8B7BlPl76Lzns7coQ==", null, null, new Guid("66a24f39-2e0a-46fd-81b5-13d6bddb8c5c") },
                    { new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"), new DateTime(2026, 1, 2, 3, 33, 30, 684, DateTimeKind.Utc).AddTicks(9469), new DateTime(1988, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "interviewer@exp.com", "Tony", "Male", true, null, "Stark", "3333333333", "AQAAAAIAAYagAAAAEI1Rq+WU3X73p3SspiU91I3r3ttdjzYxjKPUl4LUip4+aKyiBEU7oJDOm6rbPXkNsQ==", null, null, new Guid("66a24f39-2e0a-46fd-81b5-13d6bddb8c5c") }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: new Guid("c016dbd1-11c4-444b-8b3e-84095706fc65"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: new Guid("c016dbd1-11c4-444b-8b3e-84095706fc66"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"));

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
                    { new Guid("2a3af9ef-37ab-4052-948d-239cf13f4cb0"), "Full-Time" },
                    { new Guid("2f523d6f-e078-43c4-ab35-5522dd8f0362"), "Contract" },
                    { new Guid("c029af51-c008-4cee-a683-7c7b40a960d5"), "Part-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("0a2ab5b9-edb0-4bfa-8e2c-f4f97232c1e4"), true, "JavaScript" },
                    { new Guid("395e7296-18ef-4f25-987d-4630871034c9"), true, "React" },
                    { new Guid("483a3ec0-15fb-45ff-bbab-a070159c49ee"), true, "C#" },
                    { new Guid("b0b8bbf0-ff47-452d-9e2c-f8153f751155"), true, "SQL Server" },
                    { new Guid("e2c5a0d6-de77-4234-861d-656fc07552d1"), true, "ASP.NET Core" },
                    { new Guid("ea3fd983-a5bb-43aa-a0d3-621036d72427"), true, "Entity Framework Core" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("59e8a7b2-0529-4de4-a322-663498817ec1"), "Stack Overflow" },
                    { new Guid("711a7ffe-717b-466c-ba10-0b0cd44971f5"), "Portfolio" },
                    { new Guid("7c730849-68d0-4e58-a576-c191965a575d"), "Twitter" },
                    { new Guid("bbd3c48c-3a8e-4d4f-896d-bb1db6944c17"), "LinkedIn" },
                    { new Guid("e18905e3-4906-487d-8586-e3ccbc7028e4"), "GitHub" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 1, 14, 1, 40, 244, DateTimeKind.Utc).AddTicks(7251), "AQAAAAIAAYagAAAAEEQKx5BqHTmkKXLoTHcILqVS0zQE9pTyIjdilBSj5GT8XMa/h0mqTwDeB9hST8efmw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 1, 14, 1, 40, 115, DateTimeKind.Utc).AddTicks(7761), "AQAAAAIAAYagAAAAEEQDzwKB6ZeFw+c9A3a5ZfnLaSpWU5Xc0b5JKzCtVXXpUR3tPEyd96fBP/5883Rpfg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 1, 14, 1, 40, 3, DateTimeKind.Utc).AddTicks(1036), "AQAAAAIAAYagAAAAECG1iUtwFsCbLpJvieQC4TkFWuL092+iCIjQdr+Ra+yHRKEu07xireejD0lknYJkuw==" });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("7f45299d-ecdc-4712-904b-832e70e6f993"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("e2c5a0d6-de77-4234-861d-656fc07552d1") },
                    { new Guid("b951b92e-4cb4-4b51-978b-5830335f53ea"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("395e7296-18ef-4f25-987d-4630871034c9") },
                    { new Guid("c9264801-9ad6-4a0a-95a0-3cf7a9a23e13"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("483a3ec0-15fb-45ff-bbab-a070159c49ee") }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("001edd6b-70e4-47c5-a429-300ec0ab611d"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("2a3af9ef-37ab-4052-948d-239cf13f4cb0"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("293c1c1d-8e65-4c40-a814-aaeeaa428e61"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("c029af51-c008-4cee-a683-7c7b40a960d5"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("54a7c166-bb73-4ec6-9816-4a6427e73706"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("2f523d6f-e078-43c4-ab35-5522dd8f0362"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" },
                    { new Guid("877ae8f6-2188-4bb7-9b84-5ff322ac2d6c"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("2a3af9ef-37ab-4052-948d-239cf13f4cb0"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("388a20c2-15dc-4e8b-ae38-7a2031b02507"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 29, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(364), new DateTime(2026, 1, 31, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(365), new Guid("293c1c1d-8e65-4c40-a814-aaeeaa428e61"), null, 5 },
                    { new Guid("8d634e54-8b07-48db-acf7-7f8b10607920"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 25, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(350), new DateTime(2026, 1, 24, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(351), new Guid("877ae8f6-2188-4bb7-9b84-5ff322ac2d6c"), null, 2 },
                    { new Guid("c6ab91d6-755a-4440-8015-de43993c1c8c"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 27, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(357), new DateTime(2026, 1, 26, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(358), new Guid("54a7c166-bb73-4ec6-9816-4a6427e73706"), null, 1 },
                    { new Guid("d09714b6-5f0c-4682-a38c-9fac543d8f14"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 22, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 1, 21, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(341), new Guid("001edd6b-70e4-47c5-a429-300ec0ab611d"), null, 3 }
                });
        }
    }
}
