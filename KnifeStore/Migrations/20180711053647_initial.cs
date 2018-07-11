using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KnifeStore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Knives",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    SKU = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Style = table.Column<int>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManufacturerID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knives", x => x.ManufacturerID);
                    table.ForeignKey(
                        name: "FK_Knives_Manufacturers_ManufacturerID1",
                        column: x => x.ManufacturerID1,
                        principalTable: "Manufacturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knives_ManufacturerID1",
                table: "Knives",
                column: "ManufacturerID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Knives");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
