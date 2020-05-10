using Microsoft.EntityFrameworkCore.Migrations;

namespace AplikacijaZaHotel.Migrations
{
    public partial class MigracijaSoba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrstaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soba_Vrsta_vrstaId",
                        column: x => x.vrstaId,
                        principalTable: "Vrsta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Soba_vrstaId",
                table: "Soba",
                column: "vrstaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Soba");
        }
    }
}
