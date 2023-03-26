using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaDentariaFinalWork.Data.Migrations
{
    /// <inheritdoc />
    public partial class Specialty_Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "ProfessionalTeams");

            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "ProfessionalTeams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "ProfessionalTeams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "ProfessionalTeams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
