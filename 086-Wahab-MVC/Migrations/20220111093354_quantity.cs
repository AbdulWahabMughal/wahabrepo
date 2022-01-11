
using Microsoft.EntityFrameworkCore.Migrations;

namespace _086_Wahab_MVC.Migrations
{
    public partial class quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lname",
                table: "contacts",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "contacts");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "contacts",
                newName: "lname");
        }
    }
}
