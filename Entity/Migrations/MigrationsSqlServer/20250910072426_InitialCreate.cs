using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.Migrations.MigrationsSqlServer
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
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
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeDane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailInstitutional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "FormModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormModules_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleFormPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFormPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleFormPermissions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFormPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFormPermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Icon", "Name", "Order", "Path", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "Vista principal del sistema.", "fa-solid fa-house", "Inicio", 1, "dashboard", true },
                    { 2, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "Gestión de experiencias significativas.", "fa-solid fa-star", "Experiencia", 2, "experiencias", true },
                    { 3, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "Gestión de evaluaciones.", "fa-solid fa-clipboard-check", "Evaluación", 3, "evaluacion", true },
                    { 4, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "Gestión de roles del sistema.", "fa-solid fa-users-gear", "Roles", 4, "security/roles", true },
                    { 5, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "Gestión de usuarios.", "fa-solid fa-users", "Users", 5, "security/users", true },
                    { 6, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "Gestión de personas.", "fa-solid fa-user", "Persons", 6, "security/persons", true },
                    { 7, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "Formulario de seguimiento.", "fa-solid fa-building-user", "Seguimiento", 1, "seguimiento", true }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "El módulo de seguridad gestiona autenticación, roles, permisos y acceso a los formularios del sistema.", "Security", true },
                    { 2, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "El módulo operativo gestiona los formularios funcionales principales del sistema.", "Operational", true }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, "0001", new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "Allows the user to query, update, and delete records within the system, granting full access to the management of associated data.", "Reading and writing", true },
                    { 2, "0002", new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "Allows the user to only view records within the system, without permission to perform updates or deletions.", "Reading only", true }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CodeDane", "CreatedAt", "DeletedAt", "DocumentType", "Email", "EmailInstitutional", "FirstLastName", "FirstName", "IdentificationNumber", "MiddleName", "Phone", "SecondLastName", "State" },
                values: new object[] { 1, "441001004839", new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 1, "mariaalejan1080@gmail.com", "mariaa_marinh@soy.sena.com", "MARIN", "MARIA", "1000000000", "ALEJANDRA", 3243652328L, "HENRIQUEZ", true });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[] { 1, "01", new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "", "SUPERADMIN", true });

            migrationBuilder.InsertData(
                table: "FormModules",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FormId", "ModuleId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 1, 1, true },
                    { 2, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 2, 1, true },
                    { 3, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 3, 1, true },
                    { 4, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 4, 1, true },
                    { 5, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 5, 1, true },
                    { 6, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 6, 1, true },
                    { 7, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 7, 2, true }
                });

            migrationBuilder.InsertData(
                table: "RoleFormPermissions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FormId", "PermissionId", "RoleId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 1, 1, 1, true },
                    { 2, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 2, 1, 1, true },
                    { 3, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 3, 1, 1, true },
                    { 4, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 4, 1, 1, true },
                    { 5, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 5, 1, 1, true },
                    { 6, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 6, 1, 1, true },
                    { 7, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 7, 1, 1, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Password", "PersonId", "State", "Username" },
                values: new object[] { 1, "0001", new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, "202CB962AC59075B964B07152D234B70", 1, true, "mariaalejan1080@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "RoleId", "State", "UserId" },
                values: new object[] { 1, new DateTime(2025, 9, 10, 2, 24, 25, 639, DateTimeKind.Utc).AddTicks(3453), null, 1, true, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_FormModules_FormId",
                table: "FormModules",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormModules_ModuleId",
                table: "FormModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFormPermissions_FormId",
                table: "RoleFormPermissions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFormPermissions_PermissionId",
                table: "RoleFormPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFormPermissions_RoleId",
                table: "RoleFormPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "FormModules");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "LineThematics");

            migrationBuilder.DropTable(
                name: "PopulationGrade");

            migrationBuilder.DropTable(
                name: "RoleFormPermissions");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
