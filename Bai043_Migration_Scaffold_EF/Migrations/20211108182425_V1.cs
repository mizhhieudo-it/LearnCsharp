using Microsoft.EntityFrameworkCore.Migrations;

namespace Bai043_Migration_Scaffold_EF.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "article",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "article",
                newName: "Title");
        }
    }
}
