using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectAlpha.Migrations
{
    /// <inheritdoc />
    public partial class removeUserFromStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Students_StudentId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_StudentId",
                table: "User");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "Email", "FName", "LName", "Level", "Password", "PhoneNumber", "Sex", "UserId" },
                values: new object[] { 1, new DateTime(2001, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "AhmedMahmoud@Mail.com", "Ahmed", "Mahmoud", 12, "123456@Mail", "1234567890", 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_User_StudentId",
                table: "User",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Students_StudentId",
                table: "User",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
