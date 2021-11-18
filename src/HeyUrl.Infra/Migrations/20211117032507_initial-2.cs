using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyUrl.Infra.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Browser_Url_UrlId",
                table: "Browser");

            migrationBuilder.DropIndex(
                name: "IX_Click_UrlId",
                table: "Click");

            migrationBuilder.RenameColumn(
                name: "UrlId",
                table: "Browser",
                newName: "PlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_Browser_UrlId",
                table: "Browser",
                newName: "IX_Browser_PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Click_UrlId",
                table: "Click",
                column: "UrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_Browser_Platform_PlatformId",
                table: "Browser",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Browser_Platform_PlatformId",
                table: "Browser");

            migrationBuilder.DropIndex(
                name: "IX_Click_UrlId",
                table: "Click");

            migrationBuilder.RenameColumn(
                name: "PlatformId",
                table: "Browser",
                newName: "UrlId");

            migrationBuilder.RenameIndex(
                name: "IX_Browser_PlatformId",
                table: "Browser",
                newName: "IX_Browser_UrlId");

            migrationBuilder.CreateIndex(
                name: "IX_Click_UrlId",
                table: "Click",
                column: "UrlId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Browser_Url_UrlId",
                table: "Browser",
                column: "UrlId",
                principalTable: "Url",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
