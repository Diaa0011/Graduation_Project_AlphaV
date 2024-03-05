using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectAlpha.Migrations
{
    /// <inheritdoc />
    public partial class MazenUpdatesBaseEntityAndRemoveIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentQuestionId",
                table: "StudentQuestionInteraction",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentLessonId",
                table: "StudentLessonInteraction",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentAssessmentId",
                table: "StudentAssessmentInteraction",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Section",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Question",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "Module",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "Lesson",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseEnrollmentId",
                table: "CourseEnrollment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommentVoteId",
                table: "CommentVote",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ChoiceId",
                table: "Choice",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AssessmentQuestionId",
                table: "AssessmentQuestion",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AssessmentLessonLinkingId",
                table: "AssessmentLessonLinking",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AssessmentId",
                table: "Assessment",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StudentQuestionInteraction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StudentQuestionInteraction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentQuestionInteraction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "StudentQuestionInteraction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "StudentQuestionInteraction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StudentLessonInteraction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StudentLessonInteraction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentLessonInteraction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "StudentLessonInteraction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "StudentLessonInteraction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StudentAssessmentInteraction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StudentAssessmentInteraction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentAssessmentInteraction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "StudentAssessmentInteraction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "StudentAssessmentInteraction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Section",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Section",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Section",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Section",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Section",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Question",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Question",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Question",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Question",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Question",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Module",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Module",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Module",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Module",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Module",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Lesson",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Lesson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lesson",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Lesson",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Lesson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CourseEnrollment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CourseEnrollment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourseEnrollment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "CourseEnrollment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CourseEnrollment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CommentVote",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CommentVote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CommentVote",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "CommentVote",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CommentVote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Comment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Choice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Choice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Choice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Choice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Choice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AssessmentQuestion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AssessmentQuestion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AssessmentQuestion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "AssessmentQuestion",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AssessmentQuestion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AssessmentLessonLinking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AssessmentLessonLinking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AssessmentLessonLinking",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "AssessmentLessonLinking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AssessmentLessonLinking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Assessment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Assessment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Assessment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Assessment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Assessment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "IsDeleted", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 2, 26, 19, 3, 59, 462, DateTimeKind.Utc).AddTicks(2975), "Admin", false, null, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StudentQuestionInteraction");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StudentQuestionInteraction");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentQuestionInteraction");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "StudentQuestionInteraction");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StudentQuestionInteraction");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StudentLessonInteraction");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StudentLessonInteraction");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentLessonInteraction");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "StudentLessonInteraction");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StudentLessonInteraction");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StudentAssessmentInteraction");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StudentAssessmentInteraction");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentAssessmentInteraction");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "StudentAssessmentInteraction");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StudentAssessmentInteraction");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CourseEnrollment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CourseEnrollment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourseEnrollment");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "CourseEnrollment");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CourseEnrollment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CommentVote");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CommentVote");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CommentVote");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "CommentVote");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CommentVote");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Choice");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Choice");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Choice");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Choice");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Choice");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AssessmentQuestion");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AssessmentQuestion");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AssessmentQuestion");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "AssessmentQuestion");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AssessmentQuestion");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AssessmentLessonLinking");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AssessmentLessonLinking");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AssessmentLessonLinking");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "AssessmentLessonLinking");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AssessmentLessonLinking");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Assessment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Assessment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Assessment");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Assessment");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Assessment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentQuestionInteraction",
                newName: "StudentQuestionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentLessonInteraction",
                newName: "StudentLessonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentAssessmentInteraction",
                newName: "StudentAssessmentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Section",
                newName: "SectionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Question",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Module",
                newName: "ModuleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lesson",
                newName: "LessonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CourseEnrollment",
                newName: "CourseEnrollmentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CommentVote",
                newName: "CommentVoteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comment",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Choice",
                newName: "ChoiceId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AssessmentQuestion",
                newName: "AssessmentQuestionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AssessmentLessonLinking",
                newName: "AssessmentLessonLinkingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Assessment",
                newName: "AssessmentId");
        }
    }
}
