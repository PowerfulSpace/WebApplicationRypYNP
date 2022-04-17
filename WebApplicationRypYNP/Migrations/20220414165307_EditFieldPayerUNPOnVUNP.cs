using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationRypYNP.Migrations
{
    public partial class EditFieldPayerUNPOnVUNP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UNP",
                table: "Payers",
                newName: "VUNP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VUNP",
                table: "Payers",
                newName: "UNP");
        }
    }
}
