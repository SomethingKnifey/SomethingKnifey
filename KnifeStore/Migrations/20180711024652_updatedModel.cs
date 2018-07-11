using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KnifeStore.Migrations
{
    public partial class updatedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Knives",
                newName: "Model");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerID",
                table: "Knives",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KnifeManufacturer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnifeManufacturer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knives_ManufacturerID",
                table: "Knives",
                column: "ManufacturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Knives_KnifeManufacturer_ManufacturerID",
                table: "Knives",
                column: "ManufacturerID",
                principalTable: "KnifeManufacturer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knives_KnifeManufacturer_ManufacturerID",
                table: "Knives");

            migrationBuilder.DropTable(
                name: "KnifeManufacturer");

            migrationBuilder.DropIndex(
                name: "IX_Knives_ManufacturerID",
                table: "Knives");

            migrationBuilder.DropColumn(
                name: "ManufacturerID",
                table: "Knives");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Knives",
                newName: "Name");
        }
    }
}
