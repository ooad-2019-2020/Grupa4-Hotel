using Microsoft.EntityFrameworkCore.Migrations;

namespace AplikacijaZaHotel.Migrations
{
    public partial class MigracijaVrste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vrsta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Cijena = table.Column<float>(nullable: false),
                    Balkon = table.Column<bool>(nullable: false),
                    Dostupnost = table.Column<bool>(nullable: false),
                    Kapacitet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vrsta", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vrsta");
        }
    }
}
