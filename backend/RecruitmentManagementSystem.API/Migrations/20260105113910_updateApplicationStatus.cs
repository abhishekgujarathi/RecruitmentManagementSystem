using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class updateApplicationStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("5b0e6bae-ed29-4a3f-93a3-33af2f86d341"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("a3f6125e-78f2-493c-a24c-b4b8fc4cbb11"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("b57e0fee-b0b5-4c6d-b804-5c8549f8301c"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("3e521942-18fa-4ae8-9904-dae472de97ed"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("4f934501-1cbd-4eb9-be73-d5d93d4b9a84"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("808a20bc-31b4-4f2f-8e6a-7d8b5e4cd00b"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("873721d2-c5c1-43b5-bad8-66aa516f03b1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("4ac9084e-1d6f-4dce-8d7c-ad394e3708d1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("90b5e3c9-bd47-4feb-81a8-de2e73b3f16f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("d29ef713-fd70-4a79-836e-c05e30e1f1c3"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("0ad5886a-2462-466e-a7f9-155e0bf4211c"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("3e0cde21-b550-4b68-aaff-44e8f9f337bd"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("4477976a-135c-484d-bf6c-279a58b01480"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("6c35d991-1aa3-4fd3-90da-a80b83dde7de"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("dab745ea-ec96-4c38-a7eb-0f35a8ee637c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("62fbaf51-83b1-4726-8f15-f955fae67d28"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("917ddbd6-7ce4-46b8-9299-746a97ab704f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("c0b037c2-24c3-4099-b282-ff6eb59d94c9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("fbadf689-1739-4bf9-9289-9192ef8af7c3"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("07ca700e-e44c-43ef-bb86-590fc3b317b0"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("5fae42f9-731a-4255-a360-5459be157b88"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("940710b6-75c2-442c-bcc6-ebbb232d551a"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("b2bdde44-b6ee-4766-bfb9-6238066cec70"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("0378b6b2-b6e5-40f0-8d8e-a761c8c20490"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("11c28dbc-65d9-469d-9237-71c361011062"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("89e0eb0b-cd90-47ae-85bd-bfe3c8fe6112"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("48041d3b-bdda-4e9b-92c1-9a5e433c263b"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("54398d03-25a0-498b-a0f6-f84828e7c377"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("5cf38279-2032-497c-a2fd-a1d79aec261a"));

            migrationBuilder.AddColumn<string>(
                name: "StatusNote",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusUpdatedAt",
                table: "JobApplications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 5, 11, 39, 8, 205, DateTimeKind.Utc).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 5, 11, 39, 8, 205, DateTimeKind.Utc).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 5, 11, 39, 8, 205, DateTimeKind.Utc).AddTicks(9842));

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("633c036c-77be-4058-8089-c8ff6bbed3df"), "Contract" },
                    { new Guid("a8ea41ea-cd52-4941-bed2-7087d1802fdd"), "Full-Time" },
                    { new Guid("eeabfc86-e8b5-4246-8700-302d75b66ae6"), "Part-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("0f2fd736-5102-4a50-baa9-5e79dcb95dfb"), true, "JavaScript" },
                    { new Guid("528e547f-a378-49a3-8b9e-5c04f5c5e63e"), true, "Entity Framework Core" },
                    { new Guid("8f72f4c0-b3c5-42bc-9c27-037e63d4669d"), true, "React" },
                    { new Guid("9900b863-3cec-4e2b-a912-87dba3aa495f"), true, "SQL Server" },
                    { new Guid("b1ae8265-2ae0-4ca3-9c06-4f3f17cee81b"), true, "ASP.NET Core" },
                    { new Guid("c40a1bfd-05e3-458d-a47d-11efe6ff4519"), true, "C#" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("1e09daee-08c0-4cc4-80c2-4101af83488a"), "Stack Overflow" },
                    { new Guid("81bbf471-3dea-4787-baac-f92fee60cc92"), "LinkedIn" },
                    { new Guid("9b27f2ea-9c24-48c9-9972-df262d9428a7"), "Portfolio" },
                    { new Guid("9b9f6302-f903-4e2f-8d51-7a537b25e689"), "Twitter" },
                    { new Guid("b7674155-c3a6-4ff2-9bd8-ef999508e5f3"), "GitHub" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 11, 39, 7, 492, DateTimeKind.Utc).AddTicks(1751), "AQAAAAIAAYagAAAAEG5sbEpKspiTx11hDRkxVwSR8/+FVzB4IisIioZk5ZqGOoEWUSFnWVy42It/zrHrsg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 11, 39, 7, 398, DateTimeKind.Utc).AddTicks(5873), "AQAAAAIAAYagAAAAEI4nrqhVvir68wpiSmr3EsriNKxNXh9bCWq+VrS0hR9GntFG9WvRTV0EgpsaLOhB/A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 11, 39, 7, 596, DateTimeKind.Utc).AddTicks(2305), "AQAAAAIAAYagAAAAEErvh+Vxu5WZZnvvsRfsa1cj9KSIcaGEjF3LAk0jyzJFALDZd3qtGoEUqA3SCzh8ww==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 11, 39, 7, 693, DateTimeKind.Utc).AddTicks(2765), "AQAAAAIAAYagAAAAEAdTC++iFc5SQfs6xutOXCfnnED3HllSZU1mnuzBQ7VMC9EQc7M6XxOERxxb44jilg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 11, 39, 7, 301, DateTimeKind.Utc).AddTicks(9113), "AQAAAAIAAYagAAAAECOJFDKaqaO+M/jRaGOZDPiD6n1WCffZw5lB3vIxECaI3VTY9BJ/ot88O9SpyqdRTg==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "DOB", "Email", "Fname", "Gender", "IsActive", "LastLogin", "Lname", "MobileNumber", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "UserTypeId" },
                values: new object[,]
                {
                    { new Guid("805b992a-ac42-4d3c-9e05-fcfc9549c4f7"), new DateTime(2026, 1, 5, 11, 39, 8, 114, DateTimeKind.Utc).AddTicks(8746), new DateTime(1994, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "sneha@exp.com", "Sneha", "Female", true, null, "Reddy", "9000000004", "AQAAAAIAAYagAAAAEDeP+F869quzS1qScg6TLw5ads/bwtFpj9H5wVphHV8ZA7t1Vmjz04/mnT6wT9RSIQ==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("acb0c509-65f2-4e0c-b990-64838415b233"), new DateTime(2026, 1, 5, 11, 39, 8, 0, DateTimeKind.Utc).AddTicks(2317), new DateTime(1989, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "amit@exp.com", "Amit", "Male", true, null, "Kumar", "9000000003", "AQAAAAIAAYagAAAAEFe/N3/KhlBJhRfiO/C8gQMEV21/EqZQKKhogcL7PGlinXisfF3lfNWI9XNozdqm0g==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("cbaad3e8-6482-4a8b-81d4-d87e234fd361"), new DateTime(2026, 1, 5, 11, 39, 7, 895, DateTimeKind.Utc).AddTicks(4378), new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "priya@exp.com", "Priya", "Female", true, null, "Verma", "9000000002", "AQAAAAIAAYagAAAAEChXsEywZdse1tQB+hgcw65ztFKl2Sg1IUA9omGfdb6WOuUzTvb8PWPUxbiSzOA6xQ==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("e65f0884-b820-47f8-8d1e-325eb39a0b93"), new DateTime(2026, 1, 5, 11, 39, 7, 789, DateTimeKind.Utc).AddTicks(8635), new DateTime(1990, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "rahul@exp.com", "Rahul", "Male", true, null, "Sharma", "9000000001", "AQAAAAIAAYagAAAAEM3MQjGogyNO6wcipCxwK4YxykRqzGVfrQk1PcAQtsAAiy3Bl6Jnx+C2LH0XKHVMog==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") }
                });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("48216eb7-cede-45a0-b946-1059e97c0670"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("b1ae8265-2ae0-4ca3-9c06-4f3f17cee81b") },
                    { new Guid("91755a42-8055-412d-8b56-7fbbb4e33d12"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("8f72f4c0-b3c5-42bc-9c27-037e63d4669d") },
                    { new Guid("f31dea59-ae83-4cc3-9908-b5b9ddf3e177"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("c40a1bfd-05e3-458d-a47d-11efe6ff4519") }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("b7f29f56-2303-4122-b225-83310cf41659"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("a8ea41ea-cd52-4941-bed2-7087d1802fdd"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("c280c088-171a-4fa1-b335-0d8d6350277c"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("eeabfc86-e8b5-4246-8700-302d75b66ae6"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("eec0490a-0195-4b1a-b4b3-ae74b660ff92"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("633c036c-77be-4058-8089-c8ff6bbed3df"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" },
                    { new Guid("f9972994-1097-45dd-b759-31a16d813c55"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("a8ea41ea-cd52-4941-bed2-7087d1802fdd"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("381183c5-b50a-4c08-a3dd-da83ad804417"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 2, 11, 39, 8, 207, DateTimeKind.Utc).AddTicks(6859), new DateTime(2026, 2, 4, 11, 39, 8, 207, DateTimeKind.Utc).AddTicks(6859), new Guid("c280c088-171a-4fa1-b335-0d8d6350277c"), null, 5 },
                    { new Guid("7b5a6f52-264d-4a48-bea6-94c710a3e730"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 29, 11, 39, 8, 207, DateTimeKind.Utc).AddTicks(6839), new DateTime(2026, 1, 28, 11, 39, 8, 207, DateTimeKind.Utc).AddTicks(6839), new Guid("f9972994-1097-45dd-b759-31a16d813c55"), null, 2 },
                    { new Guid("f96a26d4-a0c2-4f5a-bdfd-c244b552f03d"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 26, 11, 39, 8, 207, DateTimeKind.Utc).AddTicks(6827), new DateTime(2026, 1, 25, 11, 39, 8, 207, DateTimeKind.Utc).AddTicks(6835), new Guid("b7f29f56-2303-4122-b225-83310cf41659"), null, 3 },
                    { new Guid("f96ddbc6-3b9d-4b29-bd8a-578a74b24249"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 31, 11, 39, 8, 207, DateTimeKind.Utc).AddTicks(6843), new DateTime(2026, 1, 30, 11, 39, 8, 207, DateTimeKind.Utc).AddTicks(6844), new Guid("eec0490a-0195-4b1a-b4b3-ae74b660ff92"), null, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("48216eb7-cede-45a0-b946-1059e97c0670"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("91755a42-8055-412d-8b56-7fbbb4e33d12"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("f31dea59-ae83-4cc3-9908-b5b9ddf3e177"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("381183c5-b50a-4c08-a3dd-da83ad804417"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("7b5a6f52-264d-4a48-bea6-94c710a3e730"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("f96a26d4-a0c2-4f5a-bdfd-c244b552f03d"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("f96ddbc6-3b9d-4b29-bd8a-578a74b24249"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("0f2fd736-5102-4a50-baa9-5e79dcb95dfb"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("528e547f-a378-49a3-8b9e-5c04f5c5e63e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("9900b863-3cec-4e2b-a912-87dba3aa495f"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("1e09daee-08c0-4cc4-80c2-4101af83488a"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("81bbf471-3dea-4787-baac-f92fee60cc92"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("9b27f2ea-9c24-48c9-9972-df262d9428a7"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("9b9f6302-f903-4e2f-8d51-7a537b25e689"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("b7674155-c3a6-4ff2-9bd8-ef999508e5f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("805b992a-ac42-4d3c-9e05-fcfc9549c4f7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("acb0c509-65f2-4e0c-b990-64838415b233"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("cbaad3e8-6482-4a8b-81d4-d87e234fd361"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("e65f0884-b820-47f8-8d1e-325eb39a0b93"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("b7f29f56-2303-4122-b225-83310cf41659"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("c280c088-171a-4fa1-b335-0d8d6350277c"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("eec0490a-0195-4b1a-b4b3-ae74b660ff92"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("f9972994-1097-45dd-b759-31a16d813c55"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("8f72f4c0-b3c5-42bc-9c27-037e63d4669d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("b1ae8265-2ae0-4ca3-9c06-4f3f17cee81b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("c40a1bfd-05e3-458d-a47d-11efe6ff4519"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("633c036c-77be-4058-8089-c8ff6bbed3df"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("a8ea41ea-cd52-4941-bed2-7087d1802fdd"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("eeabfc86-e8b5-4246-8700-302d75b66ae6"));

            migrationBuilder.DropColumn(
                name: "StatusNote",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "StatusUpdatedAt",
                table: "JobApplications");

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 5, 9, 47, 24, 892, DateTimeKind.Utc).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 5, 9, 47, 24, 892, DateTimeKind.Utc).AddTicks(9939));

            migrationBuilder.UpdateData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222") },
                column: "AssignedOn",
                value: new DateTime(2026, 1, 5, 9, 47, 24, 892, DateTimeKind.Utc).AddTicks(9941));

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("48041d3b-bdda-4e9b-92c1-9a5e433c263b"), "Contract" },
                    { new Guid("54398d03-25a0-498b-a0f6-f84828e7c377"), "Full-Time" },
                    { new Guid("5cf38279-2032-497c-a2fd-a1d79aec261a"), "Part-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("0378b6b2-b6e5-40f0-8d8e-a761c8c20490"), true, "C#" },
                    { new Guid("11c28dbc-65d9-469d-9237-71c361011062"), true, "ASP.NET Core" },
                    { new Guid("4ac9084e-1d6f-4dce-8d7c-ad394e3708d1"), true, "SQL Server" },
                    { new Guid("89e0eb0b-cd90-47ae-85bd-bfe3c8fe6112"), true, "React" },
                    { new Guid("90b5e3c9-bd47-4feb-81a8-de2e73b3f16f"), true, "JavaScript" },
                    { new Guid("d29ef713-fd70-4a79-836e-c05e30e1f1c3"), true, "Entity Framework Core" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("0ad5886a-2462-466e-a7f9-155e0bf4211c"), "Stack Overflow" },
                    { new Guid("3e0cde21-b550-4b68-aaff-44e8f9f337bd"), "Twitter" },
                    { new Guid("4477976a-135c-484d-bf6c-279a58b01480"), "GitHub" },
                    { new Guid("6c35d991-1aa3-4fd3-90da-a80b83dde7de"), "Portfolio" },
                    { new Guid("dab745ea-ec96-4c38-a7eb-0f35a8ee637c"), "LinkedIn" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 9, 47, 24, 153, DateTimeKind.Utc).AddTicks(1176), "AQAAAAIAAYagAAAAEMrQqTXxl+/PrtgqsTojzgucEEvelbgf66m9wh5/MjnWG4GktLfT3Ur8WZpYTyMnXg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 9, 47, 24, 56, DateTimeKind.Utc).AddTicks(4920), "AQAAAAIAAYagAAAAENDnWe5KS99Nl237S2GlJPtlkFzh9fsQqoXYMrxYdzQwzU1vC2gEQJh9yzsXsG3Yug==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 9, 47, 24, 255, DateTimeKind.Utc).AddTicks(8126), "AQAAAAIAAYagAAAAECtUg+LLlUbD1aF+qw1TyEGyCZvKuzzvTMQxzNMrQL2dOn5AlWwz8lvN8vYnK50cIQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 9, 47, 24, 364, DateTimeKind.Utc).AddTicks(1576), "AQAAAAIAAYagAAAAEIIgYyWXK5DLybEOuLtBh7KzD79Hn/eB9Qf0w75477fYwBzN52x+5udSVuou3pPpUg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"),
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 5, 9, 47, 23, 952, DateTimeKind.Utc).AddTicks(4414), "AQAAAAIAAYagAAAAEPAcJIedh+IlQzN7UgQ1KUQoDfVfMXay6EyU6rhfMRa+XqwQFEOfrGYyCeTBnumzqg==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "DOB", "Email", "Fname", "Gender", "IsActive", "LastLogin", "Lname", "MobileNumber", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "UserTypeId" },
                values: new object[,]
                {
                    { new Guid("62fbaf51-83b1-4726-8f15-f955fae67d28"), new DateTime(2026, 1, 5, 9, 47, 24, 786, DateTimeKind.Utc).AddTicks(9313), new DateTime(1994, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "sneha@exp.com", "Sneha", "Female", true, null, "Reddy", "9000000004", "AQAAAAIAAYagAAAAEDI3LRDOSvqfZginMU1Cbl5OyZYXKemuL8n67ADS8tquRqCvh/Yup70oIQARzzJZkw==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("917ddbd6-7ce4-46b8-9299-746a97ab704f"), new DateTime(2026, 1, 5, 9, 47, 24, 665, DateTimeKind.Utc).AddTicks(2466), new DateTime(1989, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "amit@exp.com", "Amit", "Male", true, null, "Kumar", "9000000003", "AQAAAAIAAYagAAAAEIIWQ4MXCn8+aigUonDyrbeiZwUFap+0WXHuw2kL7tBYqR27wdmXOKalkOjuCYs5XA==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("c0b037c2-24c3-4099-b282-ff6eb59d94c9"), new DateTime(2026, 1, 5, 9, 47, 24, 457, DateTimeKind.Utc).AddTicks(6391), new DateTime(1990, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "rahul@exp.com", "Rahul", "Male", true, null, "Sharma", "9000000001", "AQAAAAIAAYagAAAAEFQfe5sLv30D0S8/npv6T7oiS43tmC1n/CaZmWVgvG/WZ0xskMYBROIIon64xOEuMg==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("fbadf689-1739-4bf9-9289-9192ef8af7c3"), new DateTime(2026, 1, 5, 9, 47, 24, 563, DateTimeKind.Utc).AddTicks(5096), new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "priya@exp.com", "Priya", "Female", true, null, "Verma", "9000000002", "AQAAAAIAAYagAAAAEOfwlJX8euXLoyNXy7ZGXGmZt0+IkjPHOPZ9h/208qHvDuAIvz2dt9jMhl+RWCdMOg==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") }
                });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("5b0e6bae-ed29-4a3f-93a3-33af2f86d341"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("0378b6b2-b6e5-40f0-8d8e-a761c8c20490") },
                    { new Guid("a3f6125e-78f2-493c-a24c-b4b8fc4cbb11"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("11c28dbc-65d9-469d-9237-71c361011062") },
                    { new Guid("b57e0fee-b0b5-4c6d-b804-5c8549f8301c"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), null, null, new Guid("89e0eb0b-cd90-47ae-85bd-bfe3c8fe6112") }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("07ca700e-e44c-43ef-bb86-590fc3b317b0"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("54398d03-25a0-498b-a0f6-f84828e7c377"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" },
                    { new Guid("5fae42f9-731a-4255-a360-5459be157b88"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("5cf38279-2032-497c-a2fd-a1d79aec261a"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("940710b6-75c2-442c-bcc6-ebbb232d551a"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("54398d03-25a0-498b-a0f6-f84828e7c377"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("b2bdde44-b6ee-4766-bfb9-6238066cec70"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("48041d3b-bdda-4e9b-92c1-9a5e433c263b"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("3e521942-18fa-4ae8-9904-dae472de97ed"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 29, 9, 47, 24, 894, DateTimeKind.Utc).AddTicks(9617), new DateTime(2026, 1, 28, 9, 47, 24, 894, DateTimeKind.Utc).AddTicks(9617), new Guid("07ca700e-e44c-43ef-bb86-590fc3b317b0"), null, 2 },
                    { new Guid("4f934501-1cbd-4eb9-be73-d5d93d4b9a84"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 31, 9, 47, 24, 894, DateTimeKind.Utc).AddTicks(9621), new DateTime(2026, 1, 30, 9, 47, 24, 894, DateTimeKind.Utc).AddTicks(9621), new Guid("b2bdde44-b6ee-4766-bfb9-6238066cec70"), null, 1 },
                    { new Guid("808a20bc-31b4-4f2f-8e6a-7d8b5e4cd00b"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 2, 9, 47, 24, 894, DateTimeKind.Utc).AddTicks(9624), new DateTime(2026, 2, 4, 9, 47, 24, 894, DateTimeKind.Utc).AddTicks(9625), new Guid("5fae42f9-731a-4255-a360-5459be157b88"), null, 5 },
                    { new Guid("873721d2-c5c1-43b5-bad8-66aa516f03b1"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 26, 9, 47, 24, 894, DateTimeKind.Utc).AddTicks(9606), new DateTime(2026, 1, 25, 9, 47, 24, 894, DateTimeKind.Utc).AddTicks(9613), new Guid("940710b6-75c2-442c-bcc6-ebbb232d551a"), null, 3 }
                });
        }
    }
}
