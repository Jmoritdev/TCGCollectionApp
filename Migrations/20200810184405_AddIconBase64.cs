using Microsoft.EntityFrameworkCore.Migrations;

namespace TCGCollectionApp.Migrations
{
    public partial class AddIconBase64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconSvgBase64",
                table: "MTGSet",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconSvgBase64",
                table: "MTGSet");
        }
    }
}
