using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyUrl.Infra.Migrations
{
    public partial class fixedrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platform_Url_UrlId",
                table: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_Platform_UrlId",
                table: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_Browser_PlatformId",
                table: "Browser");

            migrationBuilder.DropColumn(
                name: "Clicks",
                table: "Click");

            migrationBuilder.RenameColumn(
                name: "UrlId",
                table: "Platform",
                newName: "ClickId");

            migrationBuilder.CreateIndex(
                name: "IX_Platform_ClickId",
                table: "Platform",
                column: "ClickId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Browser_PlatformId",
                table: "Browser",
                column: "PlatformId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Platform_Click_ClickId",
                table: "Platform",
                column: "ClickId",
                principalTable: "Click",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platform_Click_ClickId",
                table: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_Platform_ClickId",
                table: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_Browser_PlatformId",
                table: "Browser");

            migrationBuilder.RenameColumn(
                name: "ClickId",
                table: "Platform",
                newName: "UrlId");

            migrationBuilder.AddColumn<long>(
                name: "Clicks",
                table: "Click",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Platform_UrlId",
                table: "Platform",
                column: "UrlId");

            migrationBuilder.CreateIndex(
                name: "IX_Browser_PlatformId",
                table: "Browser",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Platform_Url_UrlId",
                table: "Platform",
                column: "UrlId",
                principalTable: "Url",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
