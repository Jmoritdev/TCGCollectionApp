using Microsoft.EntityFrameworkCore.Migrations;

namespace TCGCollectionApp.Migrations
{
    public partial class AddFoilOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Foil",
                table: "MTGUserCard",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foil",
                table: "MTGUserCard");
        }
    }
}
