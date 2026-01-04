using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class reviewmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ApplicationSkills",
                columns: table => new
                {
                    ApplicationSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasSkill = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSkills", x => x.ApplicationSkillId);
                    table.ForeignKey(
                        name: "FK_ApplicationSkills_JobApplications_JobApplicationId",
                        column: x => x.JobApplicationId,
                        principalTable: "JobApplications",
                        principalColumn: "JobApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewComments",
                columns: table => new
                {
                    ReviewCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentedByUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewComments", x => x.ReviewCommentId);
                    table.ForeignKey(
                        name: "FK_ReviewComments_JobApplications_JobApplicationId",
                        column: x => x.JobApplicationId,
                        principalTable: "JobApplications",
                        principalColumn: "JobApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewComments_Users_CommentedByUid",
                        column: x => x.CommentedByUid,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationSkills_JobApplicationId",
                table: "ApplicationSkills",
                column: "JobApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationSkills_SkillId",
                table: "ApplicationSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewComments_CommentedByUid",
                table: "ReviewComments",
                column: "CommentedByUid");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewComments_JobApplicationId",
                table: "ReviewComments",
                column: "JobApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationSkills");

            migrationBuilder.DropTable(
                name: "ReviewComments");

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

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 2, 8, 24, 37, 853, DateTimeKind.Utc).AddTicks(6572));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 2, 8, 24, 37, 853, DateTimeKind.Utc).AddTicks(6576));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 2, 8, 24, 37, 853, DateTimeKind.Utc).AddTicks(6578));

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
    }
}
