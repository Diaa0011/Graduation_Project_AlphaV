using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectAlpha.Migrations
{
    /// <inheritdoc />
    public partial class QuizUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choice_Question_QuestionId",
                table: "Choice");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Lesson_LessonId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Module_ModuleId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_Section_SectionId",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Courses_CourseId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLessonInteraction_Lesson_LessonId",
                table: "StudentLessonInteraction");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestionInteraction_Question_QuestionId",
                table: "StudentQuestionInteraction");

            migrationBuilder.DropTable(
                name: "AssessmentLessonLinking");

            migrationBuilder.DropTable(
                name: "AssessmentQuestion");

            migrationBuilder.DropTable(
                name: "StudentAssessmentInteraction");

            migrationBuilder.DropTable(
                name: "Assessment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Section",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module",
                table: "Module");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choice",
                table: "Choice");

            migrationBuilder.RenameTable(
                name: "Section",
                newName: "Sections");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Module",
                newName: "Modules");

            migrationBuilder.RenameTable(
                name: "Lesson",
                newName: "Lessons");

            migrationBuilder.RenameTable(
                name: "Choice",
                newName: "Choices");

            migrationBuilder.RenameIndex(
                name: "IX_Section_CourseId",
                table: "Sections",
                newName: "IX_Sections_CourseId");

            migrationBuilder.RenameColumn(
                name: "RightChoiceIndex",
                table: "Questions",
                newName: "RightChoiceId");

            migrationBuilder.RenameColumn(
                name: "QuestionCategory",
                table: "Questions",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Module_SectionId",
                table: "Modules",
                newName: "IX_Modules_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_ModuleId",
                table: "Lessons",
                newName: "IX_Lessons_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Choice_QuestionId",
                table: "Choices",
                newName: "IX_Choices_QuestionId");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                table: "Sections",
                column: "SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                table: "Modules",
                column: "ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "LessonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choices",
                table: "Choices",
                column: "ChoiceId");

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizId);
                    table.ForeignKey(
                        name: "FK_Quizzes_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizLessonLinkings",
                columns: table => new
                {
                    QuizLessonLinkingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizLessonLinkings", x => x.QuizLessonLinkingId);
                    table.ForeignKey(
                        name: "FK_QuizLessonLinkings_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizLessonLinkings_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentQuizInteraction",
                columns: table => new
                {
                    StudentAssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OverallGrade = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AssessmentQuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuizInteraction", x => x.StudentAssessmentId);
                    table.ForeignKey(
                        name: "FK_StudentQuizInteraction_Quizzes_AssessmentQuizId",
                        column: x => x.AssessmentQuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentQuizInteraction_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizLessonLinkings_LessonId",
                table: "QuizLessonLinkings",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizLessonLinkings_QuizId",
                table: "QuizLessonLinkings",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_ModuleId",
                table: "Quizzes",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuizInteraction_AssessmentQuizId",
                table: "StudentQuizInteraction",
                column: "AssessmentQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuizInteraction_StudentId",
                table: "StudentQuizInteraction",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                table: "Choices",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Lessons_LessonId",
                table: "Comment",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Modules_ModuleId",
                table: "Lessons",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Sections_SectionId",
                table: "Modules",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLessonInteraction_Lessons_LessonId",
                table: "StudentLessonInteraction",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestionInteraction_Questions_QuestionId",
                table: "StudentQuestionInteraction",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Lessons_LessonId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Modules_ModuleId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Sections_SectionId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLessonInteraction_Lessons_LessonId",
                table: "StudentLessonInteraction");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestionInteraction_Questions_QuestionId",
                table: "StudentQuestionInteraction");

            migrationBuilder.DropTable(
                name: "QuizLessonLinkings");

            migrationBuilder.DropTable(
                name: "StudentQuizInteraction");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choices",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Sections",
                newName: "Section");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "Module");

            migrationBuilder.RenameTable(
                name: "Lessons",
                newName: "Lesson");

            migrationBuilder.RenameTable(
                name: "Choices",
                newName: "Choice");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_CourseId",
                table: "Section",
                newName: "IX_Section_CourseId");

            migrationBuilder.RenameColumn(
                name: "RightChoiceId",
                table: "Question",
                newName: "RightChoiceIndex");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Question",
                newName: "QuestionCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_SectionId",
                table: "Module",
                newName: "IX_Module_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_ModuleId",
                table: "Lesson",
                newName: "IX_Lesson_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Choices_QuestionId",
                table: "Choice",
                newName: "IX_Choice_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Section",
                table: "Section",
                column: "SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module",
                table: "Module",
                column: "ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson",
                column: "LessonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choice",
                table: "Choice",
                column: "ChoiceId");

            migrationBuilder.CreateTable(
                name: "Assessment",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    AssessmentType = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessment", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK_Assessment_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentLessonLinking",
                columns: table => new
                {
                    AssessmentLessonLinkingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentLessonLinking", x => x.AssessmentLessonLinkingId);
                    table.ForeignKey(
                        name: "FK_AssessmentLessonLinking_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentLessonLinking_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentQuestion",
                columns: table => new
                {
                    AssessmentQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentQuestion", x => x.AssessmentQuestionId);
                    table.ForeignKey(
                        name: "FK_AssessmentQuestion_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssessmentInteraction",
                columns: table => new
                {
                    StudentAssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    OverallGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssessmentInteraction", x => x.StudentAssessmentId);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentInteraction_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAssessmentInteraction_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_ModuleId",
                table: "Assessment",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentLessonLinking_AssessmentId",
                table: "AssessmentLessonLinking",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentLessonLinking_LessonId",
                table: "AssessmentLessonLinking",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentQuestion_AssessmentId",
                table: "AssessmentQuestion",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentQuestion_QuestionId",
                table: "AssessmentQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentInteraction_AssessmentId",
                table: "StudentAssessmentInteraction",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessmentInteraction_StudentId",
                table: "StudentAssessmentInteraction",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_Question_QuestionId",
                table: "Choice",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Lesson_LessonId",
                table: "Comment",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Module_ModuleId",
                table: "Lesson",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Section_SectionId",
                table: "Module",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Courses_CourseId",
                table: "Section",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLessonInteraction_Lesson_LessonId",
                table: "StudentLessonInteraction",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestionInteraction_Question_QuestionId",
                table: "StudentQuestionInteraction",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
