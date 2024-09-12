using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdemeSatiri_AraOdemePlanlari_OdemePlaniId",
                table: "OdemeSatiri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OdemeSatiri",
                table: "OdemeSatiri");

            migrationBuilder.RenameTable(
                name: "OdemeSatiri",
                newName: "OdemeSatirlari");

            migrationBuilder.RenameIndex(
                name: "IX_OdemeSatiri_OdemePlaniId",
                table: "OdemeSatirlari",
                newName: "IX_OdemeSatirlari_OdemePlaniId");

            migrationBuilder.AlterColumn<int>(
                name: "OdemePlaniId",
                table: "OdemeSatirlari",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OdemeSatirlari",
                table: "OdemeSatirlari",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OdemeSatirlari_AraOdemePlanlari_OdemePlaniId",
                table: "OdemeSatirlari",
                column: "OdemePlaniId",
                principalTable: "AraOdemePlanlari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdemeSatirlari_AraOdemePlanlari_OdemePlaniId",
                table: "OdemeSatirlari");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OdemeSatirlari",
                table: "OdemeSatirlari");

            migrationBuilder.RenameTable(
                name: "OdemeSatirlari",
                newName: "OdemeSatiri");

            migrationBuilder.RenameIndex(
                name: "IX_OdemeSatirlari_OdemePlaniId",
                table: "OdemeSatiri",
                newName: "IX_OdemeSatiri_OdemePlaniId");

            migrationBuilder.AlterColumn<int>(
                name: "OdemePlaniId",
                table: "OdemeSatiri",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OdemeSatiri",
                table: "OdemeSatiri",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OdemeSatiri_AraOdemePlanlari_OdemePlaniId",
                table: "OdemeSatiri",
                column: "OdemePlaniId",
                principalTable: "AraOdemePlanlari",
                principalColumn: "Id");
        }
    }
}
