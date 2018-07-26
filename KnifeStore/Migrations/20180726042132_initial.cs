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
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SKU = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Style = table.Column<int>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knives", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Knives_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Knives",
                columns: new[] { "ID", "Description", "Image", "ManufacturerID", "Model", "Price", "SKU", "Style" },
                values: new object[,]
                {
                    { 1, "One knife to rule them all.", "https://assets.victorinox.com/mam/celum/celum_assets/0dc/26c/8868161683486_celum_129756_2000Wx1750H.jpg", null, "Tinker", 19.99m, "Vic-Tin-01", 1 },
                    { 2, "The best knife you can ever have.", "https://assets.victorinox.com/mam/celum/celum_assets/bcc/3cc/8870039420958_celum_131868_2000Wx1750H.jpg", null, "CyberTool Lite", 109.95m, "Vic-Cyb-Lit-01", 1 },
                    { 3, "The second best knife you can ever have.", "https://assets.victorinox.com/mam/celum/celum_assets/17c/6fc/8921382780958_celum_139682_2000Wx1750H.jpg", null, "Cadet Alox", 24.95m, "Vic-Cad-Alo-01", 1 },
                    { 4, "Like David Bowie, except pointer.", "https://assets.brandfolder.com/rxlnjq51/element@2x.png", null, "Bradly Bowie", 399.99m, "Spy-Bra-Bow-01", 2 },
                    { 5, "This will butter your bread.", "https://assets.brandfolder.com/ogsobg-3cul54-5t2tsa/element@2x.png", null, "Sprig", 209.99m, "Spy-Spr-01", 2 },
                    { 6, "You can buy this one if you are a spy.", "https://assets.brandfolder.com/o83xtl-8lo96w-fuvlw8/element@2x.png", null, "Sustain", 249.99m, "Spy-Sus-01", 2 },
                    { 7, "Butter knife with serrated edges.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", null, "Pro 5in. Z15 Serrated", 59.99m, "Pro-5in-Z15-Ser-01", 0 },
                    { 8, "Another knife.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", null, "TWIN Signature 6in.", 19.99m, "Twi-Sig-6in-01", 0 },
                    { 9, "Four stars.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", null, "Four Star 6in.", 59.99m, "Fou-Sta-6in-01", 0 },
                    { 10, "International travel knife.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Messerbank_2_fcm.jpg/1200px-Messerbank_2_fcm.jpg", null, "International Silvercap 6in.", 9.95m, "Int-Sil-6in-01", 0 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Victorinox" },
                    { 2, "Spyderco" },
                    { 3, "Zwilling J.A. Henckels" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knives_ManufacturerID",
                table: "Knives",
                column: "ManufacturerID");
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
