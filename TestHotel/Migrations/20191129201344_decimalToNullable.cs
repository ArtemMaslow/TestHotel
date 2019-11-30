using Microsoft.EntityFrameworkCore.Migrations;

namespace TestHotel.Migrations
{
    public partial class decimalToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Visits",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Visits",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
