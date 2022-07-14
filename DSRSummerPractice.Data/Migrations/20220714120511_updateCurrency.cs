using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSRSummerPractice.Data.Migrations
{
    public partial class updateCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CharCode",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharCode",
                table: "Currencies");
        }
    }
}
