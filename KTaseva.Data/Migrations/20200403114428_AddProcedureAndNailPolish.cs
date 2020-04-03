using Microsoft.EntityFrameworkCore.Migrations;

namespace KTaseva.Data.Migrations
{
    public partial class AddProcedureAndNailPolish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hour",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NailPolish",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Procedure",
                table: "Appointments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "NailPolish",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Procedure",
                table: "Appointments");
        }
    }
}
