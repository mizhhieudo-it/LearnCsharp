using Microsoft.EntityFrameworkCore.Migrations;

namespace Bai043_Migration_Scaffold_EF.Migrations
{
    public partial class V5addAT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articleTags",
                columns: table => new
                {
                    ArticleTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    ActicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleTags", x => x.ArticleTagId);
                    table.ForeignKey(
                        name: "FK_articleTags_article_ActicleId",
                        column: x => x.ActicleId,
                        principalTable: "article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articleTags_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articleTags_ActicleId_TagId",
                table: "articleTags",
                columns: new[] { "ActicleId", "TagId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_articleTags_TagId",
                table: "articleTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articleTags");
        }
    }
}
