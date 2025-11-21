using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace motorsports_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adddriverstats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CareerPoints",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChampionshipTitles",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RaceLapsLed",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RacePodiums",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RacePole",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RaceWins",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RacesParticipated",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CareerPoints",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "ChampionshipTitles",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "RaceLapsLed",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "RacePodiums",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "RacePole",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "RaceWins",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "RacesParticipated",
                table: "Driver");
        }
    }
}
