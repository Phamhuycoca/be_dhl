using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class noti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Notification");

            migrationBuilder.AddColumn<int>(
                name: "UserIdComment",
                table: "Notification",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIdComment",
                table: "Notification");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Notification",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
