using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class splitSeedingCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationSkills_Skills_SkillId",
                table: "ApplicationSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_CandidateProfiles_CandidateProfileId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Jobs_JobId",
                table: "JobApplications");

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("067be206-7456-4c11-8c24-2a3fdebab7f8"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("272e9202-e704-4abd-af25-9d995ff2e61e"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("275d0b0e-6d60-4c3a-ab77-1edfeff21a32"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("40e578a5-9408-4da2-b7d1-2618ee444ad1"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("664ecdbe-1a9e-4a56-a72e-3e1d122646ee"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("87c5a754-821a-45af-a793-3d636f0ad9d4"));

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumn: "CandidateSkillId",
                keyValue: new Guid("bef15313-d642-4d37-b8d2-0e5177a423c1"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("1aac2239-885b-4659-a20e-cd95dbcf10aa"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("26fb87cb-78ce-4b52-9ae3-2ba53ea874fc"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("7cff6c8c-a3ef-4950-b9c0-b64d340c0e5b"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("9e617234-950b-4669-b31a-0c009f299865"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("be97a527-e891-4a4a-8db2-b171c544216f"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("c0782ba6-8d48-45ca-bfcf-c082bfb66ed5"));

            migrationBuilder.DeleteData(
                table: "CandidateSocials",
                keyColumn: "CandidateSocialsId",
                keyValue: new Guid("f9812cae-0de3-4097-8270-5c9798c7b13d"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: new Guid("5658a065-4768-4745-aa39-6e2fbc9b5d3f"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: new Guid("5e049841-411d-4588-926e-9010f05e19b3"));

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: new Guid("a4808bab-76ec-40ce-a214-b5c7e20313be"));

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
                keyValue: new Guid("ce49424d-a625-4e59-b194-4153a0cf882d"));

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
                keyValue: new Guid("35a1d804-622a-4f0d-96aa-5dcec6509e6d"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("72860a21-dfdf-4432-b87c-3e099edc9e53"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("76aa471e-03a2-4fce-959d-94c38e88bc02"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("ccc773a8-36b8-43d0-84d7-9e4bd50ae17a"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("d5e4f3b2-8c4d-4e9f-0a1b-3c4d5e6f7a03"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: new Guid("e6f5a4c3-9d5e-4f0a-1b2c-4d5e6f7a8b04"));

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "JobApplicationId",
                keyValue: new Guid("030d361c-2b38-4fdf-badc-9e4db3029fd6"));

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "JobApplicationId",
                keyValue: new Guid("84b87be3-be72-440f-bbca-be8349477595"));

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "JobApplicationId",
                keyValue: new Guid("d9a8985e-31f8-4f3f-b2ba-80353eb85830"));

            migrationBuilder.DeleteData(
                table: "JobInterviewRounds",
                keyColumn: "JobInterviewRoundId",
                keyValue: new Guid("7cec740e-e176-4299-b690-b322be0e4550"));

            migrationBuilder.DeleteData(
                table: "JobInterviewRounds",
                keyColumn: "JobInterviewRoundId",
                keyValue: new Guid("e568248f-02f4-4f47-998b-e2ff63680ef9"));

            migrationBuilder.DeleteData(
                table: "JobInterviewRounds",
                keyColumn: "JobInterviewRoundId",
                keyValue: new Guid("e70a92b2-202b-4aee-b6ab-ef1f9678b1f2"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("015cb29d-f6b6-4083-a1aa-2436063f7097"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("204564ab-5f09-4156-b852-e0c75ab4e8a5"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("47439964-3f47-4233-a5e0-41113a3f4793"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("554a8a63-e8ec-4205-9f61-bf04f183ec80"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("5706cb4f-c47d-4702-bbe7-37066b4654aa"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("63ae3a18-a97a-47eb-9526-684b3fcadfb7"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("6b19d5c5-e470-4c50-b0f9-3b85dfe93d9c"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("711d5cb7-f06d-49f7-b8c5-6bdad400c6aa"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("75bc4b90-27d1-421a-b41d-69dac1af8455"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("8a2cba7c-77e8-4816-9ff5-f87d7e43f4b7"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("a384ecac-d7c3-426c-bf2c-1081c7839566"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("b862cb8b-4110-4618-b052-25f04e8791b9"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("c1a03393-44c2-4f48-aa7a-fb364b4f663d"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("c464e2c6-6050-4260-b203-7e1eb0e7ced9"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("d69a6744-7c00-4084-b53e-924cb685fec8"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("e7d891b0-bd82-4b3d-b061-0e0d08ad12ed"));

            migrationBuilder.DeleteData(
                table: "JobSkills",
                keyColumn: "JobSkillId",
                keyValue: new Guid("ecb67307-ce9e-42fa-9668-1c0fb320d2e6"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("92dc292b-9df8-419a-8424-8939f94f3c98"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("4272cb07-04bd-4a8b-a0cc-fc6b3ff6d9db"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("9cf3933d-2973-4340-afb8-14404c20613a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("24b407f3-f31c-4c5c-b78c-ca26a846d878"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("4633f56a-dac2-4601-89f5-220bc8782d54"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("cb7a41c2-d3e3-4aef-9f17-e4f07c234716"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f1990cb6-5bd3-44de-9c5b-e0249a796862"));

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "CandidateProfileId",
                keyValue: new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"));

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "CandidateProfileId",
                keyValue: new Guid("dcc9d83d-b11c-4336-9d33-fcc89185962b"));

            migrationBuilder.DeleteData(
                table: "CandidateProfiles",
                keyColumn: "CandidateProfileId",
                keyValue: new Guid("e1192660-3fe6-4244-a740-5c0325674394"));

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
                keyValue: new Guid("43ff8410-b479-4846-956a-df3c56ffd882"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: new Guid("4c487bbc-6fa9-4643-9d9e-a88e5bea917e"));

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
                keyValue: new Guid("333fab14-c62b-4ab7-886e-e880bab313b1"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("751a7e1c-df12-4bdc-a278-f0f7effc4e08"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("e51d1a21-66ec-4480-92e8-12aea0b34920"));

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
                keyValue: new Guid("17c3c873-e9b4-40c7-aa1e-f4a15215c2dd"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("1a116292-6aa5-41fd-bcd1-ec7122f1ade2"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("1b0c489e-b0aa-42f0-8970-5ae1d05d5aac"));

            migrationBuilder.DeleteData(
                table: "JobDescriptions",
                keyColumn: "JobDescriptionId",
                keyValue: new Guid("2419e70e-58bb-4f99-a148-6df838e294c8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("050e7b3e-092f-49ec-9672-3ece1fb4b1c0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("331a9809-54d9-43c3-883a-493e8787f97a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("73f67ee8-ef98-4a52-b6b6-9b8a693795de"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("14bed5b8-6c9c-4029-8e39-b78995af3c12"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("e6e80f02-6b06-4abf-aa82-49da5e69c2da"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("edfe6e5a-c18c-44dd-9cd0-c7f8a5b66fa3"));

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeId",
                keyValue: new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e"));

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeId",
                keyValue: new Guid("e91d74b9-67cb-41b5-9581-338a64a45122"));

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "JobTypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("2dcae4ce-edc0-4e8c-8250-addb75ed4b4b"), "Part-Time" },
                    { new Guid("56b52f5c-4231-4c97-ab5f-d614b0276a97"), "Full-Time" },
                    { new Guid("57832921-0cd2-4ef1-92e9-e59371e5a210"), "Contract" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("59819938-51e9-45f6-8b09-4e48f524f33b"), "Stack Overflow" },
                    { new Guid("5f220026-119d-49b0-bc3d-973a222b7776"), "Portfolio" },
                    { new Guid("adfc092e-ec21-46d2-81ba-b1d5fad53fb5"), "Twitter" },
                    { new Guid("bb043454-9cf5-4ca0-840f-93a1ffc758fb"), "GitHub" },
                    { new Guid("d88d5ddb-e422-465c-b7ce-c1da88f187af"), "LinkedIn" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationSkills_Skills_SkillId",
                table: "ApplicationSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_CandidateProfiles_CandidateProfileId",
                table: "JobApplications",
                column: "CandidateProfileId",
                principalTable: "CandidateProfiles",
                principalColumn: "CandidateProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Jobs_JobId",
                table: "JobApplications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationSkills_Skills_SkillId",
                table: "ApplicationSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_CandidateProfiles_CandidateProfileId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Jobs_JobId",
                table: "JobApplications");

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("2dcae4ce-edc0-4e8c-8250-addb75ed4b4b"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("56b52f5c-4231-4c97-ab5f-d614b0276a97"));

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "JobTypeId",
                keyValue: new Guid("57832921-0cd2-4ef1-92e9-e59371e5a210"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("59819938-51e9-45f6-8b09-4e48f524f33b"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("5f220026-119d-49b0-bc3d-973a222b7776"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("adfc092e-ec21-46d2-81ba-b1d5fad53fb5"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("bb043454-9cf5-4ca0-840f-93a1ffc758fb"));

            migrationBuilder.DeleteData(
                table: "SocialPlatforms",
                keyColumn: "SocialPlatformId",
                keyValue: new Guid("d88d5ddb-e422-465c-b7ce-c1da88f187af"));

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
                    { new Guid("14bed5b8-6c9c-4029-8e39-b78995af3c12"), "Full-Time" },
                    { new Guid("e6e80f02-6b06-4abf-aa82-49da5e69c2da"), "Part-Time" },
                    { new Guid("edfe6e5a-c18c-44dd-9cd0-c7f8a5b66fa3"), "Contract" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("07a14cde-7266-405a-9fa8-8a71554c7868"), true, "JavaScript" },
                    { new Guid("1798cda1-f1ef-45e6-9bbc-e9ca5970c5c0"), true, "React" },
                    { new Guid("355e3b35-1706-480c-b5ab-6be7707b49e0"), true, "Entity Framework Core" },
                    { new Guid("43ff8410-b479-4846-956a-df3c56ffd882"), true, "C#" },
                    { new Guid("4c487bbc-6fa9-4643-9d9e-a88e5bea917e"), true, "Python" },
                    { new Guid("92dc292b-9df8-419a-8424-8939f94f3c98"), true, "Java" },
                    { new Guid("cc858b5f-73d0-4933-880d-3ca36cdfd2c6"), true, "ASP.NET Core" },
                    { new Guid("d161a587-31d4-45ea-a184-80495bdf6895"), true, "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "SocialPlatforms",
                columns: new[] { "SocialPlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("333fab14-c62b-4ab7-886e-e880bab313b1"), "Portfolio" },
                    { new Guid("4272cb07-04bd-4a8b-a0cc-fc6b3ff6d9db"), "Twitter" },
                    { new Guid("751a7e1c-df12-4bdc-a278-f0f7effc4e08"), "GitHub" },
                    { new Guid("9cf3933d-2973-4340-afb8-14404c20613a"), "Stack Overflow" },
                    { new Guid("e51d1a21-66ec-4480-92e8-12aea0b34920"), "LinkedIn" }
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
                    { new Guid("17c3c873-e9b4-40c7-aa1e-f4a15215c2dd"), "We are looking for an experienced .NET developer to join our team. Must have strong C# and ASP.NET Core skills.", new Guid("14bed5b8-6c9c-4029-8e39-b78995af3c12"), "Mumbai, India", 5, "Develop and maintain web applications, code reviews, mentor junior developers", "Senior .NET Developer" },
                    { new Guid("1a116292-6aa5-41fd-bcd1-ec7122f1ade2"), "Entry-level position for fresh graduates passionate about Python and data science.", new Guid("e6e80f02-6b06-4abf-aa82-49da5e69c2da"), "Pune, India", 0, "Write clean code, learn from seniors, contribute to data pipelines", "Junior Python Developer" },
                    { new Guid("1b0c489e-b0aa-42f0-8970-5ae1d05d5aac"), "Join our frontend team to build modern web applications using React and TypeScript.", new Guid("14bed5b8-6c9c-4029-8e39-b78995af3c12"), "Bangalore, India", 3, "Build responsive UIs, optimize performance, collaborate with designers", "Frontend React Developer" },
                    { new Guid("2419e70e-58bb-4f99-a148-6df838e294c8"), "Seeking a DevOps engineer to manage our cloud infrastructure and CI/CD pipelines.", new Guid("edfe6e5a-c18c-44dd-9cd0-c7f8a5b66fa3"), "Remote", 4, "Maintain AWS infrastructure, automate deployments, monitor systems", "DevOps Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "DOB", "Email", "Fname", "Gender", "IsActive", "LastLogin", "Lname", "MobileNumber", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "UserTypeId" },
                values: new object[,]
                {
                    { new Guid("050e7b3e-092f-49ec-9672-3ece1fb4b1c0"), new DateTime(2025, 7, 7, 6, 51, 41, 118, DateTimeKind.Utc).AddTicks(14), new DateTime(1995, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "priya.sharma@email.com", "Priya", "Female", true, null, "Sharma", "9876543210", "AQAAAAIAAYagAAAAEJmQ2XbKnH6vPSZOecXP7jW3tYAMxJ83GXwE3Qlcixszvn2CKvST9xCa3PGc+Dv3sA==", null, null, new Guid("e91d74b9-67cb-41b5-9581-338a64a45122") },
                    { new Guid("0a33c200-c9f2-4547-810a-b3337a72d733"), new DateTime(2026, 1, 7, 6, 51, 41, 316, DateTimeKind.Utc).AddTicks(7691), new DateTime(1998, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abhi@exp.com", "Abhi", "Male", true, null, "G", "1111111111", "AQAAAAIAAYagAAAAENOyMaiAC5vNJPF0kbPdT2SJZS9on6Xjxqy5m26s8TIxeW0hhaajxBrjg206QJ7tuA==", null, null, new Guid("e91d74b9-67cb-41b5-9581-338a64a45122") },
                    { new Guid("24b407f3-f31c-4c5c-b78c-ca26a846d878"), new DateTime(2026, 1, 7, 6, 51, 41, 422, DateTimeKind.Utc).AddTicks(7889), new DateTime(1990, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "rahul@exp.com", "Rahul", "Male", true, null, "Sharma", "9000000001", "AQAAAAIAAYagAAAAEPyOU7384Iuuju9uqUVatPl+S3Rjp492FPqRrVYq7uMSwLXmITPbQ/w0svP/tsMrBA==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 7, 6, 51, 40, 814, DateTimeKind.Utc).AddTicks(5826), new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "peter@exp.com", "Peter", "Male", true, null, "Parker", "0987654321", "AQAAAAIAAYagAAAAELrvIzKRZexwxKRoVgSZ3G3WZvpeVVLFadF7f7+O0ZWexQT0gMOfZgoIN0ADmsDLww==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("4633f56a-dac2-4601-89f5-220bc8782d54"), new DateTime(2026, 1, 7, 6, 51, 41, 517, DateTimeKind.Utc).AddTicks(944), new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "priya@exp.com", "Priya", "Female", true, null, "Verma", "9000000002", "AQAAAAIAAYagAAAAEPphsWsw0+BHWLnXPyJ3KgUBIf75mD1yEm+TL5ahHaH04PoNYMtOuBp+MB9zgJgKvA==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("73f67ee8-ef98-4a52-b6b6-9b8a693795de"), new DateTime(2025, 9, 7, 6, 51, 41, 219, DateTimeKind.Utc).AddTicks(6584), new DateTime(1997, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "rajesh.kumar@email.com", "Rajesh", "Male", true, null, "Kumar", "9876543211", "AQAAAAIAAYagAAAAEKxSBElM6wKau4uIBv+K5mI7NKqIBis3Gb9rkMJMmBCkjoZDAok849tdbaKEWs0KIg==", null, null, new Guid("e91d74b9-67cb-41b5-9581-338a64a45122") },
                    { new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"), new DateTime(2026, 1, 7, 6, 51, 40, 913, DateTimeKind.Utc).AddTicks(3704), new DateTime(1992, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "reviewer@exp.com", "Bruce", "Male", true, null, "Wayne", "2222222222", "AQAAAAIAAYagAAAAED06tgsAywnF52MFHjLtutzqon5nbMlAsCtbSgtesJr21nRyNRbZR3WdYnG0M74LkQ==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"), new DateTime(2026, 1, 7, 6, 51, 41, 19, DateTimeKind.Utc).AddTicks(5200), new DateTime(1988, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "interviewer@exp.com", "Tony", "Male", true, null, "Stark", "3333333333", "AQAAAAIAAYagAAAAEMRUdP0Hnjhg97MMulTwxC42rDkbphJYx8Z5aDvTxE+xQEkFcA9+X0wapoGGNBW7fw==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("a01a33a1-10c5-4424-a74b-0130a086b96e"), new DateTime(2026, 1, 7, 6, 51, 40, 693, DateTimeKind.Utc).AddTicks(4863), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@exp.com", "Admin", "Male", true, null, "User", "1234567890", "AQAAAAIAAYagAAAAEPoBDRTPnukxjvAoF5MWR/p5NPfr0C1bzO+qODxj87Zh9yoKDYMrc9fug4wod1YwlQ==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("cb7a41c2-d3e3-4aef-9f17-e4f07c234716"), new DateTime(2026, 1, 7, 6, 51, 41, 615, DateTimeKind.Utc).AddTicks(9643), new DateTime(1989, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "amit@exp.com", "Amit", "Male", true, null, "Kumar", "9000000003", "AQAAAAIAAYagAAAAELAeLg+3AhAZc12s9i/xDavHL4eRe9FCsjlNOXDDAv3I3goNUfq0DJyJIxo2NJDTNQ==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") },
                    { new Guid("f1990cb6-5bd3-44de-9c5b-e0249a796862"), new DateTime(2026, 1, 7, 6, 51, 41, 708, DateTimeKind.Utc).AddTicks(2709), new DateTime(1994, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "sneha@exp.com", "Sneha", "Female", true, null, "Reddy", "9000000004", "AQAAAAIAAYagAAAAEAP18mZKTY5BNRkNywce5VcKmTZoDqN6xHIeL9XxUbUn9Z2oCLAQJ2ALHMPs3ADCiA==", null, null, new Guid("3b5143aa-62f9-49b8-ba06-3ae28505528e") }
                });

            migrationBuilder.InsertData(
                table: "CandidateProfiles",
                columns: new[] { "CandidateProfileId", "Address", "City", "Country", "PostalCode", "State", "UserId" },
                values: new object[,]
                {
                    { new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "123 Main Street, Apartment 4B", "Mumbai", "India", "400001", "Maharashtra", new Guid("0a33c200-c9f2-4547-810a-b3337a72d733") },
                    { new Guid("dcc9d83d-b11c-4336-9d33-fcc89185962b"), "A-304, Sunrise Apartments, Koramangala", "Bangalore", "India", "560034", "Karnataka", new Guid("050e7b3e-092f-49ec-9672-3ece1fb4b1c0") },
                    { new Guid("e1192660-3fe6-4244-a740-5c0325674394"), "B-12, Green Valley Society, Bandra West", "Mumbai", "India", "400050", "Maharashtra", new Guid("73f67ee8-ef98-4a52-b6b6-9b8a693795de") }
                });

            migrationBuilder.InsertData(
                table: "EmployeeUserRoles",
                columns: new[] { "EmployeeRoleId", "UserId", "AssignedOn" },
                values: new object[,]
                {
                    { new Guid("a12961ce-53d2-4294-99cb-b7916dbcec24"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 7, 6, 51, 41, 810, DateTimeKind.Utc).AddTicks(1447) },
                    { new Guid("9c0d0137-9b2e-47d5-8dac-8bc00bfd6e49"), new Guid("7c6a8f5b-9b2e-4e4a-a1a1-111111111111"), new DateTime(2026, 1, 7, 6, 51, 41, 810, DateTimeKind.Utc).AddTicks(1450) },
                    { new Guid("041c97a7-8cb7-4476-b7b3-5ff64bbba57f"), new Guid("8d7b9a6c-4c3f-4b5d-b2b2-222222222222"), new DateTime(2026, 1, 7, 6, 51, 41, 810, DateTimeKind.Utc).AddTicks(1453) }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CreatedByUserId", "CreatedDate", "DeadlineDate", "DefaultInterviewRoundsDefined", "DefaultReviewersAssigned", "JobDescriptionId", "LastModifiedDate", "OpeningsCount" },
                values: new object[,]
                {
                    { new Guid("15697654-2e8e-412b-b35e-8226cf911237"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 4, 6, 51, 41, 811, DateTimeKind.Utc).AddTicks(7918), new DateTime(2026, 2, 6, 6, 51, 41, 811, DateTimeKind.Utc).AddTicks(7918), false, false, new Guid("1a116292-6aa5-41fd-bcd1-ec7122f1ade2"), null, 5 },
                    { new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 28, 6, 51, 41, 811, DateTimeKind.Utc).AddTicks(7876), new DateTime(2026, 1, 27, 6, 51, 41, 811, DateTimeKind.Utc).AddTicks(7884), false, false, new Guid("17c3c873-e9b4-40c7-aa1e-f4a15215c2dd"), null, 3 },
                    { new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2025, 12, 31, 6, 51, 41, 811, DateTimeKind.Utc).AddTicks(7888), new DateTime(2026, 1, 30, 6, 51, 41, 811, DateTimeKind.Utc).AddTicks(7889), false, false, new Guid("1b0c489e-b0aa-42f0-8970-5ae1d05d5aac"), null, 2 },
                    { new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), new Guid("331a9809-54d9-43c3-883a-493e8787f97a"), new DateTime(2026, 1, 2, 6, 51, 41, 811, DateTimeKind.Utc).AddTicks(7891), new DateTime(2026, 2, 1, 6, 51, 41, 811, DateTimeKind.Utc).AddTicks(7914), false, false, new Guid("2419e70e-58bb-4f99-a148-6df838e294c8"), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateSkillId", "CandidateProfileId", "ExperienceYears", "ProficiencyLevel", "SkillId" },
                values: new object[,]
                {
                    { new Guid("067be206-7456-4c11-8c24-2a3fdebab7f8"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), 5m, "Beginner", new Guid("43ff8410-b479-4846-956a-df3c56ffd882") },
                    { new Guid("272e9202-e704-4abd-af25-9d995ff2e61e"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), 4m, "Beginner", new Guid("d161a587-31d4-45ea-a184-80495bdf6895") },
                    { new Guid("275d0b0e-6d60-4c3a-ab77-1edfeff21a32"), new Guid("dcc9d83d-b11c-4336-9d33-fcc89185962b"), 6m, "Advanced", new Guid("d161a587-31d4-45ea-a184-80495bdf6895") },
                    { new Guid("40e578a5-9408-4da2-b7d1-2618ee444ad1"), new Guid("dcc9d83d-b11c-4336-9d33-fcc89185962b"), 4m, "Advanced", new Guid("355e3b35-1706-480c-b5ab-6be7707b49e0") },
                    { new Guid("664ecdbe-1a9e-4a56-a72e-3e1d122646ee"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), 5m, "Beginner", new Guid("1798cda1-f1ef-45e6-9bbc-e9ca5970c5c0") },
                    { new Guid("87c5a754-821a-45af-a793-3d636f0ad9d4"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), 4m, "Beginner", new Guid("cc858b5f-73d0-4933-880d-3ca36cdfd2c6") },
                    { new Guid("bef15313-d642-4d37-b8d2-0e5177a423c1"), new Guid("e1192660-3fe6-4244-a740-5c0325674394"), 5m, "Advanced", new Guid("07a14cde-7266-405a-9fa8-8a71554c7868") }
                });

            migrationBuilder.InsertData(
                table: "CandidateSocials",
                columns: new[] { "CandidateSocialsId", "CandidateProfileId", "Link", "SocialPlatformId" },
                values: new object[,]
                {
                    { new Guid("1aac2239-885b-4659-a20e-cd95dbcf10aa"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "https://linkedin.com/in/test-user", new Guid("e51d1a21-66ec-4480-92e8-12aea0b34920") },
                    { new Guid("26fb87cb-78ce-4b52-9ae3-2ba53ea874fc"), new Guid("dcc9d83d-b11c-4336-9d33-fcc89185962b"), "https://github.com/priyasharma", new Guid("751a7e1c-df12-4bdc-a278-f0f7effc4e08") },
                    { new Guid("7cff6c8c-a3ef-4950-b9c0-b64d340c0e5b"), new Guid("e1192660-3fe6-4244-a740-5c0325674394"), "https://linkedin.com/in/rajesh-kumar-frontend", new Guid("e51d1a21-66ec-4480-92e8-12aea0b34920") },
                    { new Guid("9e617234-950b-4669-b31a-0c009f299865"), new Guid("e1192660-3fe6-4244-a740-5c0325674394"), "https://rajeshkumar.dev", new Guid("333fab14-c62b-4ab7-886e-e880bab313b1") },
                    { new Guid("be97a527-e891-4a4a-8db2-b171c544216f"), new Guid("e1192660-3fe6-4244-a740-5c0325674394"), "https://github.com/rajeshkumar-dev", new Guid("751a7e1c-df12-4bdc-a278-f0f7effc4e08") },
                    { new Guid("c0782ba6-8d48-45ca-bfcf-c082bfb66ed5"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "https://github.com/testuser", new Guid("751a7e1c-df12-4bdc-a278-f0f7effc4e08") },
                    { new Guid("f9812cae-0de3-4097-8270-5c9798c7b13d"), new Guid("dcc9d83d-b11c-4336-9d33-fcc89185962b"), "https://linkedin.com/in/priya-sharma-dev", new Guid("e51d1a21-66ec-4480-92e8-12aea0b34920") }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "CandidateProfileId", "DegreeType", "EndDate", "FieldOfStudy", "InstituteName", "IsCurrent", "PercentageScore", "StartDate" },
                values: new object[,]
                {
                    { new Guid("5658a065-4768-4745-aa39-6e2fbc9b5d3f"), new Guid("dcc9d83d-b11c-4336-9d33-fcc89185962b"), "12th Grade", new DateTime(2013, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Science (PCMC)", "National Public School, Bangalore", false, 89.00m, new DateTime(2011, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5e049841-411d-4588-926e-9010f05e19b3"), new Guid("dcc9d83d-b11c-4336-9d33-fcc89185962b"), "B.E", new DateTime(2017, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science and Engineering", "RV College of Engineering, Bangalore", false, 82.50m, new DateTime(2013, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4808bab-76ec-40ce-a214-b5c7e20313be"), new Guid("e1192660-3fe6-4244-a740-5c0325674394"), "HSC (12th)", new DateTime(2015, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Science", "St. Xavier's High School, Mumbai", false, 81.50m, new DateTime(2013, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3f2c0e1-6f2a-4a6c-9f8a-1a2b3c4d5e01"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "B.Tech", new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "St. Xavier's College, Mumbai", false, 78.45m, new DateTime(2016, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4d3f1a2-7b3c-4d8e-9a0b-2c3d4e5f6a02"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "Higher Secondary (12th)", new DateTime(2016, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Science", "Mumbai Central Higher Secondary School", false, 86.20m, new DateTime(2014, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ce49424d-a625-4e59-b194-4153a0cf882d"), new Guid("e1192660-3fe6-4244-a740-5c0325674394"), "B.Tech", new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", "Mumbai University - DJ Sanghvi College", false, 75.20m, new DateTime(2015, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "ExperienceId", "CandidateProfileId", "CompanyName", "DurationYears", "EndDate", "IsCurrent", "JobDescription", "Position", "StartDate" },
                values: new object[,]
                {
                    { new Guid("35a1d804-622a-4f0d-96aa-5dcec6509e6d"), new Guid("e1192660-3fe6-4244-a740-5c0325674394"), "Cognizant", 1.50m, new DateTime(2021, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Worked on client projects using HTML, CSS, JavaScript, and basic React. Fixed bugs, implemented new features, and learned modern frontend development practices.", "Junior Frontend Developer", new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("72860a21-dfdf-4432-b87c-3e099edc9e53"), new Guid("e1192660-3fe6-4244-a740-5c0325674394"), "Wipro Digital", 2.50m, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Built responsive web applications using React, Redux, and TypeScript. Collaborated with UX designers and backend teams to deliver pixel-perfect interfaces. Improved page load times by 40%.", "Frontend Developer", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("76aa471e-03a2-4fce-959d-94c38e88bc02"), new Guid("dcc9d83d-b11c-4336-9d33-fcc89185962b"), "Infosys Technologies Ltd", 3.50m, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Led a team of 4 developers in building enterprise applications using .NET Core and Angular. Implemented microservices architecture, optimized database queries, and mentored junior developers.", "Senior Software Engineer", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ccc773a8-36b8-43d0-84d7-9e4bd50ae17a"), new Guid("dcc9d83d-b11c-4336-9d33-fcc89185962b"), "TCS Digital", 3.00m, new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Developed and maintained web applications using ASP.NET MVC and SQL Server. Participated in code reviews, unit testing, and agile ceremonies.", "Software Developer", new DateTime(2017, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5e4f3b2-8c4d-4e9f-0a1b-3c4d5e6f7a03"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "InnoTech Solutions Pvt. Ltd.", 2.50m, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Worked on backend APIs using .NET Core, implemented authentication and REST endpoints, wrote unit tests and integrated CI/CD pipelines.", "Software Engineer", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6f5a4c3-9d5e-4f0a-1b2c-4d5e6f7a8b04"), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "QuickStart Internships", 0.50m, new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Assisted in developing small features, bug fixes and wrote documentation. Gained exposure to agile practices.", "Software Intern", new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "JobApplicationId", "ApplicationDate", "CandidateProfileId", "CurrentStatus", "JobId", "StatusNote", "StatusUpdatedAt" },
                values: new object[,]
                {
                    { new Guid("030d361c-2b38-4fdf-badc-9e4db3029fd6"), new DateTime(2026, 1, 1, 6, 51, 41, 813, DateTimeKind.Utc).AddTicks(5228), new Guid("29d665b6-7013-4170-a8eb-844f2d79d356"), "Applied", new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), "Application received", new DateTime(2026, 1, 1, 6, 51, 41, 813, DateTimeKind.Utc).AddTicks(5230) },
                    { new Guid("84b87be3-be72-440f-bbca-be8349477595"), new DateTime(2025, 12, 31, 6, 51, 41, 813, DateTimeKind.Utc).AddTicks(5198), new Guid("e1192660-3fe6-4244-a740-5c0325674394"), "Applied", new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), null, new DateTime(2025, 12, 31, 6, 51, 41, 813, DateTimeKind.Utc).AddTicks(5200) },
                    { new Guid("d9a8985e-31f8-4f3f-b2ba-80353eb85830"), new DateTime(2025, 12, 30, 6, 51, 41, 813, DateTimeKind.Utc).AddTicks(5148), new Guid("dcc9d83d-b11c-4336-9d33-fcc89185962b"), "Applied", new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), null, new DateTime(2025, 12, 30, 6, 51, 41, 813, DateTimeKind.Utc).AddTicks(5153) }
                });

            migrationBuilder.InsertData(
                table: "JobInterviewRounds",
                columns: new[] { "JobInterviewRoundId", "IsActive", "JobId", "RoundNumber", "RoundType" },
                values: new object[,]
                {
                    { new Guid("7cec740e-e176-4299-b690-b322be0e4550"), true, new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 2, "Technical" },
                    { new Guid("e568248f-02f4-4f47-998b-e2ff63680ef9"), true, new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 1, "Technical" },
                    { new Guid("e70a92b2-202b-4aee-b6ab-ef1f9678b1f2"), true, new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 3, "HR" }
                });

            migrationBuilder.InsertData(
                table: "JobSkills",
                columns: new[] { "JobSkillId", "JobId", "MinExperienceYears", "SkillId" },
                values: new object[,]
                {
                    { new Guid("015cb29d-f6b6-4083-a1aa-2436063f7097"), new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), 3, new Guid("1798cda1-f1ef-45e6-9bbc-e9ca5970c5c0") },
                    { new Guid("204564ab-5f09-4156-b852-e0c75ab4e8a5"), new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 3, new Guid("355e3b35-1706-480c-b5ab-6be7707b49e0") },
                    { new Guid("47439964-3f47-4233-a5e0-41113a3f4793"), new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 4, new Guid("07a14cde-7266-405a-9fa8-8a71554c7868") },
                    { new Guid("554a8a63-e8ec-4205-9f61-bf04f183ec80"), new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), 3, new Guid("4c487bbc-6fa9-4643-9d9e-a88e5bea917e") },
                    { new Guid("5706cb4f-c47d-4702-bbe7-37066b4654aa"), new Guid("15697654-2e8e-412b-b35e-8226cf911237"), 0, new Guid("1798cda1-f1ef-45e6-9bbc-e9ca5970c5c0") },
                    { new Guid("63ae3a18-a97a-47eb-9526-684b3fcadfb7"), new Guid("15697654-2e8e-412b-b35e-8226cf911237"), 0, new Guid("d161a587-31d4-45ea-a184-80495bdf6895") },
                    { new Guid("6b19d5c5-e470-4c50-b0f9-3b85dfe93d9c"), new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), 2, new Guid("355e3b35-1706-480c-b5ab-6be7707b49e0") },
                    { new Guid("711d5cb7-f06d-49f7-b8c5-6bdad400c6aa"), new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), 2, new Guid("355e3b35-1706-480c-b5ab-6be7707b49e0") },
                    { new Guid("75bc4b90-27d1-421a-b41d-69dac1af8455"), new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), 2, new Guid("43ff8410-b479-4846-956a-df3c56ffd882") },
                    { new Guid("8a2cba7c-77e8-4816-9ff5-f87d7e43f4b7"), new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 5, new Guid("43ff8410-b479-4846-956a-df3c56ffd882") },
                    { new Guid("a384ecac-d7c3-426c-bf2c-1081c7839566"), new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), 3, new Guid("07a14cde-7266-405a-9fa8-8a71554c7868") },
                    { new Guid("b862cb8b-4110-4618-b052-25f04e8791b9"), new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), 3, new Guid("cc858b5f-73d0-4933-880d-3ca36cdfd2c6") },
                    { new Guid("c1a03393-44c2-4f48-aa7a-fb364b4f663d"), new Guid("af6b7d6b-2128-4e5f-8804-d5209a38e443"), 3, new Guid("1798cda1-f1ef-45e6-9bbc-e9ca5970c5c0") },
                    { new Guid("c464e2c6-6050-4260-b203-7e1eb0e7ced9"), new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 4, new Guid("d161a587-31d4-45ea-a184-80495bdf6895") },
                    { new Guid("d69a6744-7c00-4084-b53e-924cb685fec8"), new Guid("f9651a24-9357-4af0-a9f0-96f5736e8eb6"), 4, new Guid("43ff8410-b479-4846-956a-df3c56ffd882") },
                    { new Guid("e7d891b0-bd82-4b3d-b061-0e0d08ad12ed"), new Guid("15697654-2e8e-412b-b35e-8226cf911237"), 0, new Guid("4c487bbc-6fa9-4643-9d9e-a88e5bea917e") },
                    { new Guid("ecb67307-ce9e-42fa-9668-1c0fb320d2e6"), new Guid("a83a2e30-7d33-4829-bf86-e9cce7462b53"), 4, new Guid("cc858b5f-73d0-4933-880d-3ca36cdfd2c6") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationSkills_Skills_SkillId",
                table: "ApplicationSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_CandidateProfiles_CandidateProfileId",
                table: "JobApplications",
                column: "CandidateProfileId",
                principalTable: "CandidateProfiles",
                principalColumn: "CandidateProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Jobs_JobId",
                table: "JobApplications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
