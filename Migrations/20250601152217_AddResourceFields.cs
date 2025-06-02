using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicResourceApp.Migrations
{
    /// <inheritdoc />
    public partial class AddResourceFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Format",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Resources");
        }
    }
}
