using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KTaseva.Data.Migrations
{
    public partial class AddInAppointmentTableHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Procedure",
                table: "Appointments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Hour",
                table: "Appointments",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "Procedure",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
