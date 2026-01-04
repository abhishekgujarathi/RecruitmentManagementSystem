using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class jobskills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("753827ff-7e0c-4ae3-9115-69ba9237f05f"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("8df3b520-de8a-4da4-b293-77ac6d161d93"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("8f566f10-c466-4ece-9d9c-3b1d4e66822a"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("03a00e98-67a8-4894-a165-3a28607a4e91"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("37241a65-41c6-4669-b4f1-6df822971655"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("aff3c433-ac58-4435-82ae-57ba62d99c5b"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("e84d9f4f-7771-4e17-8107-2b6d22e7b7d2"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("24aee018-88fb-42ec-a0ab-732d4c34ad2c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("2d3e7595-695b-40a0-8c30-011934c3b068"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("79f07a26-1839-482c-a1a9-11257fc359ef"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("4fdd69af-2e30-48ce-bfab-b6311464e760"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("abd8ce77-eb66-4fcd-b028-160dbb0f0dbe"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("e4859af1-f528-4661-8f5a-9a62d05ef741"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("f831d657-e721-4dc0-b00b-46c7ebd946a6"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("fb074ad0-94bd-4b77-a0c8-4e8f1722bf9f"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("3a983a21-efba-4485-9e3c-3a68c7f153a0"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("5018f850-1335-4e61-afc2-3a1db9a914b9"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("92f5854b-2bfc-4136-9ed5-fdacef7afb27"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("e758fdb2-9ae7-4294-bfc9-4a05fcef129b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("1d812ff8-4218-4852-80b0-a2551f3465d8"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("51228076-7dd7-49e2-8766-2c9c07e9426d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("582456bc-f1ab-42a5-b852-9f0e9d664afe"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("00f8698f-94d2-4e05-9e59-c1497c00645d"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("0c4e7b39-6ebb-4125-8b59-534e3ec3d905"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("24ae3def-df95-463f-90b3-8d743c9670ad"));

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    JobSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinExperienceYears = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => x.JobSkillId);
                    table.ForeignKey(
                        name: "FK_JobSkills_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_JobSkills_JobId",
                table: "JobSkills",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkills",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSkills");

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

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 4, 18, 54, 37, 161, DateTimeKind.Utc).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 4, 18, 54, 37, 161, DateTimeKind.Utc).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 4, 18, 54, 37, 161, DateTimeKind.Utc).AddTicks(2948));

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("00f8698f-94d2-4e05-9e59-c1497c00645d"), "Part-Time" },
                    { new Guid("0c4e7b39-6ebb-4125-8b59-534e3ec3d905"), "Contract" },
                    { new Guid("24ae3def-df95-463f-90b3-8d743c9670ad"), "Full-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("1d812ff8-4218-4852-80b0-a2551f3465d8"), true, "ASP.NET Core" },
                    { new Guid("24aee018-88fb-42ec-a0ab-732d4c34ad2c"), true, "Entity Framework Core" },
                    { new Guid("2d3e7595-695b-40a0-8c30-011934c3b068"), true, "JavaScript" },
                    { new Guid("51228076-7dd7-49e2-8766-2c9c07e9426d"), true, "React" },
                    { new Guid("582456bc-f1ab-42a5-b852-9f0e9d664afe"), true, "C#" },
                    { new Guid("79f07a26-1839-482c-a1a9-11257fc359ef"), true, "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("4fdd69af-2e30-48ce-bfab-b6311464e760"), "GitHub" },
                    { new Guid("abd8ce77-eb66-4fcd-b028-160dbb0f0dbe"), "LinkedIn" },
                    { new Guid("e4859af1-f528-4661-8f5a-9a62d05ef741"), "Stack Overflow" },
                    { new Guid("f831d657-e721-4dc0-b00b-46c7ebd946a6"), "Twitter" },
                    { new Guid("fb074ad0-94bd-4b77-a0c8-4e8f1722bf9f"), "Portfolio" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 18, 54, 36, 877, DateTimeKind.Utc).AddTicks(5798), "AQAAAAIAAYagAAAAEPVjHZWkb9u9A7vkhSC79Yikg04G7/pQ/ev04YvG7R3oWTpd+wc8dJ1++ZhHv6f2SA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 18, 54, 36, 769, DateTimeKind.Utc).AddTicks(3703), "AQAAAAIAAYagAAAAEHXrlpGLcxzr+zFTZeqGNkJy/HXk+daIjpOh4M23epLihs1bpp+QCVCtRgW2Zgl/UQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 18, 54, 36, 975, DateTimeKind.Utc).AddTicks(9699), "AQAAAAIAAYagAAAAECEcx2dhl5xZ4aI+G6fB1c8Zdsr/z1XYsNsQqDRV2InV9qYYmye05keKw/Swx2uazA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 18, 54, 37, 66, DateTimeKind.Utc).AddTicks(8462), "AQAAAAIAAYagAAAAEIRJpXZfXGTowQCySzJpjdyWXNhqN5XFEPDXSrRtpOWrOgG0lG6M3mwSEIzYO7OkQw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 4, 18, 54, 36, 680, DateTimeKind.Utc).AddTicks(4006), "AQAAAAIAAYagAAAAELYRJ+yjINcPkLAO9BILehNhcZfTyE8We2OwASGOPkf3dMBA0yu23mpFScSHSbCacw==" });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("753827ff-7e0c-4ae3-9115-69ba9237f05f"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("51228076-7dd7-49e2-8766-2c9c07e9426d") },
                    { new Guid("8df3b520-de8a-4da4-b293-77ac6d161d93"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("582456bc-f1ab-42a5-b852-9f0e9d664afe") },
                    { new Guid("8f566f10-c466-4ece-9d9c-3b1d4e66822a"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("1d812ff8-4218-4852-80b0-a2551f3465d8") }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("3a983a21-efba-4485-9e3c-3a68c7f153a0"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("00f8698f-94d2-4e05-9e59-c1497c00645d"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("5018f850-1335-4e61-afc2-3a1db9a914b9"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("24ae3def-df95-463f-90b3-8d743c9670ad"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" },
                    { new Guid("92f5854b-2bfc-4136-9ed5-fdacef7afb27"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("0c4e7b39-6ebb-4125-8b59-534e3ec3d905"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" },
                    { new Guid("e758fdb2-9ae7-4294-bfc9-4a05fcef129b"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("24ae3def-df95-463f-90b3-8d743c9670ad"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("03a00e98-67a8-4894-a165-3a28607a4e91"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 30, 18, 54, 37, 163, DateTimeKind.Utc).AddTicks(2080), new DateTime(2026, 1, 29, 18, 54, 37, 163, DateTimeKind.Utc).AddTicks(2081), new Guid("92f5854b-2bfc-4136-9ed5-fdacef7afb27"), null, 1 },
                    { new Guid("37241a65-41c6-4669-b4f1-6df822971655"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 25, 18, 54, 37, 163, DateTimeKind.Utc).AddTicks(2066), new DateTime(2026, 1, 24, 18, 54, 37, 163, DateTimeKind.Utc).AddTicks(2072), new Guid("e758fdb2-9ae7-4294-bfc9-4a05fcef129b"), null, 3 },
                    { new Guid("aff3c433-ac58-4435-82ae-57ba62d99c5b"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 28, 18, 54, 37, 163, DateTimeKind.Utc).AddTicks(2076), new DateTime(2026, 1, 27, 18, 54, 37, 163, DateTimeKind.Utc).AddTicks(2077), new Guid("5018f850-1335-4e61-afc2-3a1db9a914b9"), null, 2 },
                    { new Guid("e84d9f4f-7771-4e17-8107-2b6d22e7b7d2"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 1, 18, 54, 37, 163, DateTimeKind.Utc).AddTicks(2084), new DateTime(2026, 2, 3, 18, 54, 37, 163, DateTimeKind.Utc).AddTicks(2085), new Guid("3a983a21-efba-4485-9e3c-3a68c7f153a0"), null, 5 }
                });
        }
    }
}
