using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaDentariaFinalWork.Data.Migrations
{
    /// <inheritdoc />
    public partial class PositionCretion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Invoices_InvoiceID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_InvoiceID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "Appointments");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Invoices",
                type: "money",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentID",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppointmentID1",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalTeamID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PositionProfessionalTeam",
                columns: table => new
                {
                    PositionSelectID = table.Column<int>(type: "int", nullable: false),
                    ProfessionalTeamsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionProfessionalTeam", x => new { x.PositionSelectID, x.ProfessionalTeamsID });
                    table.ForeignKey(
                        name: "FK_PositionProfessionalTeam_Positions_PositionSelectID",
                        column: x => x.PositionSelectID,
                        principalTable: "Positions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionProfessionalTeam_ProfessionalTeams_ProfessionalTeamsID",
                        column: x => x.ProfessionalTeamsID,
                        principalTable: "ProfessionalTeams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Specialties_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalTeamSpecialty",
                columns: table => new
                {
                    ProfessionalTeamsID = table.Column<int>(type: "int", nullable: false),
                    SpecialtiesSelectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalTeamSpecialty", x => new { x.ProfessionalTeamsID, x.SpecialtiesSelectID });
                    table.ForeignKey(
                        name: "FK_ProfessionalTeamSpecialty_ProfessionalTeams_ProfessionalTeamsID",
                        column: x => x.ProfessionalTeamsID,
                        principalTable: "ProfessionalTeams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessionalTeamSpecialty_Specialties_SpecialtiesSelectID",
                        column: x => x.SpecialtiesSelectID,
                        principalTable: "Specialties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_AppointmentID1",
                table: "Invoices",
                column: "AppointmentID1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientID",
                table: "Invoices",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProfessionalTeamID",
                table: "Appointments",
                column: "ProfessionalTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_PositionProfessionalTeam_ProfessionalTeamsID",
                table: "PositionProfessionalTeam",
                column: "ProfessionalTeamsID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalTeamSpecialty_SpecialtiesSelectID",
                table: "ProfessionalTeamSpecialty",
                column: "SpecialtiesSelectID");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_PositionId",
                table: "Specialties",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ProfessionalTeams_ProfessionalTeamID",
                table: "Appointments",
                column: "ProfessionalTeamID",
                principalTable: "ProfessionalTeams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Appointments_AppointmentID1",
                table: "Invoices",
                column: "AppointmentID1",
                principalTable: "Appointments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clients_ClientID",
                table: "Invoices",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ProfessionalTeams_ProfessionalTeamID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Appointments_AppointmentID1",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clients_ClientID",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "PositionProfessionalTeam");

            migrationBuilder.DropTable(
                name: "ProfessionalTeamSpecialty");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_AppointmentID1",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ClientID",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ProfessionalTeamID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AppointmentID1",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ProfessionalTeamID",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Invoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_InvoiceID",
                table: "Appointments",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Invoices_InvoiceID",
                table: "Appointments",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "ID");
        }
    }
}
