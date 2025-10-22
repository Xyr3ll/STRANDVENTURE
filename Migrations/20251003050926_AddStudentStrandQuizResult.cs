using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentStrandQuizResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentStrandQuizResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrandQuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttemptNumber = table.Column<int>(type: "int", nullable: false),
                    TotalQuestions = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    ScorePercent = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ShieldsRemaining = table.Column<int>(type: "int", nullable: false),
                    MaxStreakAchieved = table.Column<int>(type: "int", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStrandQuizResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentStrandQuizResults_StrandQuizzes_StrandQuizId",
                        column: x => x.StrandQuizId,
                        principalTable: "StrandQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentStrandQuizResults_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 3, 5, 9, 25, 735, DateTimeKind.Utc).AddTicks(1970), "PBKDF2-HMACSHA256.210000.Y5xc3lOUOU+CwBsPMQsUVQ==.hVm1fhu2DUU4j75oq8/6/It3AtLNEYAS2YiQFGpSFc0=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 3, 5, 9, 25, 710, DateTimeKind.Utc).AddTicks(6903), "PBKDF2-HMACSHA256.210000.e8q3zI1ZMZKnazyQIVQ6ZA==.9gECyRkpWVBrhuIzIQ2ANsVn37bFRwff9G1gccYUAnM=" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentStrandQuizResults_StrandQuizId",
                table: "StudentStrandQuizResults",
                column: "StrandQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStrandQuizResults_StudentId_StrandQuizId_AttemptNumber",
                table: "StudentStrandQuizResults",
                columns: new[] { "StudentId", "StrandQuizId", "AttemptNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentStrandQuizResults");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 3, 2, 57, 52, 350, DateTimeKind.Utc).AddTicks(2195), "PBKDF2-HMACSHA256.210000.DHc4ta6HZpx6Ocrdpf/YuA==.FWLka5+AuoCVK7uBAFw+3iFdkT6b1VceKWt+XtHHuSo=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 3, 2, 57, 52, 325, DateTimeKind.Utc).AddTicks(8838), "PBKDF2-HMACSHA256.210000.BKMF6d5yF1RLpgU4hyk+7w==.5OaLb5oxNXw2ZSS2LV82fPodgF75g+2ya8lQ9zuUU6Y=" });
        }
    }
}
