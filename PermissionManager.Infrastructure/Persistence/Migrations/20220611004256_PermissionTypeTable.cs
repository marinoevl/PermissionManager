using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermissionManager.Infrastructure.Migrations
{
    public partial class PermissionTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_PermissionTypes_PermissionTypeId",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionTypes",
                schema: "dbo",
                table: "PermissionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "PermissionTypes",
                schema: "dbo",
                newName: "PermissionType",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Permissions",
                schema: "dbo",
                newName: "Permission",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_PermissionTypeId",
                schema: "dbo",
                table: "Permission",
                newName: "IX_Permission_PermissionTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionType",
                schema: "dbo",
                table: "PermissionType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                schema: "dbo",
                table: "Permission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_PermissionType_PermissionTypeId",
                schema: "dbo",
                table: "Permission",
                column: "PermissionTypeId",
                principalSchema: "dbo",
                principalTable: "PermissionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_PermissionType_PermissionTypeId",
                schema: "dbo",
                table: "Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionType",
                schema: "dbo",
                table: "PermissionType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                schema: "dbo",
                table: "Permission");

            migrationBuilder.RenameTable(
                name: "PermissionType",
                schema: "dbo",
                newName: "PermissionTypes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Permission",
                schema: "dbo",
                newName: "Permissions",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_PermissionTypeId",
                schema: "dbo",
                table: "Permissions",
                newName: "IX_Permissions_PermissionTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionTypes",
                schema: "dbo",
                table: "PermissionTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                schema: "dbo",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_PermissionTypes_PermissionTypeId",
                schema: "dbo",
                table: "Permissions",
                column: "PermissionTypeId",
                principalSchema: "dbo",
                principalTable: "PermissionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
