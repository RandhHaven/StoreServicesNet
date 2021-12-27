using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreServices.Api.ShoppingCart.Migrations
{
    public partial class MigrationsInitialShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartSession",
                columns: table => new
                {
                    CartSessionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartSession", x => x.CartSessionID);
                });

            migrationBuilder.CreateTable(
                name: "CartSessionDetail",
                columns: table => new
                {
                    CartSessionDetailID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ProductSelected = table.Column<string>(nullable: true),
                    CartSessionID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartSessionDetail", x => x.CartSessionDetailID);
                    table.ForeignKey(
                        name: "FK_CartSessionDetail_CartSession_CartSessionID",
                        column: x => x.CartSessionID,
                        principalTable: "CartSession",
                        principalColumn: "CartSessionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartSessionDetail_CartSessionID",
                table: "CartSessionDetail",
                column: "CartSessionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartSessionDetail");

            migrationBuilder.DropTable(
                name: "CartSession");
        }
    }
}
