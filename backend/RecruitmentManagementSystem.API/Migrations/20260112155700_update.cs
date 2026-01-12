using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CloseReason",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsClosed",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CandidateVerifications",
                columns: table => new
                {
                    CandidateVerificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateVerifications", x => x.CandidateVerificationId);
                    table.ForeignKey(
                        name: "FK_CandidateVerifications_CandidateProfiles_CandidateProfileId",
                        column: x => x.CandidateProfileId,
                        principalTable: "CandidateProfiles",
                        principalColumn: "CandidateProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateVerifications_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId");
                });

            migrationBuilder.CreateTable(
                name: "VerificationDocuments",
                columns: table => new
                {
                    VerificationDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateVerificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReviewedByUserUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationDocuments", x => x.VerificationDocumentId);
                    table.ForeignKey(
                        name: "FK_VerificationDocuments_CandidateVerifications_CandidateVerificationId",
                        column: x => x.CandidateVerificationId,
                        principalTable: "CandidateVerifications",
                        principalColumn: "CandidateVerificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerificationDocuments_Users_ReviewedByUserUserId",
                        column: x => x.ReviewedByUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateVerifications_CandidateProfileId",
                table: "CandidateVerifications",
                column: "CandidateProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateVerifications_JobId",
                table: "CandidateVerifications",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationDocuments_CandidateVerificationId",
                table: "VerificationDocuments",
                column: "CandidateVerificationId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationDocuments_ReviewedByUserUserId",
                table: "VerificationDocuments",
                column: "ReviewedByUserUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerificationDocuments");

            migrationBuilder.DropTable(
                name: "CandidateVerifications");

            migrationBuilder.DropColumn(
                name: "CloseReason",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Jobs");
        }
    }
}
