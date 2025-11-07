using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace motorsports_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetrackentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RaceTrack",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "RaceTrack",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "RaceTrack");

            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "RaceTrack");
        }
    }
}
