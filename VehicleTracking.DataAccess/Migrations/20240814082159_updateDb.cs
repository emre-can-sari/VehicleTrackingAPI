using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleTracking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Journeys_DriverId",
                table: "Journeys",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Journeys_Drivers_DriverId",
                table: "Journeys",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journeys_Drivers_DriverId",
                table: "Journeys");

            migrationBuilder.DropIndex(
                name: "IX_Journeys_DriverId",
                table: "Journeys");
        }
    }
}
