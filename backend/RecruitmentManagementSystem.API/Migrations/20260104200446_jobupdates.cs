using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class jobupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVReviewStages_JobApplications_JobApplicationId",
                table: "CVReviewStages");

            migrationBuilder.DropForeignKey(
                name: "FK_CVReviewStages_Users_ReviewedByUid",
                table: "CVReviewStages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CVReviewStages",
                table: "CVReviewStages");

            migrationBuilder.DropIndex(
                name: "IX_CVReviewStages_ReviewedByUid",
                table: "CVReviewStages");

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("7716193f-2188-4524-a1d5-b70e4a72f875"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("94030797-f5af-41cc-a13b-110cafe4c556"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("97f1dc14-2aa0-4b07-a469-d8fbe64832d5"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("3cc51923-b38a-4eda-8523-6577d2b63e54"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("3fc609ee-2ad3-4023-9d1f-8f22f17142b3"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("41796f1f-bcdf-4127-ab13-8283e744f0b0"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("e481d97e-7cba-4200-9e04-79edf2916c71"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("21def8c2-dd58-478a-8271-018ec1fe40d7"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("584982bb-daa0-4e75-9e87-6901649b95d5"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("5856875e-78fb-4efd-86c0-24e8857972e0"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("468a9d7a-8cbc-4d25-828e-f01121c743d8"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("6459d3b0-2e54-4357-ab5a-c89c2819b733"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("84f68276-1a61-46ab-826e-ae3ca5261904"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("8c4df48a-e952-4dee-a238-7a8a0b31b2da"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("d338060a-30cc-4275-b80f-88d427fa32a9"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("09f9f319-b455-4f2c-8bff-433f885f9f14"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("2a778506-fc46-41e3-be10-f77e1cfab8d3"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("50b43ef2-d999-49e7-b025-4b6ae1971067"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("d95bf6ed-1ac2-41be-b483-f32a09c02d6f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("77aaadce-bb82-4718-a20a-5fc5a20499ee"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("9cc814bf-6240-4f3b-bd07-0920f765da90"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("9ea15407-71d6-4911-8675-6cc4aafc8235"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("64018c1a-a5e7-4b5b-9189-1d893c40d658"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("65ed2e33-e49c-48ad-8df5-9140922f2aff"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("7c14f709-c074-4485-95b9-9518cec5f63e"));

            migrationBuilder.DropColumn(
                name: "CVReviewStageSid",
                table: "CVReviewStages");

            migrationBuilder.RenameColumn(
                name: "ReviewedByUid",
                table: "CVReviewStages",
                newName: "CVReviewStageId");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobApplicationId",
                table: "CVReviewStages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssignedReviewersId",
                table: "CVReviewStages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExperienceYears",
                table: "ApplicationSkills",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CVReviewStages",
                table: "CVReviewStages",
                column: "CVReviewStageId");

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 4, 20, 4, 45, 385, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 4, 20, 4, 45, 385, DateTimeKind.Utc).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 4, 20, 4, 45, 385, DateTimeKind.Utc).AddTicks(9525));

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("6e92f9bf-14ca-452d-90e9-89fe1b97d699"), "Part-Time" },
                    { new Guid("b5b7e11a-1bd9-4b9b-ab18-7203d85cfb52"), "Full-Time" },
                    { new Guid("c1298f9b-36be-466d-8fbe-2169c0e10da2"), "Contract" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("2976bbe9-235c-45bf-9e00-9e3d717e4602"), true, "JavaScript" },
                    { new Guid("4222f2c2-53f8-4c94-be5d-ebcbe47d826c"), true, "React" },
                    { new Guid("50829d6c-a2a3-4e6f-b4df-22a7b71799b6"), true, "Entity Framework Core" },
                    { new Guid("596244f0-5a36-4995-bb57-00bcd5c05613"), true, "SQL Server" },
                    { new Guid("786cc2d5-b8e2-47f9-b70a-c55f6a6cc9fc"), true, "C#" },
                    { new Guid("da232863-f64e-4a78-ad40-eff3ba8909b8"), true, "ASP.NET Core" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("d515fbf5-4ac7-45f5-8d33-9372aee9539b"), "LinkedIn" },
                    { new Guid("e3f5028c-b76c-49dd-962e-2e309d3d055a"), "Stack Overflow" },
                    { new Guid("ec34f9bb-2a17-46b5-a10a-c203fb9e330a"), "Twitter" },
                    { new Guid("f33509de-55d1-4b19-af42-7e8ac2c6b685"), "Portfolio" },
                    { new Guid("f6089223-5d91-43aa-9d03-dcb081753454"), "GitHub" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 20, 4, 45, 90, DateTimeKind.Utc).AddTicks(676), "AQAAAAIAAYagAAAAEAf4iWLRV6LNDi7ZYCQNEiatqIb7T9Kn/8qPsNktGcMuTsA1osUvlBgcZoUDsrnEcQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 20, 4, 44, 989, DateTimeKind.Utc).AddTicks(9977), "AQAAAAIAAYagAAAAEEfSHlc25dMoWBFp4RX+qaeTWS25k55zIOozQ+KbHnBvP0aB8Kvp0/AejPtDgv+86w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 20, 4, 45, 187, DateTimeKind.Utc).AddTicks(821), "AQAAAAIAAYagAAAAEJmLH10rgjCwth4KCuySEDJtrMmFEo2vCn78IYAY9gYmEE5oyxW3Dhs7PWnDi4dXqg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 20, 4, 45, 287, DateTimeKind.Utc).AddTicks(4844), "AQAAAAIAAYagAAAAEGCpZV8Zu+sc3lPVdfE+cQ8l32LtzXHCYNykdBX+pr7n6RqeJGdRY8CZiLxeUWN+3w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 20, 4, 44, 892, DateTimeKind.Utc).AddTicks(9819), "AQAAAAIAAYagAAAAECqTyoYP39AXWBRDebQXx4t3mZJ+lutvFE8GCpjw9tQGF1nekBdI05blrkaK1kggJw==" });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("9e66ad93-bd3e-4e5d-bc9f-83162467498e"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("786cc2d5-b8e2-47f9-b70a-c55f6a6cc9fc") },
                    { new Guid("b1aaf75c-8c4d-4c90-8cfe-1513d3dcf87f"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("da232863-f64e-4a78-ad40-eff3ba8909b8") },
                    { new Guid("deb68cc9-7cee-4b75-8056-0e9495f8c8e3"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("4222f2c2-53f8-4c94-be5d-ebcbe47d826c") }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("20e3be65-b67a-4132-8c4f-df163598c9a1"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("b5b7e11a-1bd9-4b9b-ab18-7203d85cfb52"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" },
                    { new Guid("21810b29-0883-441e-a6d7-1d8edc6c3f9b"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("b5b7e11a-1bd9-4b9b-ab18-7203d85cfb52"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("72a71874-3f8d-404a-8dc8-f711898f8524"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("6e92f9bf-14ca-452d-90e9-89fe1b97d699"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("bf7f4a0e-e51d-49b9-9533-275a2b31c52a"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("c1298f9b-36be-466d-8fbe-2169c0e10da2"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("4cd2bc95-ab61-4a0d-b84e-a0c2146d5c28"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 28, 20, 4, 45, 387, DateTimeKind.Utc).AddTicks(5654), new DateTime(2026, 1, 27, 20, 4, 45, 387, DateTimeKind.Utc).AddTicks(5655), new Guid("20e3be65-b67a-4132-8c4f-df163598c9a1"), null, 2 },
                    { new Guid("7423ad81-3e27-40eb-8ca0-7b31ffbb3061"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 1, 20, 4, 45, 387, DateTimeKind.Utc).AddTicks(5676), new DateTime(2026, 2, 3, 20, 4, 45, 387, DateTimeKind.Utc).AddTicks(5677), new Guid("72a71874-3f8d-404a-8dc8-f711898f8524"), null, 5 },
                    { new Guid("a77841be-9b65-44c2-8ae0-2ce8004429dd"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 25, 20, 4, 45, 387, DateTimeKind.Utc).AddTicks(5641), new DateTime(2026, 1, 24, 20, 4, 45, 387, DateTimeKind.Utc).AddTicks(5649), new Guid("21810b29-0883-441e-a6d7-1d8edc6c3f9b"), null, 3 },
                    { new Guid("a8aa2e5f-cde3-42d5-8309-f19a33a6f36d"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 30, 20, 4, 45, 387, DateTimeKind.Utc).AddTicks(5672), new DateTime(2026, 1, 29, 20, 4, 45, 387, DateTimeKind.Utc).AddTicks(5673), new Guid("bf7f4a0e-e51d-49b9-9533-275a2b31c52a"), null, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CVReviewStages_JobApplications_JobApplicationId",
                table: "CVReviewStages",
                column: "JobApplicationId",
                principalTable: "JobApplications",
                principalColumn: "JobApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVReviewStages_JobApplications_JobApplicationId",
                table: "CVReviewStages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CVReviewStages",
                table: "CVReviewStages");

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("9e66ad93-bd3e-4e5d-bc9f-83162467498e"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("b1aaf75c-8c4d-4c90-8cfe-1513d3dcf87f"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("deb68cc9-7cee-4b75-8056-0e9495f8c8e3"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("4cd2bc95-ab61-4a0d-b84e-a0c2146d5c28"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("7423ad81-3e27-40eb-8ca0-7b31ffbb3061"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("a77841be-9b65-44c2-8ae0-2ce8004429dd"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("a8aa2e5f-cde3-42d5-8309-f19a33a6f36d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("2976bbe9-235c-45bf-9e00-9e3d717e4602"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("50829d6c-a2a3-4e6f-b4df-22a7b71799b6"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("596244f0-5a36-4995-bb57-00bcd5c05613"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("d515fbf5-4ac7-45f5-8d33-9372aee9539b"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("e3f5028c-b76c-49dd-962e-2e309d3d055a"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("ec34f9bb-2a17-46b5-a10a-c203fb9e330a"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("f33509de-55d1-4b19-af42-7e8ac2c6b685"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("f6089223-5d91-43aa-9d03-dcb081753454"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("20e3be65-b67a-4132-8c4f-df163598c9a1"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("21810b29-0883-441e-a6d7-1d8edc6c3f9b"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("72a71874-3f8d-404a-8dc8-f711898f8524"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("bf7f4a0e-e51d-49b9-9533-275a2b31c52a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("4222f2c2-53f8-4c94-be5d-ebcbe47d826c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("786cc2d5-b8e2-47f9-b70a-c55f6a6cc9fc"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("da232863-f64e-4a78-ad40-eff3ba8909b8"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("6e92f9bf-14ca-452d-90e9-89fe1b97d699"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("b5b7e11a-1bd9-4b9b-ab18-7203d85cfb52"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("c1298f9b-36be-466d-8fbe-2169c0e10da2"));

            migrationBuilder.DropColumn(
                name: "ExperienceYears",
                table: "ApplicationSkills");

            migrationBuilder.RenameColumn(
                name: "CVReviewStageId",
                table: "CVReviewStages",
                newName: "ReviewedByUid");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobApplicationId",
                table: "CVReviewStages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AssignedReviewersId",
                table: "CVReviewStages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CVReviewStageSid",
                table: "CVReviewStages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CVReviewStages",
                table: "CVReviewStages",
                column: "CVReviewStageSid");

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 4, 19, 12, 45, 562, DateTimeKind.Utc).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 4, 19, 12, 45, 562, DateTimeKind.Utc).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 4, 19, 12, 45, 562, DateTimeKind.Utc).AddTicks(7413));

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("64018c1a-a5e7-4b5b-9189-1d893c40d658"), "Full-Time" },
                    { new Guid("65ed2e33-e49c-48ad-8df5-9140922f2aff"), "Contract" },
                    { new Guid("7c14f709-c074-4485-95b9-9518cec5f63e"), "Part-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("21def8c2-dd58-478a-8271-018ec1fe40d7"), true, "SQL Server" },
                    { new Guid("584982bb-daa0-4e75-9e87-6901649b95d5"), true, "Entity Framework Core" },
                    { new Guid("5856875e-78fb-4efd-86c0-24e8857972e0"), true, "JavaScript" },
                    { new Guid("77aaadce-bb82-4718-a20a-5fc5a20499ee"), true, "ASP.NET Core" },
                    { new Guid("9cc814bf-6240-4f3b-bd07-0920f765da90"), true, "React" },
                    { new Guid("9ea15407-71d6-4911-8675-6cc4aafc8235"), true, "C#" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("468a9d7a-8cbc-4d25-828e-f01121c743d8"), "GitHub" },
                    { new Guid("6459d3b0-2e54-4357-ab5a-c89c2819b733"), "Stack Overflow" },
                    { new Guid("84f68276-1a61-46ab-826e-ae3ca5261904"), "Portfolio" },
                    { new Guid("8c4df48a-e952-4dee-a238-7a8a0b31b2da"), "Twitter" },
                    { new Guid("d338060a-30cc-4275-b80f-88d427fa32a9"), "LinkedIn" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 19, 12, 45, 276, DateTimeKind.Utc).AddTicks(1167), "AQAAAAIAAYagAAAAEI/efDdoMabi0zn20nkssvL9HJK4b2iRkk1tlmTIMa02DLhHAHJzNns9WyVXMMuaGw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 19, 12, 45, 162, DateTimeKind.Utc).AddTicks(7102), "AQAAAAIAAYagAAAAEF3m9oMrSOOI9JWJk7O5dzM/SlZIJKnPnqL8LoFOMwXKKQMhpCgnWDGr6lh55WPvPQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 19, 12, 45, 373, DateTimeKind.Utc).AddTicks(2220), "AQAAAAIAAYagAAAAELj1vGG2La5FwXdCTuAEH/nFf6NAvsVwvTf83meuUyNlkLtdsVsU30JabLzO2pj98A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 19, 12, 45, 470, DateTimeKind.Utc).AddTicks(6011), "AQAAAAIAAYagAAAAEHf9Ga3UJ8oMZDFicAgpfi/ljqdMsjxMMe8XF4zI3sGaobcwwPJBlq3zvzPwlGv92w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 19, 12, 45, 59, DateTimeKind.Utc).AddTicks(9933), "AQAAAAIAAYagAAAAECQ5fN3t4YB0h9x0hy6oQXJG5o1wfYKJdeXENg2u3wrgBLIGmdIOvMyuPWI4uRJmmw==" });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("7716193f-2188-4524-a1d5-b70e4a72f875"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("9ea15407-71d6-4911-8675-6cc4aafc8235") },
                    { new Guid("94030797-f5af-41cc-a13b-110cafe4c556"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("9cc814bf-6240-4f3b-bd07-0920f765da90") },
                    { new Guid("97f1dc14-2aa0-4b07-a469-d8fbe64832d5"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("77aaadce-bb82-4718-a20a-5fc5a20499ee") }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("09f9f319-b455-4f2c-8bff-433f885f9f14"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("64018c1a-a5e7-4b5b-9189-1d893c40d658"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("2a778506-fc46-41e3-be10-f77e1cfab8d3"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("64018c1a-a5e7-4b5b-9189-1d893c40d658"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" },
                    { new Guid("50b43ef2-d999-49e7-b025-4b6ae1971067"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("65ed2e33-e49c-48ad-8df5-9140922f2aff"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" },
                    { new Guid("d95bf6ed-1ac2-41be-b483-f32a09c02d6f"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("7c14f709-c074-4485-95b9-9518cec5f63e"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("3cc51923-b38a-4eda-8523-6577d2b63e54"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 1, 19, 12, 45, 564, DateTimeKind.Utc).AddTicks(7283), new DateTime(2026, 2, 3, 19, 12, 45, 564, DateTimeKind.Utc).AddTicks(7284), new Guid("d95bf6ed-1ac2-41be-b483-f32a09c02d6f"), null, 5 },
                    { new Guid("3fc609ee-2ad3-4023-9d1f-8f22f17142b3"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 28, 19, 12, 45, 564, DateTimeKind.Utc).AddTicks(7272), new DateTime(2026, 1, 27, 19, 12, 45, 564, DateTimeKind.Utc).AddTicks(7273), new Guid("2a778506-fc46-41e3-be10-f77e1cfab8d3"), null, 2 },
                    { new Guid("41796f1f-bcdf-4127-ab13-8283e744f0b0"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 30, 19, 12, 45, 564, DateTimeKind.Utc).AddTicks(7279), new DateTime(2026, 1, 29, 19, 12, 45, 564, DateTimeKind.Utc).AddTicks(7280), new Guid("50b43ef2-d999-49e7-b025-4b6ae1971067"), null, 1 },
                    { new Guid("e481d97e-7cba-4200-9e04-79edf2916c71"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 25, 19, 12, 45, 564, DateTimeKind.Utc).AddTicks(7260), new DateTime(2026, 1, 24, 19, 12, 45, 564, DateTimeKind.Utc).AddTicks(7267), new Guid("09f9f319-b455-4f2c-8bff-433f885f9f14"), null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVReviewStages_ReviewedByUid",
                table: "CVReviewStages",
                column: "ReviewedByUid");

            migrationBuilder.AddForeignKey(
                name: "FK_CVReviewStages_JobApplications_JobApplicationId",
                table: "CVReviewStages",
                column: "JobApplicationId",
                principalTable: "JobApplications",
                principalColumn: "JobApplicationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CVReviewStages_Users_ReviewedByUid",
                table: "CVReviewStages",
                column: "ReviewedByUid",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
