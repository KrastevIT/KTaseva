using Microsoft.EntityFrameworkCore.Migrations;

namespace KTaseva.Data.Migrations
{
    public partial class AddRelProcedureAndAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Procedure",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "ProcedureId",
                table: "Appointments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProcedureId",
                table: "Appointments",
                column: "ProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Procedures_ProcedureId",
                table: "Appointments",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Procedures_ProcedureId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ProcedureId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ProcedureId",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "Procedure",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
