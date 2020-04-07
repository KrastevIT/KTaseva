using Microsoft.EntityFrameworkCore.Migrations;

namespace KTaseva.Data.Migrations
{
    public partial class AddNameInProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Procedures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Procedures");
        }
    }
}
