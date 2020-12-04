using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TextSaverWebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TextEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartedTexts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    PartNumber = table.Column<int>(nullable: false),
                    TextEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartedTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartedTexts_TextEntities_TextEntityId",
                        column: x => x.TextEntityId,
                        principalTable: "TextEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartedTexts_TextEntityId",
                table: "PartedTexts",
                column: "TextEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartedTexts");

            migrationBuilder.DropTable(
                name: "TextEntities");
        }
    }
}
