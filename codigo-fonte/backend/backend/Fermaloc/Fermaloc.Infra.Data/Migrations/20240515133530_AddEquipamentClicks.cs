using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fermaloc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipamentClicks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipamentsClicks");

            migrationBuilder.CreateTable(
                name: "EquipamentClicks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NumberOfClicks = table.Column<int>(type: "INT", nullable: false),
                    Date = table.Column<DateOnly>(type: "DATE", nullable: false),
                    EquipamentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentClicks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipamentClicks_Equipaments_EquipamentId",
                        column: x => x.EquipamentId,
                        principalTable: "Equipaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentClicks_EquipamentId",
                table: "EquipamentClicks",
                column: "EquipamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipamentClicks");

            migrationBuilder.CreateTable(
                name: "EquipamentsClicks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EquipamentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    NumberOfClicks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentsClicks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipamentsClicks_Equipaments_EquipamentId",
                        column: x => x.EquipamentId,
                        principalTable: "Equipaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentsClicks_EquipamentId",
                table: "EquipamentsClicks",
                column: "EquipamentId");
        }
    }
}
