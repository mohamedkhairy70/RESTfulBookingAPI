using Microsoft.EntityFrameworkCore.Migrations;

namespace RESTfulBookingAPI.Migrations
{
    public partial class deleteRelationBetweenTripAndReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CompanyInformations_TripId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TripId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "TripName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripName",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TripId",
                table: "Customers",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CompanyInformations_TripId",
                table: "Customers",
                column: "TripId",
                principalTable: "CompanyInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
