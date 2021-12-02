using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StoreServices.Api.Author.Migrations
{
    public partial class migrationsStoreServiceInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookAuthorID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameAuthor = table.Column<string>(nullable: true),
                    LastNameAuthor = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    BookAuthorGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => x.BookAuthorID);
                });

            migrationBuilder.CreateTable(
                name: "AcademicDegree",
                columns: table => new
                {
                    AcademicDegreeID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameGraduate = table.Column<string>(nullable: true),
                    AcademicCenter = table.Column<string>(nullable: true),
                    DateDegree = table.Column<DateTime>(nullable: true),
                    BookAuthorID = table.Column<long>(nullable: true),
                    AcademicDegreeGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegree", x => x.AcademicDegreeID);
                    table.ForeignKey(
                        name: "FK_AcademicDegree_BookAuthor_BookAuthorID",
                        column: x => x.BookAuthorID,
                        principalTable: "BookAuthor",
                        principalColumn: "BookAuthorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicDegree_BookAuthorID",
                table: "AcademicDegree",
                column: "BookAuthorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicDegree");

            migrationBuilder.DropTable(
                name: "BookAuthor");
        }
    }
}
