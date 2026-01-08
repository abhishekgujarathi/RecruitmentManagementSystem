using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class removeallseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedReviewers_Users_Uid",
                table: "AssignedReviewers");

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("074cc6c8-637b-4639-b22c-b80a210a9778"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("18d0c154-5983-4a60-b09d-8fe456742a56"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("222db577-d2d0-4eec-aa42-6263e4e5da76"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("2e4bf4c2-e1b0-4c85-b28e-4f79734a1234"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("372935c5-e750-4c8d-a307-f8b51b038347"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("3fb2b7a0-a492-4ce7-b45d-0a69a1ab3bef"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("64f4420e-1c32-4461-85a8-2c4c9341588b"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("65a4485d-1e04-4a91-b749-e639f1ad6c93"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("82036566-cd6f-4e42-af17-6e83d2ea5854"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("a4823745-470b-49d0-a34f-872229e00184"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("b71362e2-d04d-4000-bc48-603fe801ffba"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("c47f3e8f-a1c9-4298-ac93-9784f64b38dd"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("cef361e0-7e46-4ae5-b6bc-a4ef8ad0d71d"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("d4aaa9dc-cf7d-4662-8d82-9ad4b22baf24"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("e90b2759-00bf-432a-972d-e005782ad34c"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("ed2623d9-8a24-48c1-925e-05655e56379e"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("fcda6750-e3cf-4548-a043-f3d2d3a286e0"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("0552abcc-db6f-49ad-add1-4b224afecd1d"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("64064824-6411-439d-b3fe-cbc2fe60c39d"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("7fd7af50-00fd-4884-823a-dea1a58bc3a6"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("968972b5-2b03-4be3-8664-03f65d179fa1"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("a176e36e-022d-41eb-bfa1-aeee65fc1aff"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("c7649386-3789-47cf-ac64-eced1122797d"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("f906bb36-5f31-4029-aa23-df70a2e24b38"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: new Guid("17293e17-f196-4fbc-8b77-3c720d3e62f4"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: new Guid("26490411-25df-460e-89f2-9ddff9196a7e"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: new Guid("3c802d7b-bbca-40e4-a96c-a508824249d8"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: new Guid("b3f2c0e1-6f2a-4a6c-9f8a-1a2b3c4d5e01"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: new Guid("c4d3f1a2-7b3c-4d8e-9a0b-2c3d4e5f6a02"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: new Guid("e5ba47e9-d283-4742-ba40-034916da8c17"));

            migrationBuilder.DeleteData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a") });

            migrationBuilder.DeleteData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111") });

            migrationBuilder.DeleteData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "EmployeeRoleId", "UserId" },
                keyValues: new object[] { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222") });

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("1707a597-c901-44c1-a4b8-1596ee8bc2dd"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("3d2b65d7-be01-4045-a93e-b5ce34f02cb5"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("c1d1c8b4-881f-4cdb-a8ed-2f97f652e792"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("d5e4f3b2-8c4d-4e9f-0a1b-3c4d5e6f7a03"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("defbc4eb-bb4f-4549-a64a-4185863c4bcc"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("e6f5a4c3-9d5e-4f0a-1b2c-4d5e6f7a8b04"));

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "JobApplicationId",
                keyValue: new Guid("96637b5d-61b1-45e0-8813-38dd76f0b8a2"));

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "JobApplicationId",
                keyValue: new Guid("a7a32744-a9be-4d15-9410-0b44d3b959d5"));

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "JobApplicationId",
                keyValue: new Guid("d61d7f07-8593-409c-bbeb-fcd63263157c"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("20928977-ee64-4974-b67d-5893382521a0"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("249edd52-4bfe-4528-8ac3-9fbea5c11bdc"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("38e9f232-1480-45f2-9e32-2a8c044bd4d8"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("41204854-f400-4527-8722-ab1e5cc3a157"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("4cbbafc5-8ab0-4bd1-ae3b-5dfc34ff6a0a"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("5382c6f9-464d-4d2c-a082-aaaf6d766434"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("59623389-6c75-41f2-b953-c7730dfaca2a"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("7f47b809-2a0e-47ee-956d-61183c4da696"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("a89f2847-1f1a-4b5d-93f5-a81cc7aabee6"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("ba158853-30e2-46d6-ba8a-d56f223e4cdf"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("c7f6645e-ef61-450f-aa5e-bddb77be5d85"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("ce18b342-3429-4198-8532-dc162d4f36f1"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("cfa5265f-6908-43f1-a15c-ce5d146315cd"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("d24ce563-8785-4021-b572-fd5bc68a1fd9"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("d5863eb1-3129-4789-bee7-7a993726e596"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("ef7540f6-c9e0-4aec-a561-d8f1a5eca99f"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("ef99ecc6-b6b4-4510-a5cc-be9b250c892f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("92dc292b-9df8-419a-8424-8939f94f3c98"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("c21098f7-038e-466c-967d-2c64189c27e6"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("077827b9-1561-471d-8a02-455d46d415f4"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("ea5b4b2a-070c-45d8-8a6b-383e98d669d6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("07253644-addb-48db-be8d-0164e41586dd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("1e89c149-5c9f-4492-b55d-60bf897da9ae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("9b3048b1-3024-45b0-bb1a-4d29bda2f32b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("db13c8ce-7469-4b70-89ad-4bf0a637d78c"));

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "CandidateProfileId",
                keyValue: new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"));

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "CandidateProfileId",
                keyValue: new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"));

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "CandidateProfileId",
                keyValue: new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"));

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumn: "EmployeeRoleId",
                keyValue: new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"));

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumn: "EmployeeRoleId",
                keyValue: new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"));

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumn: "EmployeeRoleId",
                keyValue: new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("15697654-2e8e-412b-b35e-8226cf911237"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("03d86258-cd7e-467f-87cb-09609d38571b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("068ad609-d1cf-4945-aaf1-1914d10402ed"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("07a14cde-7266-405a-9fa8-8a71554c7868"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("1798cda1-f1ef-45e6-9bbc-e9ca5970c5c0"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("355e3b35-1706-480c-b5ab-6be7707b49e0"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("40624a3a-30ff-47db-8084-c54aa5487d2e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("43ff8410-b479-4846-956a-df3c56ffd882"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("4c487bbc-6fa9-4643-9d9e-a88e5bea917e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("4ee9ab25-f239-42dd-93e9-203749c9a8a7"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("64b7e1de-546e-47b0-a15b-85364d11037d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("67ddb3fd-f7ce-4797-af87-9a6842e6d2ef"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("79891c3c-4052-4206-b2ef-a7608bb093a1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("8b6c6882-ccc8-435f-b991-50e6d47bc9e9"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("b4c75a72-9a14-4c89-94e3-5ebdfd5c04d6"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("b88a8be0-fc87-4713-a9c1-abc02a1be5f5"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("c46102bc-1749-43bf-b1a5-c5a31827b346"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("cc858b5f-73d0-4933-880d-3ca36cdfd2c6"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("d161a587-31d4-45ea-a184-80495bdf6895"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("0b516f73-50c5-422f-948c-8da253849b27"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("50bdf779-682c-4625-8c54-9859d7d7a0e6"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("9cb27dd8-5cd0-4092-ba45-e0b5bdcfbd12"));

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
                keyValue: new Guid("2faf5007-a266-49d4-8c97-dc5790b45dae"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("79ce823e-e1f1-452b-b485-4e8268c18f75"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("9e0ff7b6-48fd-4a0b-acf7-ab19e6586563"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("a6aa2872-4447-48e2-86f0-7fb51bb78f37"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0f159347-5847-4449-ad7e-8b604ac5a9ac"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("4603558e-87ae-4fea-88c4-9f5c2e188f5e"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("09c3576e-2b5e-4973-9dea-c6485b8a733a"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("6ee1eb42-f820-4b07-8e5b-21aada900f71"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("bec262d6-f5d8-44c6-b80a-20699c3012a2"));

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeId",
                keyValue: new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e"));

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeId",
                keyValue: new Guid("e91d74b9-67cb-41b5-9581-338a64a45122"));

            migrationBuilder.RenameColumn(
                name: "Uid",
                table: "AssignedReviewers",
                newName: "ReviewerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedReviewers_Uid",
                table: "AssignedReviewers",
                newName: "IX_AssignedReviewers_ReviewerUserId");

            migrationBuilder.AddColumn<bool>(
                name: "DefaultInterviewRoundsDefined",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DefaultReviewersAssigned",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusUpdatedAt",
                table: "JobApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentStatus",
                table: "JobApplications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationInterviewRounds",
                columns: table => new
                {
                    ApplicationInterviewRoundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false),
                    RoundType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationInterviewRounds", x => x.ApplicationInterviewRoundId);
                    table.ForeignKey(
                        name: "FK_ApplicationInterviewRounds_JobApplications_JobApplicationId",
                        column: x => x.JobApplicationId,
                        principalTable: "JobApplications",
                        principalColumn: "JobApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobInterviewRounds",
                columns: table => new
                {
                    JobInterviewRoundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false),
                    RoundType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInterviewRounds", x => x.JobInterviewRoundId);
                    table.ForeignKey(
                        name: "FK_JobInterviewRounds_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewPanelMembers",
                columns: table => new
                {
                    InterviewPanelMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationInterviewRoundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewPanelMembers", x => x.InterviewPanelMemberId);
                    table.ForeignKey(
                        name: "FK_InterviewPanelMembers_ApplicationInterviewRounds_ApplicationInterviewRoundId",
                        column: x => x.ApplicationInterviewRoundId,
                        principalTable: "ApplicationInterviewRounds",
                        principalColumn: "ApplicationInterviewRoundId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewPanelMembers_Users_AssignedByUserId",
                        column: x => x.AssignedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterviewPanelMembers_Users_InterviewerId",
                        column: x => x.InterviewerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationInterviewRounds_JobApplicationId",
                table: "ApplicationInterviewRounds",
                column: "JobApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewPanelMembers_ApplicationInterviewRoundId",
                table: "InterviewPanelMembers",
                column: "ApplicationInterviewRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewPanelMembers_AssignedByUserId",
                table: "InterviewPanelMembers",
                column: "AssignedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewPanelMembers_InterviewerId",
                table: "InterviewPanelMembers",
                column: "InterviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInterviewRounds_JobId",
                table: "JobInterviewRounds",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedReviewers_Users_ReviewerUserId",
                table: "AssignedReviewers",
                column: "ReviewerUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedReviewers_Users_ReviewerUserId",
                table: "AssignedReviewers");

            migrationBuilder.DropTable(
                name: "InterviewPanelMembers");

            migrationBuilder.DropTable(
                name: "JobInterviewRounds");

            migrationBuilder.DropTable(
                name: "ApplicationInterviewRounds");

            migrationBuilder.DropColumn(
                name: "DefaultInterviewRoundsDefined",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DefaultReviewersAssigned",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "ReviewerUserId",
                table: "AssignedReviewers",
                newName: "Uid");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedReviewers_ReviewerUserId",
                table: "AssignedReviewers",
                newName: "IX_AssignedReviewers_Uid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusUpdatedAt",
                table: "JobApplications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentStatus",
                table: "JobApplications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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
                    { new Guid("09c3576e-2b5e-4973-9dea-c6485b8a733a"), "Contract" },
                    { new Guid("6ee1eb42-f820-4b07-8e5b-21aada900f71"), "Full-Time" },
                    { new Guid("bec262d6-f5d8-44c6-b80a-20699c3012a2"), "Part-Time" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("03d86258-cd7e-467f-87cb-09609d38571b"), true, "REST API" },
                    { new Guid("068ad609-d1cf-4945-aaf1-1914d10402ed"), true, "Kubernetes" },
                    { new Guid("07a14cde-7266-405a-9fa8-8a71554c7868"), true, "JavaScript" },
                    { new Guid("1798cda1-f1ef-45e6-9bbc-e9ca5970c5c0"), true, "React" },
                    { new Guid("355e3b35-1706-480c-b5ab-6be7707b49e0"), true, "Entity Framework Core" },
                    { new Guid("40624a3a-30ff-47db-8084-c54aa5487d2e"), true, "Node.js" },
                    { new Guid("43ff8410-b479-4846-956a-df3c56ffd882"), true, "C#" },
                    { new Guid("4c487bbc-6fa9-4643-9d9e-a88e5bea917e"), true, "Python" },
                    { new Guid("4ee9ab25-f239-42dd-93e9-203749c9a8a7"), true, "AWS" },
                    { new Guid("64b7e1de-546e-47b0-a15b-85364d11037d"), true, "Angular" },
                    { new Guid("67ddb3fd-f7ce-4797-af87-9a6842e6d2ef"), true, "MongoDB" },
                    { new Guid("79891c3c-4052-4206-b2ef-a7608bb093a1"), true, "Jenkins" },
                    { new Guid("8b6c6882-ccc8-435f-b991-50e6d47bc9e9"), true, "Git" },
                    { new Guid("92dc292b-9df8-419a-8424-8939f94f3c98"), true, "Java" },
                    { new Guid("b4c75a72-9a14-4c89-94e3-5ebdfd5c04d6"), true, "Docker" },
                    { new Guid("b88a8be0-fc87-4713-a9c1-abc02a1be5f5"), true, "TypeScript" },
                    { new Guid("c21098f7-038e-466c-967d-2c64189c27e6"), true, "PostgreSQL" },
                    { new Guid("c46102bc-1749-43bf-b1a5-c5a31827b346"), true, "Azure" },
                    { new Guid("cc858b5f-73d0-4933-880d-3ca36cdfd2c6"), true, "ASP.NET Core" },
                    { new Guid("d161a587-31d4-45ea-a184-80495bdf6895"), true, "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("077827b9-1561-471d-8a02-455d46d415f4"), "Stack Overflow" },
                    { new Guid("0b516f73-50c5-422f-948c-8da253849b27"), "GitHub" },
                    { new Guid("50bdf779-682c-4625-8c54-9859d7d7a0e6"), "LinkedIn" },
                    { new Guid("9cb27dd8-5cd0-4092-ba45-e0b5bdcfbd12"), "Portfolio" },
                    { new Guid("ea5b4b2a-070c-45d8-8a6b-383e98d669d6"), "Twitter" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "TypeName", "active" },
                values: new object[,]
                {
                    { new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e"), "Employee", true },
                    { new Guid("e91d74b9-67cb-41b5-9581-338a64a45122"), "Candidate", true }
                });

            migrationBuilder.InsertData(
                table: "JobDescriptions",
                columns: new[] { "JobDescriptionId", "Details", "JobTypeId", "Location", "MinimumExperienceReq", "Responsibilty", "Title" },
                values: new object[,]
                {
                    { new Guid("2faf5007-a266-49d4-8c97-dc5790b45dae"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("09c3576e-2b5e-4973-9dea-c6485b8a733a"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" },
                    { new Guid("79ce823e-e1f1-452b-b485-4e8268c18f75"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("bec262d6-f5d8-44c6-b80a-20699c3012a2"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("9e0ff7b6-48fd-4a0b-acf7-ab19e6586563"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("6ee1eb42-f820-4b07-8e5b-21aada900f71"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("a6aa2872-4447-48e2-86f0-7fb51bb78f37"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("6ee1eb42-f820-4b07-8e5b-21aada900f71"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "DOB", "Email", "Fname", "Gender", "IsActive", "LastLogin", "Lname", "MobileNumber", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "UserTypeId" },
                values: new object[,]
                {
                    { new Guid("07253644-addb-48db-be8d-0164e41586dd"), new DateTime(2026, 1, 6, 18, 59, 34, 637, DateTimeKind.Utc).AddTicks(7812), new DateTime(1989, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "amit@exp.com", "Amit", "Male", true, null, "Kumar", "9000000003", "AQAAAAIAAYagAAAAEIIijrT+fYCtbCtosftI8OQA/kMFnaZtyfX5w8GmeVkUD6sOlFZv7uhaq4YTCOZ9Ww==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"), new DateTime(2026, 1, 6, 18, 59, 34, 336, DateTimeKind.Utc).AddTicks(9785), new DateTime(1998, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abhi@exp.com", "Abhi", "Male", true, null, "G", "1111111111", "AQAAAAIAAYagAAAAEBRYtjrP5FdwVfLgac/2KHRVDTTrQlnQ0+smGuYGOPPzAvCQ91sTcmIew58FVVP3Xw==", null, null, new Guid("e91d74b9-67cb-41b5-9581-338a64a45122") },
                    { new Guid("0f159347-5847-4449-ad7e-8b604ac5a9ac"), new DateTime(2025, 9, 6, 18, 59, 34, 240, DateTimeKind.Utc).AddTicks(1043), new DateTime(1997, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "rajesh.kumar@email.com", "Rajesh", "Male", true, null, "Kumar", "9876543211", "AQAAAAIAAYagAAAAEJluFJ1RsMEpEsdEjWddVFa0fGe5d6YLZvpsnK4XY1kK2YEDIMvQOgyXBTVF2Sab1g==", null, null, new Guid("e91d74b9-67cb-41b5-9581-338a64a45122") },
                    { new Guid("1e89c149-5c9f-4492-b55d-60bf897da9ae"), new DateTime(2026, 1, 6, 18, 59, 34, 730, DateTimeKind.Utc).AddTicks(5546), new DateTime(1994, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "sneha@exp.com", "Sneha", "Female", true, null, "Reddy", "9000000004", "AQAAAAIAAYagAAAAEKToU1R1kuAyk8OEdFVbisuaBxTWKBE2Z4vHPsMQ43IgjW05J1ezixxJGATitu3kfQ==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 6, 18, 59, 33, 838, DateTimeKind.Utc).AddTicks(5707), new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "peter@exp.com", "Peter", "Male", true, null, "Parker", "0987654321", "AQAAAAIAAYagAAAAEErV+1lKS7JC/bTUNWjLEUf7pSdqPvT5eTodRatkRtZMRPMdhVrJKLC272cY8LlhdA==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("4603558e-87ae-4fea-88c4-9f5c2e188f5e"), new DateTime(2025, 7, 6, 18, 59, 34, 134, DateTimeKind.Utc).AddTicks(2457), new DateTime(1995, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "priya.sharma@email.com", "Priya", "Female", true, null, "Sharma", "9876543210", "AQAAAAIAAYagAAAAEMbeUjC0/QUFpfv7JR2Lwnvt0/LwcqCyv+zec9UNt8yJ2Qd7roopkhsTLVaguC96yg==", null, null, new Guid("e91d74b9-67cb-41b5-9581-338a64a45122") },
                    { new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"), new DateTime(2026, 1, 6, 18, 59, 33, 934, DateTimeKind.Utc).AddTicks(8180), new DateTime(1992, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "reviewer@exp.com", "Bruce", "Male", true, null, "Wayne", "2222222222", "AQAAAAIAAYagAAAAENDrQKkjIeR1TUWCBfEBALzc5g1yHlxGVnzF04Cbsb/Od9KBm2NT4jcBHEEyI/BTIA==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"), new DateTime(2026, 1, 6, 18, 59, 34, 35, DateTimeKind.Utc).AddTicks(5188), new DateTime(1988, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "interviewer@exp.com", "Tony", "Male", true, null, "Stark", "3333333333", "AQAAAAIAAYagAAAAECS8Il7ciZEwHbamBQplioE3KwETYAX20XfVcIVJdRBNGM1tDdVnW39gV17uPgwZzQ==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("9b3048b1-3024-45b0-bb1a-4d29bda2f32b"), new DateTime(2026, 1, 6, 18, 59, 34, 438, DateTimeKind.Utc).AddTicks(7313), new DateTime(1990, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "rahul@exp.com", "Rahul", "Male", true, null, "Sharma", "9000000001", "AQAAAAIAAYagAAAAEGHWEje0UKqDqjpzfdI0ZY21os3UYXKCHLY1Mzk8XIcR2neEDAI6hdtbm+BjzU7V7Q==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"), new DateTime(2026, 1, 6, 18, 59, 33, 745, DateTimeKind.Utc).AddTicks(1076), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@exp.com", "Admin", "Male", true, null, "User", "1234567890", "AQAAAAIAAYagAAAAEOkSIsZwPzqqRRPBPdlBrKwKDgJxubmvGLkrO2NJzZ42v3YnVTCpEiSvArDbu8tvHw==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("db13c8ce-7469-4b70-89ad-4bf0a637d78c"), new DateTime(2026, 1, 6, 18, 59, 34, 539, DateTimeKind.Utc).AddTicks(8740), new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "priya@exp.com", "Priya", "Female", true, null, "Verma", "9000000002", "AQAAAAIAAYagAAAAECLssCEtq6FqaWdW4eYMRRrrX+6sje27nKk8c8W2GG4e+VJUPDy2iHpig9/6QdKKtw==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") }
                });

            migrationBuilder.InsertData(
                table: "CandidateProfiles",
                columns: new[] { "CandidateProfileId", "Address", "City", "Country", "PostalCode", "State", "UserId" },
                values: new object[,]
                {
                    { new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "123 Main Street, Apartment 4B", "Mumbai", "India", "400001", "Maharashtra", new Guid("0a33c200-c9f2-4547-810a-b3337a72d733") },
                    { new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), "A-304, Sunrise Apartments, Koramangala", "Bangalore", "India", "560034", "Karnataka", new Guid("4603558e-87ae-4fea-88c4-9f5c2e188f5e") },
                    { new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), "B-12, Green Valley Society, Bandra West", "Mumbai", "India", "400050", "Maharashtra", new Guid("0f159347-5847-4449-ad7e-8b604ac5a9ac") }
                });

            migrationBuilder.InsertData(
                table: "EmployeeUserRoles",
                columns: new[] { "EmployeeRoleId", "UserId", "AssignedOn" },
                values: new object[,]
                {
                    { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 6, 18, 59, 34, 825, DateTimeKind.Utc).AddTicks(412) },
                    { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"), new DateTime(2026, 1, 6, 18, 59, 34, 825, DateTimeKind.Utc).AddTicks(415) },
                    { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"), new DateTime(2026, 1, 6, 18, 59, 34, 825, DateTimeKind.Utc).AddTicks(417) }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("15697654-2e8e-412b-b35e-8226cf911237"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 3, 18, 59, 34, 826, DateTimeKind.Utc).AddTicks(6229), new DateTime(2026, 2, 5, 18, 59, 34, 826, DateTimeKind.Utc).AddTicks(6229), new Guid("79ce823e-e1f1-452b-b485-4e8268c18f75"), null, 5 },
                    { new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 27, 18, 59, 34, 826, DateTimeKind.Utc).AddTicks(6205), new DateTime(2026, 1, 26, 18, 59, 34, 826, DateTimeKind.Utc).AddTicks(6215), new Guid("9e0ff7b6-48fd-4a0b-acf7-ab19e6586563"), null, 3 },
                    { new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 30, 18, 59, 34, 826, DateTimeKind.Utc).AddTicks(6217), new DateTime(2026, 1, 29, 18, 59, 34, 826, DateTimeKind.Utc).AddTicks(6218), new Guid("a6aa2872-4447-48e2-86f0-7fb51bb78f37"), null, 2 },
                    { new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 1, 18, 59, 34, 826, DateTimeKind.Utc).AddTicks(6221), new DateTime(2026, 1, 31, 18, 59, 34, 826, DateTimeKind.Utc).AddTicks(6226), new Guid("2faf5007-a266-49d4-8c97-dc5790b45dae"), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("074cc6c8-637b-4639-b22c-b80a210a9778"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), 3m, "Advanced", new Guid("b88a8be0-fc87-4713-a9c1-abc02a1be5f5") },
                    { new Guid("18d0c154-5983-4a60-b09d-8fe456742a56"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), 6m, "Expert", new Guid("43ff8410-b479-4846-956a-df3c56ffd882") },
                    { new Guid("222db577-d2d0-4eec-aa42-6263e4e5da76"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), 5m, "Advanced", new Guid("07a14cde-7266-405a-9fa8-8a71554c7868") },
                    { new Guid("2e4bf4c2-e1b0-4c85-b28e-4f79734a1234"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), 2m, "Intermediate", new Guid("40624a3a-30ff-47db-8084-c54aa5487d2e") },
                    { new Guid("372935c5-e750-4c8d-a307-f8b51b038347"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), 6m, "Advanced", new Guid("d161a587-31d4-45ea-a184-80495bdf6895") },
                    { new Guid("3fb2b7a0-a492-4ce7-b45d-0a69a1ab3bef"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), 5m, "Beginner", new Guid("43ff8410-b479-4846-956a-df3c56ffd882") },
                    { new Guid("64f4420e-1c32-4461-85a8-2c4c9341588b"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), 4m, "Advanced", new Guid("355e3b35-1706-480c-b5ab-6be7707b49e0") },
                    { new Guid("65a4485d-1e04-4a91-b749-e639f1ad6c93"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), 4m, "Beginner", new Guid("d161a587-31d4-45ea-a184-80495bdf6895") },
                    { new Guid("82036566-cd6f-4e42-af17-6e83d2ea5854"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), 4m, "Advanced", new Guid("1798cda1-f1ef-45e6-9bbc-e9ca5970c5c0") },
                    { new Guid("a4823745-470b-49d0-a34f-872229e00184"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), 2m, "Beginner", new Guid("c46102bc-1749-43bf-b1a5-c5a31827b346") },
                    { new Guid("b71362e2-d04d-4000-bc48-603fe801ffba"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), 5m, "Advanced", new Guid("03d86258-cd7e-467f-87cb-09609d38571b") },
                    { new Guid("c47f3e8f-a1c9-4298-ac93-9784f64b38dd"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), 5m, "Beginner", new Guid("1798cda1-f1ef-45e6-9bbc-e9ca5970c5c0") },
                    { new Guid("cef361e0-7e46-4ae5-b6bc-a4ef8ad0d71d"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), 4m, "Beginner", new Guid("cc858b5f-73d0-4933-880d-3ca36cdfd2c6") },
                    { new Guid("d4aaa9dc-cf7d-4662-8d82-9ad4b22baf24"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), 3m, "Intermediate", new Guid("64b7e1de-546e-47b0-a15b-85364d11037d") },
                    { new Guid("e90b2759-00bf-432a-972d-e005782ad34c"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), 5m, "Advanced", new Guid("cc858b5f-73d0-4933-880d-3ca36cdfd2c6") },
                    { new Guid("ed2623d9-8a24-48c1-925e-05655e56379e"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), 3m, "Beginner", new Guid("b88a8be0-fc87-4713-a9c1-abc02a1be5f5") },
                    { new Guid("fcda6750-e3cf-4548-a043-f3d2d3a286e0"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), 4m, "Intermediate", new Guid("8b6c6882-ccc8-435f-b991-50e6d47bc9e9") }
                });

            migrationBuilder.InsertData(
                table: "CandidateSocials",
                columns: new[] { "CandidateSocialsId", "CandidateProfileId", "Link", "SocialPlatformId" },
                values: new object[,]
                {
                    { new Guid("0552abcc-db6f-49ad-add1-4b224afecd1d"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), "https://linkedin.com/in/priya-sharma-dev", new Guid("50bdf779-682c-4625-8c54-9859d7d7a0e6") },
                    { new Guid("64064824-6411-439d-b3fe-cbc2fe60c39d"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), "https://github.com/rajeshkumar-dev", new Guid("0b516f73-50c5-422f-948c-8da253849b27") },
                    { new Guid("7fd7af50-00fd-4884-823a-dea1a58bc3a6"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "https://linkedin.com/in/test-user", new Guid("50bdf779-682c-4625-8c54-9859d7d7a0e6") },
                    { new Guid("968972b5-2b03-4be3-8664-03f65d179fa1"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), "https://linkedin.com/in/rajesh-kumar-frontend", new Guid("50bdf779-682c-4625-8c54-9859d7d7a0e6") },
                    { new Guid("a176e36e-022d-41eb-bfa1-aeee65fc1aff"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), "https://rajeshkumar.dev", new Guid("9cb27dd8-5cd0-4092-ba45-e0b5bdcfbd12") },
                    { new Guid("c7649386-3789-47cf-ac64-eced1122797d"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), "https://github.com/priyasharma", new Guid("0b516f73-50c5-422f-948c-8da253849b27") },
                    { new Guid("f906bb36-5f31-4029-aa23-df70a2e24b38"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "https://github.com/testuser", new Guid("0b516f73-50c5-422f-948c-8da253849b27") }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "CandidateProfileId", "DegreeType", "EndDate", "FieldOfStudy", "InstituteName", "IsCurrent", "PercentageScore", "StartDate" },
                values: new object[,]
                {
                    { new Guid("17293e17-f196-4fbc-8b77-3c720d3e62f4"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), "HSC (12th)", new DateTime(2015, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Science", "St. Xavier's High School, Mumbai", false, 81.50m, new DateTime(2013, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26490411-25df-460e-89f2-9ddff9196a7e"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), "12th Grade", new DateTime(2013, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Science (PCMC)", "National Public School, Bangalore", false, 89.00m, new DateTime(2011, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c802d7b-bbca-40e4-a96c-a508824249d8"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), "B.E", new DateTime(2017, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science and Engineering", "RV College of Engineering, Bangalore", false, 82.50m, new DateTime(2013, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3f2c0e1-6f2a-4a6c-9f8a-1a2b3c4d5e01"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "B.Tech", new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "St. Xavier's College, Mumbai", false, 78.45m, new DateTime(2016, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4d3f1a2-7b3c-4d8e-9a0b-2c3d4e5f6a02"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "Higher Secondary (12th)", new DateTime(2016, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Science", "Mumbai Central Higher Secondary School", false, 86.20m, new DateTime(2014, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5ba47e9-d283-4742-ba40-034916da8c17"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), "B.Tech", new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", "Mumbai University - DJ Sanghvi College", false, 75.20m, new DateTime(2015, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "ExperienceId", "CandidateProfileId", "CompanyName", "DurationYears", "EndDate", "IsCurrent", "JobDescription", "Position", "StartDate" },
                values: new object[,]
                {
                    { new Guid("1707a597-c901-44c1-a4b8-1596ee8bc2dd"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), "Cognizant", 1.50m, new DateTime(2021, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Worked on client projects using HTML, CSS, JavaScript, and basic React. Fixed bugs, implemented new features, and learned modern frontend development practices.", "Junior Frontend Developer", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d2b65d7-be01-4045-a93e-b5ce34f02cb5"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), "Infosys Technologies Ltd", 3.50m, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Led a team of 4 developers in building enterprise applications using .NET Core and Angular. Implemented microservices architecture, optimized database queries, and mentored junior developers.", "Senior Software Engineer", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1d1c8b4-881f-4cdb-a8ed-2f97f652e792"), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), "TCS Digital", 3.00m, new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Developed and maintained web applications using ASP.NET MVC and SQL Server. Participated in code reviews, unit testing, and agile ceremonies.", "Software Developer", new DateTime(2017, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5e4f3b2-8c4d-4e9f-0a1b-3c4d5e6f7a03"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "InnoTech Solutions Pvt. Ltd.", 2.50m, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Worked on backend APIs using .NET Core, implemented authentication and REST endpoints, wrote unit tests and integrated CI/CD pipelines.", "Software Engineer", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("defbc4eb-bb4f-4549-a64a-4185863c4bcc"), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), "Wipro Digital", 2.50m, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Built responsive web applications using React, Redux, and TypeScript. Collaborated with UX designers and backend teams to deliver pixel-perfect interfaces. Improved page load times by 40%.", "Frontend Developer", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6f5a4c3-9d5e-4f0a-1b2c-4d5e6f7a8b04"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "QuickStart Internships", 0.50m, new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Assisted in developing small features, bug fixes and wrote documentation. Gained exposure to agile practices.", "Software Intern", new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "JobApplicationId", "ApplicationDate", "CandidateProfileId", "CurrentStatus", "JobId", "StatusNote", "StatusUpdatedAt" },
                values: new object[,]
                {
                    { new Guid("96637b5d-61b1-45e0-8813-38dd76f0b8a2"), new DateTime(2025, 12, 30, 18, 59, 34, 828, DateTimeKind.Utc).AddTicks(6241), new Guid("984e06f1-bb17-4bd9-a8ad-6cee04841e8f"), "Applied", new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), null, new DateTime(2025, 12, 30, 18, 59, 34, 828, DateTimeKind.Utc).AddTicks(6242) },
                    { new Guid("a7a32744-a9be-4d15-9410-0b44d3b959d5"), new DateTime(2025, 12, 29, 18, 59, 34, 828, DateTimeKind.Utc).AddTicks(6191), new Guid("67bfaed4-2f6b-4dbc-aa3e-6d257300d72c"), "Applied", new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), null, new DateTime(2025, 12, 29, 18, 59, 34, 828, DateTimeKind.Utc).AddTicks(6196) },
                    { new Guid("d61d7f07-8593-409c-bbeb-fcd63263157c"), new DateTime(2025, 12, 31, 18, 59, 34, 828, DateTimeKind.Utc).AddTicks(6270), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "Applied", new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), "Application received", new DateTime(2025, 12, 31, 18, 59, 34, 828, DateTimeKind.Utc).AddTicks(6272) }
                });

            migrationBuilder.InsertData(
                table: "JobSkills",
                columns: new[] { "JobSkillId", "JobId", "MinExperienceYears", "SkillId" },
                values: new object[,]
                {
                    { new Guid("20928977-ee64-4974-b67d-5893382521a0"), new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 4, new Guid("cc858b5f-73d0-4933-880d-3ca36cdfd2c6") },
                    { new Guid("249edd52-4bfe-4528-8ac3-9fbea5c11bdc"), new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 5, new Guid("43ff8410-b479-4846-956a-df3c56ffd882") },
                    { new Guid("38e9f232-1480-45f2-9e32-2a8c044bd4d8"), new Guid("15697654-2e8e-412b-b35e-8226cf911237"), 0, new Guid("8b6c6882-ccc8-435f-b991-50e6d47bc9e9") },
                    { new Guid("41204854-f400-4527-8722-ab1e5cc3a157"), new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), 3, new Guid("b4c75a72-9a14-4c89-94e3-5ebdfd5c04d6") },
                    { new Guid("4cbbafc5-8ab0-4bd1-ae3b-5dfc34ff6a0a"), new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), 3, new Guid("07a14cde-7266-405a-9fa8-8a71554c7868") },
                    { new Guid("5382c6f9-464d-4d2c-a082-aaaf6d766434"), new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), 2, new Guid("068ad609-d1cf-4945-aaf1-1914d10402ed") },
                    { new Guid("59623389-6c75-41f2-b953-c7730dfaca2a"), new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 4, new Guid("03d86258-cd7e-467f-87cb-09609d38571b") },
                    { new Guid("7f47b809-2a0e-47ee-956d-61183c4da696"), new Guid("15697654-2e8e-412b-b35e-8226cf911237"), 0, new Guid("67ddb3fd-f7ce-4797-af87-9a6842e6d2ef") },
                    { new Guid("a89f2847-1f1a-4b5d-93f5-a81cc7aabee6"), new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), 3, new Guid("1798cda1-f1ef-45e6-9bbc-e9ca5970c5c0") },
                    { new Guid("ba158853-30e2-46d6-ba8a-d56f223e4cdf"), new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), 2, new Guid("8b6c6882-ccc8-435f-b991-50e6d47bc9e9") },
                    { new Guid("c7f6645e-ef61-450f-aa5e-bddb77be5d85"), new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), 4, new Guid("4ee9ab25-f239-42dd-93e9-203749c9a8a7") },
                    { new Guid("ce18b342-3429-4198-8532-dc162d4f36f1"), new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 4, new Guid("d161a587-31d4-45ea-a184-80495bdf6895") },
                    { new Guid("cfa5265f-6908-43f1-a15c-ce5d146315cd"), new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), 2, new Guid("b88a8be0-fc87-4713-a9c1-abc02a1be5f5") },
                    { new Guid("d24ce563-8785-4021-b572-fd5bc68a1fd9"), new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), 3, new Guid("8b6c6882-ccc8-435f-b991-50e6d47bc9e9") },
                    { new Guid("d5863eb1-3129-4789-bee7-7a993726e596"), new Guid("15697654-2e8e-412b-b35e-8226cf911237"), 0, new Guid("4c487bbc-6fa9-4643-9d9e-a88e5bea917e") },
                    { new Guid("ef7540f6-c9e0-4aec-a561-d8f1a5eca99f"), new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), 3, new Guid("79891c3c-4052-4206-b2ef-a7608bb093a1") },
                    { new Guid("ef99ecc6-b6b4-4510-a5cc-be9b250c892f"), new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 3, new Guid("355e3b35-1706-480c-b5ab-6be7707b49e0") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedReviewers_Users_Uid",
                table: "AssignedReviewers",
                column: "Uid",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
