using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAppJulia.Migrations
{
    public partial class AddTrains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "login",
                table: "Users",
                newName: "UserLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserLogin",
                table: "Users",
                newName: "login");
        }
    }
}
