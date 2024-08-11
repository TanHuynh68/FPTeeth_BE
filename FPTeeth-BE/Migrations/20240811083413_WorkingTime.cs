using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTeeth_BE.Migrations
{
    /// <inheritdoc />
    public partial class WorkingTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Slot");

            migrationBuilder.AddColumn<int>(
                name: "WorkingDayOfWeek",
                table: "WorkingTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SlotTime",
                table: "Slot",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkingDayOfWeek",
                table: "WorkingTimes");

            migrationBuilder.DropColumn(
                name: "SlotTime",
                table: "Slot");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Slot",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Slot",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
