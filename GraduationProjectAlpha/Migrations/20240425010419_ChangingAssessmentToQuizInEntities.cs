using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectAlpha.Migrations
{
    /// <inheritdoc />
    public partial class ChangingAssessmentToQuizInEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuizInteraction_Quizzes_AssessmentQuizId",
                table: "StudentQuizInteraction");

            migrationBuilder.RenameColumn(
                name: "AssessmentQuizId",
                table: "StudentQuizInteraction",
                newName: "QuizId");

            migrationBuilder.RenameColumn(
                name: "StudentAssessmentId",
                table: "StudentQuizInteraction",
                newName: "StudentQuizId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuizInteraction_AssessmentQuizId",
                table: "StudentQuizInteraction",
                newName: "IX_StudentQuizInteraction_QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuizInteraction_Quizzes_QuizId",
                table: "StudentQuizInteraction",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuizInteraction_Quizzes_QuizId",
                table: "StudentQuizInteraction");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "StudentQuizInteraction",
                newName: "AssessmentQuizId");

            migrationBuilder.RenameColumn(
                name: "StudentQuizId",
                table: "StudentQuizInteraction",
                newName: "StudentAssessmentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuizInteraction_QuizId",
                table: "StudentQuizInteraction",
                newName: "IX_StudentQuizInteraction_AssessmentQuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuizInteraction_Quizzes_AssessmentQuizId",
                table: "StudentQuizInteraction",
                column: "AssessmentQuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
