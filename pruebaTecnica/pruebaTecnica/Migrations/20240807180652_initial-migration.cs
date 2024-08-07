using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BRPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrpCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodingScheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidityStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidityEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRPs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BRPs");
        }
    }
}
