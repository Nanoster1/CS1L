using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CS1L.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    testid = table.Column<int>(name: "test_id", type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    imageurl = table.Column<string>(name: "image_url", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question", x => new { x.testid, x.id });
                    table.ForeignKey(
                        name: "fk_question_tests_test_id",
                        column: x => x.testid,
                        principalTable: "tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answer",
                columns: table => new
                {
                    questiontestid = table.Column<int>(name: "question_test_id", type: "integer", nullable: false),
                    questionid = table.Column<int>(name: "question_id", type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    iscorrect = table.Column<bool>(name: "is_correct", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_answer", x => new { x.questiontestid, x.questionid, x.id });
                    table.ForeignKey(
                        name: "fk_answer_question_question_test_id_question_id",
                        columns: x => new { x.questiontestid, x.questionid },
                        principalTable: "question",
                        principalColumns: new[] { "test_id", "id" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answer");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "tests");
        }
    }
}
