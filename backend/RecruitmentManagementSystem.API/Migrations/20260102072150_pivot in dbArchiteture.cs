using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class pivotindbArchiteture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");

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

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                table: "Users",
                newName: "UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                newName: "IX_Users_UserTypeId");

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.EmployeeRoleId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUserRoles", x => new { x.UserId, x.EmployeeRoleId });
                    table.ForeignKey(
                        name: "FK_EmployeeUserRoles_EmployeeRoles_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "EmployeeRoles",
                        principalColumn: "EmployeeRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeRoleId", "IsActive", "RoleName" },
                values: new object[,]
                {
                    { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), true, "Interviewer" },
                    { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), true, "Reviewer" },
                    { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), true, "Recruiter" }
                });

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

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "TypeName", "active" },
                values: new object[,]
                {
                    { new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e"), "Employee", true },
                    { new Guid("e91d74b9-67cb-41b5-9581-338a64a45122"), "Candidate", true }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash", "UserTypeId" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 21, 47, 480, DateTimeKind.Utc).AddTicks(394), "AQAAAAIAAYagAAAAEJsPxTHncuSwFdCiZHlGllxK/RrS1t/yzc/tKQyg3vKybATUUDMOwY9sfslUEnAcrQ==", new Guid("e91d74b9-67cb-41b5-9581-338a64a45122") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash", "UserTypeId" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 21, 47, 393, DateTimeKind.Utc).AddTicks(7256), "AQAAAAIAAYagAAAAEDPQo1NQSvvJd0/Et3by0Um+Ki9GeC4NmXnKye5ocRlx9K42zfKnyXbJ7GcFIffmmg==", new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"),
                columns: new[] { "CreatedDate", "PasswordHash", "UserTypeId" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 21, 47, 584, DateTimeKind.Utc).AddTicks(7273), "AQAAAAIAAYagAAAAEIP/1/EYDXbIZ6dgZsT2CmBn1A0iadiCMoqShTUF7NK75WbXH0hMNBrTgEv9LHcS5w==", new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"),
                columns: new[] { "CreatedDate", "PasswordHash", "UserTypeId" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 21, 47, 674, DateTimeKind.Utc).AddTicks(7793), "AQAAAAIAAYagAAAAEDUpjB+UYzC9RydX5QyNhuXMVocnlqYPI3RuIX+yEkZG5Y4Cn8geuXBpG5A/brnaSg==", new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash", "UserTypeId" },
                values: new object[] { new DateTime(2026, 1, 2, 7, 21, 47, 303, DateTimeKind.Utc).AddTicks(7949), "AQAAAAIAAYagAAAAEIvQdMWD/k37K1jtKEhizs7eez4po8FeKfI/t5e8f1xHpEiytqBeb35ZOoi+0gDrOw==", new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") });

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

            migrationBuilder.CreateIndex(
                name: "IX_AssignedReviewers_JobApplicationId",
                table: "AssignedReviewers",
                column: "JobApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeUserRoles_EmployeeRoleId",
                table: "EmployeeUserRoles",
                column: "EmployeeRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedReviewers_JobApplications_JobApplicationId",
                table: "AssignedReviewers",
                column: "JobApplicationId",
                principalTable: "JobApplications",
                principalColumn: "JobApplicationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedReviewers_JobApplications_JobApplicationId",
                table: "AssignedReviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "EmployeeUserRoles");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropIndex(
                name: "IX_AssignedReviewers_JobApplicationId",
                table: "AssignedReviewers");

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

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "Users",
                newName: "UserRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                newName: "IX_Users_UserRoleId");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

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

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "RoleName", "active" },
                values: new object[,]
                {
                    { new Guid("66a24f39-2e0a-46fd-81b5-13d6bddb8c5c"), "Recruiter", true },
                    { new Guid("b57751e8-24af-473b-a7aa-ff30ddfc0d49"), "Admin", true },
                    { new Guid("c016dbd1-11c4-444b-8b3e-84095706fc60"), "Candidate", true },
                    { new Guid("c016dbd1-11c4-444b-8b3e-84095706fc65"), "Reviewer", true },
                    { new Guid("c016dbd1-11c4-444b-8b3e-84095706fc66"), "Interviewer", true }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash", "UserRoleId" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 57, 35, 687, DateTimeKind.Utc).AddTicks(6984), "AQAAAAIAAYagAAAAEJyqSfh/qiaK3SOjWo4EeDcp42sTBoXJLZS1zepxEKSsdTab0rkie+uGK4jUuA607A==", new Guid("c016dbd1-11c4-444b-8b3e-84095706fc60") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash", "UserRoleId" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 57, 35, 601, DateTimeKind.Utc).AddTicks(4515), "AQAAAAIAAYagAAAAEKDWS/RYgNcxg5zLcfAYCcPW8OcspLiZfFK5VcPMp3tPP3cC3oC7r3Uh4BxieqhyCg==", new Guid("66a24f39-2e0a-46fd-81b5-13d6bddb8c5c") });

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
                columns: new[] { "CreatedDate", "PasswordHash", "UserRoleId" },
                values: new object[] { new DateTime(2026, 1, 2, 3, 57, 35, 520, DateTimeKind.Utc).AddTicks(459), "AQAAAAIAAYagAAAAEGDD5Rtx+Jq76jogG0wmXTv/CZH3DnxhGCwXmq0NZHptcRWw76SAGFbpk87TZ9ns/A==", new Guid("b57751e8-24af-473b-a7aa-ff30ddfc0d49") });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
