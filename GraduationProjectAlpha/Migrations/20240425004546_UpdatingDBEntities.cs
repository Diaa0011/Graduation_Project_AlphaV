using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectAlpha.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingDBEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WatchingTimeInSeconds",
                table: "StudentLessonInteraction");

            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "DurationInSeconds",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IntroductionVideoUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "IntroductionVideoUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "WatchingTimeInSeconds",
                table: "StudentLessonInteraction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DurationInSeconds",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
