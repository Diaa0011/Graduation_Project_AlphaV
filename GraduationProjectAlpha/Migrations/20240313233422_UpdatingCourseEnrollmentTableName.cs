using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectAlpha.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingCourseEnrollmentTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollment_Courses_CourseId",
                table: "CourseEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollment_Students_StudentId",
                table: "CourseEnrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEnrollment",
                table: "CourseEnrollment");

            migrationBuilder.RenameTable(
                name: "CourseEnrollment",
                newName: "CourseEnrollments");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrollment_StudentId",
                table: "CourseEnrollments",
                newName: "IX_CourseEnrollments_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrollment_CourseId",
                table: "CourseEnrollments",
                newName: "IX_CourseEnrollments_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEnrollments",
                table: "CourseEnrollments",
                column: "CourseEnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_Courses_CourseId",
                table: "CourseEnrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_Students_StudentId",
                table: "CourseEnrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_Courses_CourseId",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_Students_StudentId",
                table: "CourseEnrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEnrollments",
                table: "CourseEnrollments");

            migrationBuilder.RenameTable(
                name: "CourseEnrollments",
                newName: "CourseEnrollment");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrollments_StudentId",
                table: "CourseEnrollment",
                newName: "IX_CourseEnrollment_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrollments_CourseId",
                table: "CourseEnrollment",
                newName: "IX_CourseEnrollment_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEnrollment",
                table: "CourseEnrollment",
                column: "CourseEnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollment_Courses_CourseId",
                table: "CourseEnrollment",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollment_Students_StudentId",
                table: "CourseEnrollment",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
