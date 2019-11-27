using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestHotel.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Phone = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Phone);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Number = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Record = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Arrive = table.Column<DateTime>(nullable: false),
                    Leave = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Record);
                    table.ForeignKey(
                        name: "FK_Visitors_Rooms_Number",
                        column: x => x.Number,
                        principalTable: "Rooms",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visitors_Customers_Phone",
                        column: x => x.Phone,
                        principalTable: "Customers",
                        principalColumn: "Phone",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_Number",
                table: "Visitors",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_Phone",
                table: "Visitors",
                column: "Phone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
