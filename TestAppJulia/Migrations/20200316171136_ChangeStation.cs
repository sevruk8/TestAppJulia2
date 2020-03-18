using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAppJulia.Migrations
{
    public partial class ChangeStation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DirectionID",
                table: "Stations",
                newName: "DirectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DirectionId",
                table: "Stations",
                newName: "DirectionID");
        }
    }
}
