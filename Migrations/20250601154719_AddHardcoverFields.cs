using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicResourceApp.Migrations
{
    /// <inheritdoc />
    public partial class AddHardcoverFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetupLocation",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalLocation",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "MeetupLocation",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "PhysicalLocation",
                table: "Resources");
        }
    }
}
