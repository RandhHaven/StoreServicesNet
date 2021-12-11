using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreServices.Api.Book.Migrations
{
    public partial class MigrationsInitialBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialLibrary",
                columns: table => new
                {
                    MaterialLibraryID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTittle = table.Column<string>(nullable: true),
                    DatePublish = table.Column<DateTime>(nullable: true),
                    BookAuthor = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialLibrary", x => x.MaterialLibraryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialLibrary");
        }
    }
}
