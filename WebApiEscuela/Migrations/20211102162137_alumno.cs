using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiEscuela.Migrations
{
    public partial class alumno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores");

            migrationBuilder.RenameTable(
                name: "Profesores",
                newName: "Profesor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor");

            migrationBuilder.RenameTable(
                name: "Profesor",
                newName: "Profesores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores",
                column: "Id");
        }
    }
}
