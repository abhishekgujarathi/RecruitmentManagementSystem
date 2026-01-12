using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class defaultRev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultInterviewRoundsDefined",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DefaultReviewersAssigned",
                table: "Jobs");

            migrationBuilder.CreateTable(
                name: "JobReviewers",
                columns: table => new
                {
                    JobReviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobReviewers", x => x.JobReviewerId);
                    table.ForeignKey(
                        name: "FK_JobReviewers_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobReviewers_Users_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobReviewers_JobId",
                table: "JobReviewers",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobReviewers_ReviewerId",
                table: "JobReviewers",
                column: "ReviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobReviewers");

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
        }
    }
}
