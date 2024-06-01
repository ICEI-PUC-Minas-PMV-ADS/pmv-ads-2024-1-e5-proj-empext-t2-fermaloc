using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fermaloc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPropClickInEquipamentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfClicks",
                table: "Equipaments",
                type: "BIGINT",
                nullable: false);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfClicks",
                table: "Equipaments"
            );

        }
    }
}
