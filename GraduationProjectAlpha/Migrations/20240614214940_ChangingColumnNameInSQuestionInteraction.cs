using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectAlpha.Migrations
{
    /// <inheritdoc />
    public partial class ChangingColumnNameInSQuestionInteraction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentChoiceIndex",
                table: "StudentQuestionInteraction",
                newName: "StudentChoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentChoiceId",
                table: "StudentQuestionInteraction",
                newName: "StudentChoiceIndex");
        }
    }
}
