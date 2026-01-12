using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class interviewfeedbacl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewFeedbacks",
                columns: table => new
                {
                    InterviewFeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationInterviewRoundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallRating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewFeedbacks", x => x.InterviewFeedbackId);
                    table.ForeignKey(
                        name: "FK_InterviewFeedbacks_ApplicationInterviewRounds_ApplicationInterviewRoundId",
                        column: x => x.ApplicationInterviewRoundId,
                        principalTable: "ApplicationInterviewRounds",
                        principalColumn: "ApplicationInterviewRoundId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewFeedbacks_Users_InterviewerId",
                        column: x => x.InterviewerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewSkillRatings",
                columns: table => new
                {
                    InterviewSkillRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterviewFeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewSkillRatings", x => x.InterviewSkillRatingId);
                    table.ForeignKey(
                        name: "FK_InterviewSkillRatings_InterviewFeedbacks_InterviewFeedbackId",
                        column: x => x.InterviewFeedbackId,
                        principalTable: "InterviewFeedbacks",
                        principalColumn: "InterviewFeedbackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewSkillRatings_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterviewFeedbacks_ApplicationInterviewRoundId",
                table: "InterviewFeedbacks",
                column: "ApplicationInterviewRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewFeedbacks_InterviewerId",
                table: "InterviewFeedbacks",
                column: "InterviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewSkillRatings_InterviewFeedbackId",
                table: "InterviewSkillRatings",
                column: "InterviewFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewSkillRatings_SkillId",
                table: "InterviewSkillRatings",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewSkillRatings");

            migrationBuilder.DropTable(
                name: "InterviewFeedbacks");
        }
    }
}
