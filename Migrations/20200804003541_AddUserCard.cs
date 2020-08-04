using Microsoft.EntityFrameworkCore.Migrations;

namespace TCGCollectionApp.Migrations
{
    public partial class AddUserCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MTGUserCard",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    CardId = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Signed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTGUserCard", x => new { x.CardId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MTGUserCard_MTGCard_CardId",
                        column: x => x.CardId,
                        principalTable: "MTGCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MTGUserCard_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MTGUserCard_UserId",
                table: "MTGUserCard",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MTGUserCard");
        }
    }
}
