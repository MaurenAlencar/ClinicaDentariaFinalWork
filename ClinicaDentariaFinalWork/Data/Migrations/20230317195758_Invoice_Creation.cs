using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaDentariaFinalWork.Data.Migrations
{
    /// <inheritdoc />
    public partial class Invoice_Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "Clients",
                type: "int",
                nullable: true);

            
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    Procedure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "money", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_InvoiceID",
                table: "Clients",
                column: "InvoiceID");

                       

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Invoices_InvoiceID",
                table: "Clients",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Invoices_InvoiceID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Invoices_InvoiceID",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Clients_InvoiceID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "Clients");

            
        }
    }
}
