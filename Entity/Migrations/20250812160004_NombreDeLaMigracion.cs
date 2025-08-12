using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "CodeDane",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailInstitutional",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Criteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineThematics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineThematics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PopulationGrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CodeDane", "CreatedAt", "EmailInstitutional" },
                values: new object[] { "441001004839", new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769), "mariaa_marinh@soy.sena.com" });

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 12, 11, 0, 3, 802, DateTimeKind.Utc).AddTicks(9769));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "LineThematics");

            migrationBuilder.DropTable(
                name: "PopulationGrade");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropColumn(
                name: "CodeDane",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "EmailInstitutional",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "FormModules",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Gender" },
                values: new object[] { new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), 2 });

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "RoleFormPermissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492));
        }
    }
}
