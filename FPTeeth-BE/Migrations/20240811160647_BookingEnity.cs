using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTeeth_BE.Migrations
{
    /// <inheritdoc />
    public partial class BookingEnity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ClinicServices_ClinicServiceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_customerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Bookings_BookingId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ClinicServiceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ClinicServiceId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Bookings",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_customerId",
                table: "Bookings",
                newName: "IX_Bookings_CustomerId");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookingAddress",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BookingName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClinicsServiceId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClinicsServiceId",
                table: "Bookings",
                column: "ClinicsServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ClinicServices_ClinicsServiceId",
                table: "Bookings",
                column: "ClinicsServiceId",
                principalTable: "ClinicServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Bookings_BookingId",
                table: "Medicines",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ClinicServices_ClinicsServiceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Bookings_BookingId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ClinicsServiceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingAddress",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ClinicsServiceId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Bookings",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                newName: "IX_Bookings_customerId");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "Medicines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClinicServiceId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClinicServiceId",
                table: "Bookings",
                column: "ClinicServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ClinicServices_ClinicServiceId",
                table: "Bookings",
                column: "ClinicServiceId",
                principalTable: "ClinicServices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_customerId",
                table: "Bookings",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Bookings_BookingId",
                table: "Medicines",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
