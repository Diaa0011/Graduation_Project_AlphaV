using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectAlpha.Migrations
{
    /// <inheritdoc />
    public partial class AddingDefaultValueToRatingToBeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnrolmentDate",
                table: "CourseEnrollments",
                newName: "EnrollmentDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnrollmentDate",
                table: "CourseEnrollments",
                newName: "EnrolmentDate");
        }
    }
}
