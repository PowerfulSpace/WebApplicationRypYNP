using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationRypYNP.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VNAIMP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VNAIMK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DREG = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NMNS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VMNS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CKODSOST = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VKODS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DLIKV = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VLIKV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payers");
        }
    }
}
