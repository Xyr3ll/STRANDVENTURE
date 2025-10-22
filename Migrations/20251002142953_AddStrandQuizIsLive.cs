using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STRANDVENTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddStrandQuizIsLive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLive",
                table: "StrandQuizzes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 2, 14, 29, 52, 870, DateTimeKind.Utc).AddTicks(4314), "PBKDF2-HMACSHA256.210000.iauNdHGpCLYd+xsT8UecIg==.hmPIa3CaubqeZ7QJHI6a3lAckVwx08z2+dwHC3Yu4WE=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 2, 14, 29, 52, 846, DateTimeKind.Utc).AddTicks(1428), "PBKDF2-HMACSHA256.210000.iQzsABxQiSM7nYbHb3lssQ==./E3WIK5dWb4R1q+xCjSDVz6T8b8znP/xSKiA49TPwnM=" });

            migrationBuilder.CreateIndex(
                name: "IX_StrandQuizzes_StrandId_IsLive",
                table: "StrandQuizzes",
                columns: new[] { "StrandId", "IsLive" },
                unique: true,
                filter: "[IsLive] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StrandQuizzes_StrandId_IsLive",
                table: "StrandQuizzes");

            migrationBuilder.DropColumn(
                name: "IsLive",
                table: "StrandQuizzes");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a26b9b24-c1ac-47de-9555-9c41571a7bff"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 2, 14, 1, 44, 331, DateTimeKind.Utc).AddTicks(2853), "PBKDF2-HMACSHA256.210000.r8W6OVApi4v9PzBPFqpc8A==.Ohhuk5biW0N5025vAMxgDNJE6xoeJZLJXwj2R/d4q0k=" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c1f6a527-8aac-4f51-aa59-0c3d8b451e18"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 2, 14, 1, 44, 306, DateTimeKind.Utc).AddTicks(686), "PBKDF2-HMACSHA256.210000.+i0dK0mZhfgg5x9aIwR1fw==.3xpD/vCEmOlkkkFCoubVVlYwFUU+hieyhiL4cHKBq28=" });
        }
    }
}
