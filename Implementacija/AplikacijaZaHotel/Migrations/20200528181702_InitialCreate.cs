using Microsoft.EntityFrameworkCore.Migrations;

namespace AplikacijaZaHotel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vrsta",
                columns: table => new
                {
                    VrstaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Balkon = table.Column<bool>(nullable: false),
                    Kapacitet = table.Column<int>(nullable: false),
                    Cijena = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vrsta", x => x.VrstaId);
                });

            migrationBuilder.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSobe = table.Column<int>(nullable: false),
                    VrstaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.Id);
                    table.UniqueConstraint("AK_Soba_BrojSobe", x => x.BrojSobe);
                    table.ForeignKey(
                        name: "FK_Soba_Vrsta_VrstaID",
                        column: x => x.VrstaID,
                        principalTable: "Vrsta",
                        principalColumn: "VrstaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Soba_VrstaID",
                table: "Soba",
                column: "VrstaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Soba");

            migrationBuilder.DropTable(
                name: "Vrsta");
        }
    }
}
