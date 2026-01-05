using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class dummyEmployeesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
