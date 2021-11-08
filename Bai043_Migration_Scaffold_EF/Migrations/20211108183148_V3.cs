using Microsoft.EntityFrameworkCore.Migrations;

namespace Bai043_Migration_Scaffold_EF.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tags",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "tags");

            migrationBuilder.AddColumn<int>(
                name: "TagIdNew",
                table: "tags",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tags",
                table: "tags",
                column: "TagIdNew");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tags",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "TagIdNew",
                table: "tags");

            migrationBuilder.AddColumn<string>(
                name: "TagId",
                table: "tags",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tags",
                table: "tags",
                column: "TagId");
        }
    }
}
