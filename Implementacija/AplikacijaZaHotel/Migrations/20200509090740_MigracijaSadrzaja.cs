using Microsoft.EntityFrameworkCore.Migrations;

namespace AplikacijaZaHotel.Migrations
{
    public partial class MigracijaSadrzaja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sadrzaj",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Cijena = table.Column<float>(nullable: false),
                    Dostupnost = table.Column<bool>(nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sadrzaj", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sadrzaj");
        }
    }
}
