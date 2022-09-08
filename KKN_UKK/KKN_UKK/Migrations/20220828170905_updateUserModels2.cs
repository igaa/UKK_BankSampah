using Microsoft.EntityFrameworkCore.Migrations;

namespace KKN_UKK.Migrations
{
    public partial class updateUserModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_M_Employees_M_Users_UserIdId",
                table: "M_Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_M_Nasabah_M_Users_UserIdId",
                table: "M_Nasabah");

            migrationBuilder.DropIndex(
                name: "IX_M_Nasabah_UserIdId",
                table: "M_Nasabah");

            migrationBuilder.DropIndex(
                name: "IX_M_Employees_UserIdId",
                table: "M_Employees");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "M_Nasabah");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "M_Employees");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "M_Nasabah",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "M_Employees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "M_Nasabah");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "M_Employees");

            migrationBuilder.AddColumn<int>(
                name: "UserIdId",
                table: "M_Nasabah",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserIdId",
                table: "M_Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_M_Nasabah_UserIdId",
                table: "M_Nasabah",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_M_Employees_UserIdId",
                table: "M_Employees",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_M_Employees_M_Users_UserIdId",
                table: "M_Employees",
                column: "UserIdId",
                principalTable: "M_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_M_Nasabah_M_Users_UserIdId",
                table: "M_Nasabah",
                column: "UserIdId",
                principalTable: "M_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
