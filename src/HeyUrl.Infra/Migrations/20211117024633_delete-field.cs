using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyUrl.Infra.Migrations
{
    public partial class deletefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Browser_Click_ClickId",
                table: "Browser");

            migrationBuilder.DropForeignKey(
                name: "FK_Platform_Click_ClickId",
                table: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_Platform_ClickId",
                table: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_Browser_ClickId",
                table: "Browser");

            migrationBuilder.DropColumn(
                name: "ClickId",
                table: "Platform");

            migrationBuilder.DropColumn(
                name: "ClickId",
                table: "Browser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClickId",
                table: "Platform",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClickId",
                table: "Browser",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platform_ClickId",
                table: "Platform",
                column: "ClickId");

            migrationBuilder.CreateIndex(
                name: "IX_Browser_ClickId",
                table: "Browser",
                column: "ClickId");

            migrationBuilder.AddForeignKey(
                name: "FK_Browser_Click_ClickId",
                table: "Browser",
                column: "ClickId",
                principalTable: "Click",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Platform_Click_ClickId",
                table: "Platform",
                column: "ClickId",
                principalTable: "Click",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
