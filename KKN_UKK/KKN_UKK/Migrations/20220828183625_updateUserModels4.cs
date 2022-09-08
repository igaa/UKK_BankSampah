using Microsoft.EntityFrameworkCore.Migrations;

namespace KKN_UKK.Migrations
{
    public partial class updateUserModels4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "M_Users");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "M_Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "M_Users");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "M_Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
