using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTeeth_BE.Migrations
{
    /// <inheritdoc />
    public partial class FUllName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DortorName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "DortorName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
