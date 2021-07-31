using Microsoft.EntityFrameworkCore.Migrations;

namespace RESTfulBookingAPI.Migrations
{
    public partial class updateNameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCompany",
                table: "UsersCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyInformations",
                table: "CompanyInformations");

            migrationBuilder.RenameTable(
                name: "UsersCompany",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "CompanyInformations",
                newName: "Trips");

            migrationBuilder.RenameIndex(
                name: "IX_UsersCompany_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trips",
                table: "Trips",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trips",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UsersCompany");

            migrationBuilder.RenameTable(
                name: "Trips",
                newName: "CompanyInformations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "UsersCompany",
                newName: "IX_UsersCompany_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCompany",
                table: "UsersCompany",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyInformations",
                table: "CompanyInformations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");
        }
    }
}
