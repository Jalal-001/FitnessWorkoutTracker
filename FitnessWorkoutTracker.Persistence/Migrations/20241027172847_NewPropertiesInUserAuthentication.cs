using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWorkoutTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewPropertiesInUserAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserAuthentications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserAuthentications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserAuthentications");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserAuthentications");
        }
    }
}
