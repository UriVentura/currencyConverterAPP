using Microsoft.EntityFrameworkCore.Migrations;

namespace CCTransferWeb.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FactorConversiones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonedaOrigen = table.Column<string>(nullable: true),
                    MonedaDestino = table.Column<string>(nullable: true),
                    Conversion = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorConversiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monedas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMoneda = table.Column<string>(nullable: true),
                    CodMoneda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Monedas",
                columns: new[] { "Id", "CodMoneda", "NomMoneda" },
                values: new object[] { 1, "EUR", "Euro" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactorConversiones");

            migrationBuilder.DropTable(
                name: "Monedas");
        }
    }
}
