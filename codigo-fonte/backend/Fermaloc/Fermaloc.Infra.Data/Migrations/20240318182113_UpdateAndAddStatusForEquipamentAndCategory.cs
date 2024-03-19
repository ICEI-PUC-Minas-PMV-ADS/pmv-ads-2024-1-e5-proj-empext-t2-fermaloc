using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fermaloc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAndAddStatusForEquipamentAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Equipaments",
                newName: "Status");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Categories",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Equipaments",
                newName: "Active");
        }
    }
}
