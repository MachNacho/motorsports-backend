using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace motorsports_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamDriverRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Driver_TeamID",
                table: "Driver",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Team_TeamID",
                table: "Driver",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Team_TeamID",
                table: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_Driver_TeamID",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Driver");
        }
    }
}
