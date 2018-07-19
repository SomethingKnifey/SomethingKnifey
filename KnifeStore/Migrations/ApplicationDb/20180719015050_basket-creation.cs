using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KnifeStore.Migrations.ApplicationDb
{
    public partial class basketcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasketID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Knife",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SKU = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Style = table.Column<int>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: true),
                    BasketID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knife", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Knife_Basket_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Basket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Knife_KnifeManufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "KnifeManufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BasketID",
                table: "AspNetUsers",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_Knife_BasketID",
                table: "Knife",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_Knife_ManufacturerID",
                table: "Knife",
                column: "ManufacturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Basket_BasketID",
                table: "AspNetUsers",
                column: "BasketID",
                principalTable: "Basket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Basket_BasketID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Knife");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "KnifeManufacturer");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BasketID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BasketID",
                table: "AspNetUsers");
        }
    }
}
