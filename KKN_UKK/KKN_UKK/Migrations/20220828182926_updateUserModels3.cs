using Microsoft.EntityFrameworkCore.Migrations;

namespace KKN_UKK.Migrations
{
    public partial class updateUserModels3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_M_Role_M_Users_UserModelsId",
                table: "M_Role");

            migrationBuilder.DropIndex(
                name: "IX_M_Role_UserModelsId",
                table: "M_Role");

            migrationBuilder.DropColumn(
                name: "UserModelsId",
                table: "M_Role");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "M_Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "M_Users");

            migrationBuilder.AddColumn<int>(
                name: "UserModelsId",
                table: "M_Role",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_M_Role_UserModelsId",
                table: "M_Role",
                column: "UserModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_M_Role_M_Users_UserModelsId",
                table: "M_Role",
                column: "UserModelsId",
                principalTable: "M_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
