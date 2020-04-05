using Microsoft.EntityFrameworkCore.Migrations;

namespace KTaseva.Data.Migrations
{
    public partial class RemoveHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Appointments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hour",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
