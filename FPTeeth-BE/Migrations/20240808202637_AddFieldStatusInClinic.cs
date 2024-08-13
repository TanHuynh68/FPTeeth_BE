using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTeeth_BE.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldStatusInClinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Clinics");
        }
    }
}
