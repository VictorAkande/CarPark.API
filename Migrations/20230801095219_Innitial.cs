using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPark.API.Migrations
{
    /// <inheritdoc />
    public partial class Innitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntranceFee = table.Column<int>(type: "int", nullable: false),
                    FirstHourCost = table.Column<int>(type: "int", nullable: false),
                    SuccessiveHourCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingTickets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkingRules",
                columns: new[] { "Id", "EntranceFee", "FirstHourCost", "SuccessiveHourCost" },
                values: new object[] { 1, 2, 3, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingRules");

            migrationBuilder.DropTable(
                name: "ParkingTickets");
        }
    }
}
