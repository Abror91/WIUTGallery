using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWIUTGallery.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Path = table.Column<string>(maxLength: 255, nullable: true),
                    FolderId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photoes_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2022, 7, 5, 13, 55, 33, 940, DateTimeKind.Local).AddTicks(5268), "Books", new DateTime(2022, 7, 5, 13, 55, 33, 939, DateTimeKind.Local).AddTicks(8479) });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2022, 7, 5, 13, 55, 33, 940, DateTimeKind.Local).AddTicks(5996), "Mountains", new DateTime(2022, 7, 5, 13, 55, 33, 940, DateTimeKind.Local).AddTicks(5991) });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 3, new DateTime(2022, 7, 5, 13, 55, 33, 940, DateTimeKind.Local).AddTicks(6016), "Lakes", new DateTime(2022, 7, 5, 13, 55, 33, 940, DateTimeKind.Local).AddTicks(6015) });

            migrationBuilder.CreateIndex(
                name: "IX_Photoes_FolderId",
                table: "Photoes",
                column: "FolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photoes");

            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
