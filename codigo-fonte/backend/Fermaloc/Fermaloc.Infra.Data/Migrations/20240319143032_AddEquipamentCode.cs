using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fermaloc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipamentCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipamentCode",
                table: "Equipaments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipamentCode",
                table: "Equipaments");
        }
    }
}
