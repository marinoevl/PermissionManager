using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermissionManager.Infrastructure.Migrations
{
    public partial class ChangeDateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateAT",
                schema: "dbo",
                table: "Permissions",
                newName: "PermissionDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PermissionDate",
                schema: "dbo",
                table: "Permissions",
                newName: "DateAT");
        }
    }
}
