using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAppJulia.Migrations
{
    public partial class AddEmployes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<int>>(
                name: "Employes",
                table: "Stations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employes",
                table: "Stations");
        }
    }
}
