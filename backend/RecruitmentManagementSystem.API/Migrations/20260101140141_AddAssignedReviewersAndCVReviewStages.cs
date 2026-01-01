using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAssignedReviewersAndCVReviewStages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    JobTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.JobTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "SocialPlatforms",
                columns: table => new
                {
                    SocialPlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialPlatforms", x => x.SocialPlatformId);
                });

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

            migrationBuilder.CreateTable(
                name: "JobDescriptions",
                columns: table => new
                {
                    JobDescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsibilty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumExperienceReq = table.Column<int>(type: "int", nullable: false),
                    JobTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescriptions", x => x.JobDescriptionId);
                    table.ForeignKey(
                        name: "FK_JobDescriptions_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "JobTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignedReviewers",
                columns: table => new
                {
                    AssignedReviewersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedByUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedReviewers", x => x.AssignedReviewersId);
                    table.ForeignKey(
                        name: "FK_AssignedReviewers_Users_Uid",
                        column: x => x.Uid,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "CandidateProfiles",
                columns: table => new
                {
                    CandidateProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateProfiles", x => x.CandidateProfileId);
                    table.ForeignKey(
                        name: "FK_CandidateProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobDescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpeningsCount = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_JobDescriptions_JobDescriptionId",
                        column: x => x.JobDescriptionId,
                        principalTable: "JobDescriptions",
                        principalColumn: "JobDescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkills",
                columns: table => new
                {
                    CandidateSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceYears = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    ProficiencyLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkills", x => x.CandidateSkillId);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_CandidateProfiles_CandidateProfileId",
                        column: x => x.CandidateProfileId,
                        principalTable: "CandidateProfiles",
                        principalColumn: "CandidateProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSocials",
                columns: table => new
                {
                    CandidateSocialsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocialPlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSocials", x => x.CandidateSocialsId);
                    table.ForeignKey(
                        name: "FK_CandidateSocials_CandidateProfiles_CandidateProfileId",
                        column: x => x.CandidateProfileId,
                        principalTable: "CandidateProfiles",
                        principalColumn: "CandidateProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSocials_SocialPlatforms_SocialPlatformId",
                        column: x => x.SocialPlatformId,
                        principalTable: "SocialPlatforms",
                        principalColumn: "SocialPlatformId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CVStorages",
                columns: table => new
                {
                    CVStorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVStorages", x => x.CVStorageId);
                    table.ForeignKey(
                        name: "FK_CVStorages_CandidateProfiles_CandidateProfileId",
                        column: x => x.CandidateProfileId,
                        principalTable: "CandidateProfiles",
                        principalColumn: "CandidateProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PercentageScore = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Educations_CandidateProfiles_CandidateProfileId",
                        column: x => x.CandidateProfileId,
                        principalTable: "CandidateProfiles",
                        principalColumn: "CandidateProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationYears = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceId);
                    table.ForeignKey(
                        name: "FK_Experiences_CandidateProfiles_CandidateProfileId",
                        column: x => x.CandidateProfileId,
                        principalTable: "CandidateProfiles",
                        principalColumn: "CandidateProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    JobApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.JobApplicationId);
                    table.ForeignKey(
                        name: "FK_JobApplications_CandidateProfiles_CandidateProfileId",
                        column: x => x.CandidateProfileId,
                        principalTable: "CandidateProfiles",
                        principalColumn: "CandidateProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplications_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CVReviewStages",
                columns: table => new
                {
                    CVReviewStageSid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewedByUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPass = table.Column<bool>(type: "bit", nullable: true),
                    AssignedReviewersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVReviewStages", x => x.CVReviewStageSid);
                    table.ForeignKey(
                        name: "FK_CVReviewStages_AssignedReviewers_AssignedReviewersId",
                        column: x => x.AssignedReviewersId,
                        principalTable: "AssignedReviewers",
                        principalColumn: "AssignedReviewersId");
                    table.ForeignKey(
                        name: "FK_CVReviewStages_JobApplications_JobApplicationId",
                        column: x => x.JobApplicationId,
                        principalTable: "JobApplications",
                        principalColumn: "JobApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CVReviewStages_Users_ReviewedByUid",
                        column: x => x.ReviewedByUid,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

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

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "RoleName", "active" },
                values: new object[,]
                {
                    { new Guid("66a24f39-2e0a-46fd-81b5-13d6bddb8c5c"), "Recruiter", true },
                    { new Guid("b57751e8-24af-473b-a7aa-ff30ddfc0d49"), "Admin", true },
                    { new Guid("c016dbd1-11c4-444b-8b3e-84095706fc60"), "Candidate", true }
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
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "DOB", "Email", "Fname", "Gender", "IsActive", "LastLogin", "Lname", "MobileNumber", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"), new DateTime(2026, 1, 1, 14, 1, 40, 244, DateTimeKind.Utc).AddTicks(7251), new DateTime(1998, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abhi@exp.com", "Abhi", "Male", true, null, "G", "1111111111", "AQAAAAIAAYagAAAAEEQKx5BqHTmkKXLoTHcILqVS0zQE9pTyIjdilBSj5GT8XMa/h0mqTwDeB9hST8efmw==", null, null, new Guid("c016dbd1-11c4-444b-8b3e-84095706fc60") },
                    { new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 1, 14, 1, 40, 115, DateTimeKind.Utc).AddTicks(7761), new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "peter@exp.com", "Peter", "Male", true, null, "Parker", "0987654321", "AQAAAAIAAYagAAAAEEQDzwKB6ZeFw+c9A3a5ZfnLaSpWU5Xc0b5JKzCtVXXpUR3tPEyd96fBP/5883Rpfg==", null, null, new Guid("66a24f39-2e0a-46fd-81b5-13d6bddb8c5c") },
                    { new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"), new DateTime(2026, 1, 1, 14, 1, 40, 3, DateTimeKind.Utc).AddTicks(1036), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@exp.com", "Admin", "Male", true, null, "User", "1234567890", "AQAAAAIAAYagAAAAECG1iUtwFsCbLpJvieQC4TkFWuL092+iCIjQdr+Ra+yHRKEu07xireejD0lknYJkuw==", null, null, new Guid("b57751e8-24af-473b-a7aa-ff30ddfc0d49") }
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
                    { new Guid("388a20c2-15dc-4e8b-ae38-7a2031b02507"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 29, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(364), new DateTime(2026, 1, 31, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(365), new Guid("293c1c1d-8e65-4c40-a814-aaeeaa428e61"), null, 5 },
                    { new Guid("8d634e54-8b07-48db-acf7-7f8b10607920"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 25, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(350), new DateTime(2026, 1, 24, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(351), new Guid("877ae8f6-2188-4bb7-9b84-5ff322ac2d6c"), null, 2 },
                    { new Guid("c6ab91d6-755a-4440-8015-de43993c1c8c"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 27, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(357), new DateTime(2026, 1, 26, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(358), new Guid("54a7c166-bb73-4ec6-9816-4a6427e73706"), null, 1 },
                    { new Guid("d09714b6-5f0c-4682-a38c-9fac543d8f14"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 22, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 1, 21, 14, 1, 40, 419, DateTimeKind.Utc).AddTicks(341), new Guid("001edd6b-70e4-47c5-a429-300ec0ab611d"), null, 3 }
                });

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
                name: "IX_AssignedReviewers_Uid",
                table: "AssignedReviewers",
                column: "Uid");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProfiles_UserId",
                table: "CandidateProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_CandidateProfileId",
                table: "CandidateSkills",
                column: "CandidateProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_SkillId",
                table: "CandidateSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSocials_CandidateProfileId_SocialPlatformId",
                table: "CandidateSocials",
                columns: new[] { "CandidateProfileId", "SocialPlatformId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSocials_SocialPlatformId",
                table: "CandidateSocials",
                column: "SocialPlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_CVReviewStages_AssignedReviewersId",
                table: "CVReviewStages",
                column: "AssignedReviewersId");

            migrationBuilder.CreateIndex(
                name: "IX_CVReviewStages_JobApplicationId",
                table: "CVReviewStages",
                column: "JobApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_CVReviewStages_ReviewedByUid",
                table: "CVReviewStages",
                column: "ReviewedByUid");

            migrationBuilder.CreateIndex(
                name: "IX_CVStorages_CandidateProfileId",
                table: "CVStorages",
                column: "CandidateProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CandidateProfileId",
                table: "Educations",
                column: "CandidateProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CandidateProfileId",
                table: "Experiences",
                column: "CandidateProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CandidateProfileId",
                table: "JobApplications",
                column: "CandidateProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobId",
                table: "JobApplications",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobDescriptions_JobTypeId",
                table: "JobDescriptions",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CreatedByUserId",
                table: "Jobs",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobDescriptionId",
                table: "Jobs",
                column: "JobDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialPlatforms_Name",
                table: "SocialPlatforms",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateSkills");

            migrationBuilder.DropTable(
                name: "CandidateSocials");

            migrationBuilder.DropTable(
                name: "CVReviewStages");

            migrationBuilder.DropTable(
                name: "CVStorages");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SocialPlatforms");

            migrationBuilder.DropTable(
                name: "AssignedReviewers");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "CandidateProfiles");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "JobDescriptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
