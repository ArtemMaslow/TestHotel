using Microsoft.EntityFrameworkCore.Migrations;

namespace TestHotel.Migrations
{
    public partial class ChangeNameOfClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Customers_ClientId",
                table: "Visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Clietns");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clietns",
                table: "Clietns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Clietns_ClientId",
                table: "Visits",
                column: "ClientId",
                principalTable: "Clietns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Clietns_ClientId",
                table: "Visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clietns",
                table: "Clietns");

            migrationBuilder.RenameTable(
                name: "Clietns",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Customers_ClientId",
                table: "Visits",
                column: "ClientId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
