using Microsoft.EntityFrameworkCore.Migrations;

namespace Bai043_Migration_Scaffold_EF.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagIdNew",
                table: "tags",
                newName: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "tags",
                newName: "TagIdNew");
        }
    }
}
