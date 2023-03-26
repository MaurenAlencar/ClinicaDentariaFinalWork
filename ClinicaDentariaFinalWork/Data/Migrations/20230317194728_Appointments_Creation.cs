using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaDentariaFinalWork.Data.Migrations
{
    /// <inheritdoc />
    public partial class Appointments_Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentID",
                table: "ProfessionalTeams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Performed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalTeams_AppointmentID",
                table: "ProfessionalTeams",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientID",
                table: "Appointments",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalTeams_Appointments_AppointmentID",
                table: "ProfessionalTeams",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalTeams_Appointments_AppointmentID",
                table: "ProfessionalTeams");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalTeams_AppointmentID",
                table: "ProfessionalTeams");

            migrationBuilder.DropColumn(
                name: "AppointmentID",
                table: "ProfessionalTeams");
        }
    }
}
