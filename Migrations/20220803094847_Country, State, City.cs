using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.Migrations
{
    public partial class CountryStateCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AddressBook");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AddressBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AddressBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AddressBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AddressBook");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AddressBook");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AddressBook");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AddressBook",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
