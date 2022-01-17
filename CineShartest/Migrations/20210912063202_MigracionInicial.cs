using Microsoft.EntityFrameworkCore.Migrations;

namespace CineShartest.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomCli = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApeCli = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DniCli = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
