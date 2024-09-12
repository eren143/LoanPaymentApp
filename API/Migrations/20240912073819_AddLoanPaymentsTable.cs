using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanPaymentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AraOdemePlanlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OdemeSayisi = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AraOdemePlanlari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdemeSatiri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaksitNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Taksit = table.Column<double>(type: "REAL", nullable: false),
                    Anapara = table.Column<double>(type: "REAL", nullable: false),
                    Faiz = table.Column<double>(type: "REAL", nullable: false),
                    KalanTutar = table.Column<double>(type: "REAL", nullable: false),
                    OdemePlaniId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeSatiri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdemeSatiri_AraOdemePlanlari_OdemePlaniId",
                        column: x => x.OdemePlaniId,
                        principalTable: "AraOdemePlanlari",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OdemeSatiri_OdemePlaniId",
                table: "OdemeSatiri",
                column: "OdemePlaniId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdemeSatiri");

            migrationBuilder.DropTable(
                name: "AraOdemePlanlari");
        }
    }
}
