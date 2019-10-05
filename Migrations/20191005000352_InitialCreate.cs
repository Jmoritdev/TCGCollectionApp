using Microsoft.EntityFrameworkCore.Migrations;

namespace TCGCollectionApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MTGSet",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTGSet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MTGCard",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LanguageCode = table.Column<string>(maxLength: 3, nullable: false),
                    OracleID = table.Column<string>(nullable: false),
                    SetID = table.Column<string>(nullable: false),
                    IsFoil = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTGCard", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MTGCard_MTGSet_SetID",
                        column: x => x.SetID,
                        principalTable: "MTGSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MTGCard_SetID",
                table: "MTGCard",
                column: "SetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MTGCard");

            migrationBuilder.DropTable(
                name: "MTGSet");
        }
    }
}
