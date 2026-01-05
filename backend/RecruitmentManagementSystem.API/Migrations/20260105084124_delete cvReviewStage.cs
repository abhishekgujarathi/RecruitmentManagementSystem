using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class deletecvReviewStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVReviewStages");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsPass",
                table: "AssignedReviewers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReviewCompleted",
                table: "AssignedReviewers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewCompletedAt",
                table: "AssignedReviewers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 5, 8, 41, 21, 223, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 5, 8, 41, 21, 223, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 5, 8, 41, 21, 223, DateTimeKind.Utc).AddTicks(9011));

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("493d816a-2fae-42e5-a4ec-e0e116071a77"), "Part-Time" },
                    { new Guid("b7fb22a8-901c-45b3-a5c3-8a567c481c9a"), "Contract" },
                    { new Guid("bca4d3f6-2010-475a-81e5-5b71e06f118e"), "Full-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("0f43ffe8-70eb-4ff3-a131-4f2f9183b1b1"), true, "React" },
                    { new Guid("182eddce-2890-43a2-b7c9-725e58d272ec"), true, "ASP.NET Core" },
                    { new Guid("95263483-37c6-42d6-a8bb-112c8c12b1ec"), true, "C#" },
                    { new Guid("a007ca29-9fe9-4483-a944-59d031bfecf9"), true, "Entity Framework Core" },
                    { new Guid("c94fb23b-0555-497f-96b2-a126c53ee6b6"), true, "SQL Server" },
                    { new Guid("e591431e-e935-498a-9669-5ddaca2871ac"), true, "JavaScript" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("7bbea65d-b7a2-4a3a-b308-513d481fdec8"), "Twitter" },
                    { new Guid("7e9ad767-3282-4765-8d61-f43523e0c1ea"), "Stack Overflow" },
                    { new Guid("b8491feb-307a-460d-b117-b00eab866b11"), "Portfolio" },
                    { new Guid("ca80483f-43f1-4982-9869-af869d33efeb"), "GitHub" },
                    { new Guid("d824ed3e-2635-4a7d-b10d-82086a38aeaf"), "LinkedIn" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 8, 41, 20, 933, DateTimeKind.Utc).AddTicks(5911), "AQAAAAIAAYagAAAAEI5CfWkp8YRE5brO47pOhBG113QMjiqZI32wMOgCAgiEGtCSJDJ7kSeKe0wMBHsTPw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 8, 41, 20, 843, DateTimeKind.Utc).AddTicks(1900), "AQAAAAIAAYagAAAAEClsDhJ+rB0GAwnhQ8Rp0OAJ65mvlVn6fAM+So41x7Gyk9IAf+LlY8aTxnWsckF4nw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 8, 41, 21, 33, DateTimeKind.Utc).AddTicks(3060), "AQAAAAIAAYagAAAAEIvgTl49ASQv4Qo+ajvkM9BurbcyL8TcBIpKr19TgirhTpHxHqu6y4VKdp+elRwAgA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 8, 41, 21, 128, DateTimeKind.Utc).AddTicks(4399), "AQAAAAIAAYagAAAAEMje5ZDDPCpWK3nJfEUx2zLSWa+zG1saf5/3y4MlRxTipMHDsZkXtYTHzFLqp7kGdw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 8, 41, 20, 753, DateTimeKind.Utc).AddTicks(4385), "AQAAAAIAAYagAAAAEAd3p8HLrFop66dmFxVyKnkUn57kbPIc1vHxdgSraARSaVp5h0q1vNhh6+DhpByH9Q==" });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("9e6ceac5-ee46-439c-ac0c-c5f02755fbf8"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("95263483-37c6-42d6-a8bb-112c8c12b1ec") },
                    { new Guid("a87146c5-f4a5-4df3-ae68-bc1220f31557"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("0f43ffe8-70eb-4ff3-a131-4f2f9183b1b1") },
                    { new Guid("ec07afb9-f5b9-4913-82e5-29d1efa959e9"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("182eddce-2890-43a2-b7c9-725e58d272ec") }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("06104643-7c6a-45bd-bb6d-e2598ead8c71"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("493d816a-2fae-42e5-a4ec-e0e116071a77"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("5c43bd3b-e4d8-46ab-ac76-f18e4cbd3921"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("b7fb22a8-901c-45b3-a5c3-8a567c481c9a"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" },
                    { new Guid("82510579-c9d5-49bf-ae17-eca3c31f8f1f"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("bca4d3f6-2010-475a-81e5-5b71e06f118e"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("97e802eb-6f4c-45c5-868a-2e9c8410bf1c"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("bca4d3f6-2010-475a-81e5-5b71e06f118e"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("277d71b9-6fb7-41dd-b334-03a58357fee9"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 2, 8, 41, 21, 225, DateTimeKind.Utc).AddTicks(9359), new DateTime(2026, 2, 4, 8, 41, 21, 225, DateTimeKind.Utc).AddTicks(9360), new Guid("06104643-7c6a-45bd-bb6d-e2598ead8c71"), null, 5 },
                    { new Guid("33c74333-a942-4a71-a7de-6ebb1c47abd8"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 29, 8, 41, 21, 225, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 1, 28, 8, 41, 21, 225, DateTimeKind.Utc).AddTicks(9351), new Guid("97e802eb-6f4c-45c5-868a-2e9c8410bf1c"), null, 2 },
                    { new Guid("500556d0-50a0-41ec-8934-016e66365208"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 31, 8, 41, 21, 225, DateTimeKind.Utc).AddTicks(9355), new DateTime(2026, 1, 30, 8, 41, 21, 225, DateTimeKind.Utc).AddTicks(9356), new Guid("5c43bd3b-e4d8-46ab-ac76-f18e4cbd3921"), null, 1 },
                    { new Guid("f6ce07d7-d263-4e3f-8617-7f7cee41156e"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 26, 8, 41, 21, 225, DateTimeKind.Utc).AddTicks(9337), new DateTime(2026, 1, 25, 8, 41, 21, 225, DateTimeKind.Utc).AddTicks(9345), new Guid("82510579-c9d5-49bf-ae17-eca3c31f8f1f"), null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("9e6ceac5-ee46-439c-ac0c-c5f02755fbf8"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("a87146c5-f4a5-4df3-ae68-bc1220f31557"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("ec07afb9-f5b9-4913-82e5-29d1efa959e9"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("277d71b9-6fb7-41dd-b334-03a58357fee9"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("33c74333-a942-4a71-a7de-6ebb1c47abd8"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("500556d0-50a0-41ec-8934-016e66365208"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("f6ce07d7-d263-4e3f-8617-7f7cee41156e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("a007ca29-9fe9-4483-a944-59d031bfecf9"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("c94fb23b-0555-497f-96b2-a126c53ee6b6"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("e591431e-e935-498a-9669-5ddaca2871ac"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("7bbea65d-b7a2-4a3a-b308-513d481fdec8"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("7e9ad767-3282-4765-8d61-f43523e0c1ea"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("b8491feb-307a-460d-b117-b00eab866b11"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("ca80483f-43f1-4982-9869-af869d33efeb"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("d824ed3e-2635-4a7d-b10d-82086a38aeaf"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("06104643-7c6a-45bd-bb6d-e2598ead8c71"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("5c43bd3b-e4d8-46ab-ac76-f18e4cbd3921"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("82510579-c9d5-49bf-ae17-eca3c31f8f1f"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("97e802eb-6f4c-45c5-868a-2e9c8410bf1c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("0f43ffe8-70eb-4ff3-a131-4f2f9183b1b1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("182eddce-2890-43a2-b7c9-725e58d272ec"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("95263483-37c6-42d6-a8bb-112c8c12b1ec"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("493d816a-2fae-42e5-a4ec-e0e116071a77"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("b7fb22a8-901c-45b3-a5c3-8a567c481c9a"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("bca4d3f6-2010-475a-81e5-5b71e06f118e"));

            migrationBuilder.DropColumn(
                name: "IsPass",
                table: "AssignedReviewers");

            migrationBuilder.DropColumn(
                name: "IsReviewCompleted",
                table: "AssignedReviewers");

            migrationBuilder.DropColumn(
                name: "ReviewCompletedAt",
                table: "AssignedReviewers");

            migrationBuilder.CreateTable(
                name: "CVReviewStages",
                columns: table => new
                {
                    CVReviewStageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedReviewersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPass = table.Column<bool>(type: "bit", nullable: true),
                    JobApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVReviewStages", x => x.CVReviewStageId);
                    table.ForeignKey(
                        name: "FK_CVReviewStages_AssignedReviewers_AssignedReviewersId",
                        column: x => x.AssignedReviewersId,
                        principalTable: "AssignedReviewers",
                        principalColumn: "AssignedReviewersId");
                    table.ForeignKey(
                        name: "FK_CVReviewStages_JobApplications_JobApplicationId",
                        column: x => x.JobApplicationId,
                        principalTable: "JobApplications",
                        principalColumn: "JobApplicationId");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CVReviewStages_AssignedReviewersId",
                table: "CVReviewStages",
                column: "AssignedReviewersId");

            migrationBuilder.CreateIndex(
                name: "IX_CVReviewStages_JobApplicationId",
                table: "CVReviewStages",
                column: "JobApplicationId");
        }
    }
}
