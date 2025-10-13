using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class addJobApplication : Migration
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

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("9b3dba76-b255-4d3c-964d-8c764f081704"), "Full-Time" },
                    { new Guid("9d20f8ec-f97b-49e3-bcce-951d5a0b6f5d"), "Contract" },
                    { new Guid("a948d4ae-56e2-4637-98a8-5395f76c5f8d"), "Part-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("47e22076-cd0c-42fd-8903-6039532b7bb3"), true, "Entity Framework Core" },
                    { new Guid("615fd2cc-fee6-4235-b97f-cc01ab4a3cfa"), true, "JavaScript" },
                    { new Guid("72537f82-c966-4728-8fe2-2e38ad4fbb86"), true, "ASP.NET Core" },
                    { new Guid("c0609e0d-f977-4122-9fd6-2725bddc33a5"), true, "SQL Server" },
                    { new Guid("f41f37ad-52bd-4edb-a7e5-8b187d9e9cef"), true, "C#" },
                    { new Guid("f8226c1e-b668-45e2-be5c-a8d96330d81e"), true, "React" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("0c8be5b5-93f6-40f4-88f3-9f8190acca69"), "Portfolio" },
                    { new Guid("78908330-6c7b-4d70-8a64-d47c30ae9b67"), "Twitter" },
                    { new Guid("a2009b5c-6d31-46f2-a855-39ccf269fdf5"), "Stack Overflow" },
                    { new Guid("b8d3b3bd-7a05-4b26-b52a-04317c8fc6fe"), "LinkedIn" },
                    { new Guid("ea8b7980-50bb-44c8-973c-1962f86f29d1"), "GitHub" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "RoleName", "active" },
                values: new object[,]
                {
                    { new Guid("02a3603f-8d61-48dc-b160-155ad6742082"), "Candidate", true },
                    { new Guid("24f6c931-3342-4b4f-b9c7-4f8a8cb82f10"), "Recruiter", true },
                    { new Guid("8dcde8b0-144f-4a2c-8b4f-552973f6726c"), "Admin", true }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("54908862-c3ae-42c8-9c29-b03e5017fa5f"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("a948d4ae-56e2-4637-98a8-5395f76c5f8d"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("99ac97d2-01ce-4dea-ab17-47eae5769d9f"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("9b3dba76-b255-4d3c-964d-8c764f081704"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" },
                    { new Guid("d876a659-76db-47ae-9fe4-9872d74943e3"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("9d20f8ec-f97b-49e3-bcce-951d5a0b6f5d"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" },
                    { new Guid("f62eeab4-2de2-4ed0-9c3d-3d1fe90a7ddf"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("9b3dba76-b255-4d3c-964d-8c764f081704"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "DOB", "Email", "Fname", "Gender", "IsActive", "LastLogin", "Lname", "MobileNumber", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"), new DateTime(2025, 10, 12, 8, 28, 4, 4, DateTimeKind.Utc).AddTicks(7538), new DateTime(1998, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abhi@exp.com", "Abhi", "Male", true, null, "G", "1111111111", "AQAAAAIAAYagAAAAEOOAtrBiqFFzbt6OxpI9EnhRufZUpohq5M+9Z/WykOaxfKZ8SdY87rKSfJ8NeNzUxw==", null, null, new Guid("02a3603f-8d61-48dc-b160-155ad6742082") },
                    { new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 10, 12, 8, 28, 3, 895, DateTimeKind.Utc).AddTicks(6053), new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "peter@exp.com", "Peter", "Male", true, null, "Parker", "0987654321", "AQAAAAIAAYagAAAAEGgT8g42VsM5EHti8dMK5lZtrSbrJCaICK91Ss5eUtG0Er4EkexbKCdvjF8kFEqibQ==", null, null, new Guid("24f6c931-3342-4b4f-b9c7-4f8a8cb82f10") },
                    { new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"), new DateTime(2025, 10, 12, 8, 28, 3, 778, DateTimeKind.Utc).AddTicks(1674), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@exp.com", "Admin", "Male", true, null, "User", "1234567890", "AQAAAAIAAYagAAAAEGI0v1p62Mg/5kYDssM1Xr6uyfdT4TU6/nxHywFVDmIDZKT0DzzR8SzoGD/5d4rH1A==", null, null, new Guid("8dcde8b0-144f-4a2c-8b4f-552973f6726c") }
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
                    { new Guid("3e4cfbf0-a193-4671-b145-5d5bce4ac68e"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 10, 9, 8, 28, 4, 141, DateTimeKind.Utc).AddTicks(511), new DateTime(2025, 11, 11, 8, 28, 4, 141, DateTimeKind.Utc).AddTicks(512), new Guid("54908862-c3ae-42c8-9c29-b03e5017fa5f"), null, 5 },
                    { new Guid("9fcf555f-cfff-434f-b957-284dc34b5712"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 10, 7, 8, 28, 4, 141, DateTimeKind.Utc).AddTicks(507), new DateTime(2025, 11, 6, 8, 28, 4, 141, DateTimeKind.Utc).AddTicks(508), new Guid("d876a659-76db-47ae-9fe4-9872d74943e3"), null, 1 },
                    { new Guid("9fe3960e-c13d-44a0-955c-8d0b4123e17e"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 10, 5, 8, 28, 4, 141, DateTimeKind.Utc).AddTicks(502), new DateTime(2025, 11, 4, 8, 28, 4, 141, DateTimeKind.Utc).AddTicks(503), new Guid("99ac97d2-01ce-4dea-ab17-47eae5769d9f"), null, 2 },
                    { new Guid("c6f12993-936e-4d06-adf1-4f9d7cf5d587"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 10, 2, 8, 28, 4, 141, DateTimeKind.Utc).AddTicks(488), new DateTime(2025, 11, 1, 8, 28, 4, 141, DateTimeKind.Utc).AddTicks(498), new Guid("f62eeab4-2de2-4ed0-9c3d-3d1fe90a7ddf"), null, 3 }
                });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("1604e37e-7e5a-4e63-98d2-4181d181645d"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("72537f82-c966-4728-8fe2-2e38ad4fbb86") },
                    { new Guid("493e1518-33d5-4dee-8a73-4ab71ddded43"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("f8226c1e-b668-45e2-be5c-a8d96330d81e") },
                    { new Guid("cfa2215c-4cf4-4702-be88-01f5ae56d1f8"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("f41f37ad-52bd-4edb-a7e5-8b187d9e9cef") }
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
                name: "CVStorages");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SocialPlatforms");

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
