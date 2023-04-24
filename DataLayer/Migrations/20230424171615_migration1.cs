using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations {
	/// <inheritdoc />
	public partial class migration1 : Migration {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable(
				name: "Classes",
				columns: table => new {
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Classes", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Students",
				columns: table => new {
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					FirstName = table.Column<string>(type: "text", nullable: true),
					LastName = table.Column<string>(type: "text", nullable: true),
					DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					ClassId = table.Column<int>(type: "integer", nullable: false),
					Address = table.Column<string>(type: "text", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Students", x => x.Id);
					table.ForeignKey(
						name: "FK_Students_Classes_ClassId",
						column: x => x.ClassId,
						principalTable: "Classes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Grades",
				columns: table => new {
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Value = table.Column<double>(type: "double precision", nullable: false),
					Course = table.Column<int>(type: "integer", nullable: false),
					DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					StudentId = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Grades", x => x.Id);
					table.ForeignKey(
						name: "FK_Grades_Students_StudentId",
						column: x => x.StudentId,
						principalTable: "Students",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Grades_StudentId",
				table: "Grades",
				column: "StudentId");

			migrationBuilder.CreateIndex(
				name: "IX_Students_ClassId",
				table: "Students",
				column: "ClassId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(
				name: "Grades");

			migrationBuilder.DropTable(
				name: "Students");

			migrationBuilder.DropTable(
				name: "Classes");
		}
	}
}
