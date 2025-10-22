using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class FixMultipleCascadaPath_StudentAssessmentResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentAssessmentAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttemptNumber = table.Column<int>(type: "int", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TotalScorePercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssessmentAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentAttempts_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssessmentAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttemptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssessmentAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentAnswers_QuestionOptions_QuestionOptionId",
                        column: x => x.QuestionOptionId,
                        principalTable: "QuestionOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentAnswers_StudentAssessmentAttempts_AttemptId",
                        column: x => x.AttemptId,
                        principalTable: "StudentAssessmentAttempts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssessmentResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttemptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecommendedStrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FinalizedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssessmentResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentResults_Strands_RecommendedStrandId",
                        column: x => x.RecommendedStrandId,
                        principalTable: "Strands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentResults_StudentAssessmentAttempts_AttemptId",
                        column: x => x.AttemptId,
                        principalTable: "StudentAssessmentAttempts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentResults_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssessmentStrandScores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttemptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScorePercent = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssessmentStrandScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentStrandScores_Strands_StrandId",
                        column: x => x.StrandId,
                        principalTable: "Strands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentStrandScores_StudentAssessmentAttempts_AttemptId",
                        column: x => x.AttemptId,
                        principalTable: "StudentAssessmentAttempts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 20, 6, 10, 59, 609, DateTimeKind.Utc).AddTicks(4845), "PBKDF2-HMACSHA256.210000.7aGzD5NivYTYGu+p1HBS9A==.26R9hb+aQmk7DmMRpLqw6J/5KXl30usU4hHlu5gyxhA=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 20, 6, 10, 59, 584, DateTimeKind.Utc).AddTicks(8257), "PBKDF2-HMACSHA256.210000.xoXuK7Pp/A7XWx2TCytdPQ==.fSMbcNx2UsMs0hKb8T63GtQSTsDbe6p9PH1xF/9wz88=" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentAnswers_AttemptId_QuestionId",
                table: "StudentAssessmentAnswers",
                columns: new[] { "AttemptId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentAnswers_QuestionId",
                table: "StudentAssessmentAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentAnswers_QuestionOptionId",
                table: "StudentAssessmentAnswers",
                column: "QuestionOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentAttempts_StudentId_AttemptNumber",
                table: "StudentAssessmentAttempts",
                columns: new[] { "StudentId", "AttemptNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentResults_AttemptId",
                table: "StudentAssessmentResults",
                column: "AttemptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentResults_RecommendedStrandId",
                table: "StudentAssessmentResults",
                column: "RecommendedStrandId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentResults_StudentId",
                table: "StudentAssessmentResults",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentStrandScores_AttemptId_StrandId",
                table: "StudentAssessmentStrandScores",
                columns: new[] { "AttemptId", "StrandId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentStrandScores_StrandId",
                table: "StudentAssessmentStrandScores",
                column: "StrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssessmentAnswers");

            migrationBuilder.DropTable(
                name: "StudentAssessmentResults");

            migrationBuilder.DropTable(
                name: "StudentAssessmentStrandScores");

            migrationBuilder.DropTable(
                name: "StudentAssessmentAttempts");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 2, 0, 15, 46, 88, DateTimeKind.Local).AddTicks(2194), "PBKDF2-HMACSHA256.210000.PNXSS6xiYYFJYlbhN49ozw==.V8AzyE5+esNy5BWxuBuih8Zyql0g5x5pDhhsGRjcSqM=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 9, 2, 0, 15, 46, 62, DateTimeKind.Local).AddTicks(8479), "PBKDF2-HMACSHA256.210000.cN1lErw/DSXXiC2Ia6s/2g==.vDtDftrm0nDgAhNkYVBSJs4kuClVvV0kJxnPZob/01k=" });
        }
    }
}
