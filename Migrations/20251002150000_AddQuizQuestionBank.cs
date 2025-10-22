using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STRANDVENTURE.Migrations
{
    public partial class AddQuizQuestionBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop legacy join table if it still exists
            if (migrationBuilder.ActiveProvider.Contains("SqlServer", StringComparison.OrdinalIgnoreCase))
            {
                // Guarded drop (will fail silently if not exists is unsupported, so wrapped in TRY in raw SQL)
                migrationBuilder.Sql(@"IF OBJECT_ID('[dbo].[StrandQuizQuestions]','U') IS NOT NULL BEGIN DROP TABLE [dbo].[StrandQuizQuestions] END");
            }

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrandQuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_StrandQuizzes_StrandQuizId",
                        column: x => x.StrandQuizId,
                        principalTable: "StrandQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestionOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Letter = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestionOptions_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_StrandQuizId_DisplayOrder",
                table: "QuizQuestions",
                columns: new[] { "StrandQuizId", "DisplayOrder" },
                unique: true,
                filter: "[DisplayOrder] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_CreatedBy",
                table: "QuizQuestions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestionOptions_QuizQuestionId_Letter",
                table: "QuizQuestionOptions",
                columns: new[] { "QuizQuestionId", "Letter" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestionOptions_QuizQuestionId_IsCorrect",
                table: "QuizQuestionOptions",
                columns: new[] { "QuizQuestionId", "IsCorrect" },
                unique: true,
                filter: "[IsCorrect] = 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "QuizQuestionOptions");
            migrationBuilder.DropTable(name: "QuizQuestions");
        }
    }
}
