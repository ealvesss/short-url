using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyUrl.Infra.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "sequence-Click");

            migrationBuilder.CreateSequence(
                name: "sequence-Url");

            migrationBuilder.CreateTable(
                name: "Url",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShortUrl = table.Column<string>(type: "text", nullable: false),
                    OriginalUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Url", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Click",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClickedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Clicks = table.Column<long>(type: "bigint", nullable: false),
                    UrlId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Click", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Click_Url_UrlId",
                        column: x => x.UrlId,
                        principalTable: "Url",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Browser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UrlId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClickId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Browser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Browser_Click_ClickId",
                        column: x => x.ClickId,
                        principalTable: "Click",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Browser_Url_UrlId",
                        column: x => x.UrlId,
                        principalTable: "Url",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UrlId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClickId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Platform_Click_ClickId",
                        column: x => x.ClickId,
                        principalTable: "Click",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Platform_Url_UrlId",
                        column: x => x.UrlId,
                        principalTable: "Url",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Browser_ClickId",
                table: "Browser",
                column: "ClickId");

            migrationBuilder.CreateIndex(
                name: "IX_Browser_UrlId",
                table: "Browser",
                column: "UrlId");

            migrationBuilder.CreateIndex(
                name: "IX_Click_UrlId",
                table: "Click",
                column: "UrlId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platform_ClickId",
                table: "Platform",
                column: "ClickId");

            migrationBuilder.CreateIndex(
                name: "IX_Platform_UrlId",
                table: "Platform",
                column: "UrlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Browser");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropTable(
                name: "Click");

            migrationBuilder.DropTable(
                name: "Url");

            migrationBuilder.DropSequence(
                name: "sequence-Click");

            migrationBuilder.DropSequence(
                name: "sequence-Url");
        }
    }
}
