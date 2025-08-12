using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 1, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "Manages system modules, allowing users to define, modify, and assign modules available to them based on established roles and permissions.", "fa-solid fa-window-maximize", "Modules", 1, "security/modules", true },
                    { 2, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "Manages the forms available in the system, allowing the creation, modification, and deletion of forms associated with different functionalities and modules.", "fa-solid fa-window-restore", "Forms", 2, "security/forms", true },
                    { 3, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "Allows you to assign specific permissions to users and roles, controlling access to functions, forms, and modules according to the system's needs and security policies.", "fa-solid fa-user-lock", "Permissions", 3, "security/permissions", true },
                    { 4, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "Defines and manages roles within the system, allowing you to assign specific permissions to each role and control access to different application features and resources.", "fa-solid fa-users-gear", "Roles", 4, "security/roles", true },
                    { 5, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "It allows you to manage user information, including its creation, editing, and deletion. It facilitates the assignment of roles and permissions, ensuring controlled access to the system.", "fa-solid fa-users", "Users", 5, "security/users", true },
                    { 6, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "It allows you to manage the information of people associated with the system, such as users, employees, or any other relevant entity. It facilitates the creation, editing, and deletion of records, allowing you to link people to specific roles, modules, and permissions as needed.", "fa-solid fa-user", "Persons", 6, "security/persons", true },
                    { 7, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "This form allows the registration and management of customers within the system. It facilitates the creation, editing, and tracking of customer records, enabling the association of relevant operational data and interactions essential for service delivery and follow-up.", "fa-solid fa-building-user", "Customers", 1, "operational/customers", true }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "The security module manages authentication, roles, permissions, and access to the system's forms and modules, ensuring the control and protection of information.", "Security", true },
                    { 2, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "The operational module manages the system's core functional forms, allowing users to execute day-to-day activities", "Operational", true }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, "0001", new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "Allows the user to query, update, and delete records within the system, granting full access to the management of associated data.", "Reading and writing", true },
                    { 2, "0002", new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "Allows the user to only view records within the system, without permission to perform updates or deletions.", "Reading only", true }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DocumentType", "Email", "FirstLastName", "FirstName", "Gender", "IdentificationNumber", "MiddleName", "Phone", "SecondLastName", "State" },
                values: new object[] { 1, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 1, "mariaalejan1080@gmail.com", "MARIN", "MARIA", 2, "1000000000", "ALEJANDRA", 3243652328L, "HENRIQUEZ", true });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[] { 1, "01", new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "", "SUPERADMIN", true });

            migrationBuilder.InsertData(
                table: "FormModules",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FormId", "ModuleId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 1, 1, true },
                    { 2, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 2, 1, true },
                    { 3, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 3, 1, true },
                    { 4, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 4, 1, true },
                    { 5, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 5, 1, true },
                    { 6, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 6, 1, true },
                    { 7, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 7, 2, true }
                });

            migrationBuilder.InsertData(
                table: "RoleFormPermissions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FormId", "PermissionId", "RoleId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 1, 1, 1, true },
                    { 2, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 2, 1, 1, true },
                    { 3, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 3, 1, 1, true },
                    { 4, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 4, 1, 1, true },
                    { 5, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 5, 1, 1, true },
                    { 6, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 6, 1, 1, true },
                    { 7, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 7, 1, 1, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Password", "PersonId", "State", "Username" },
                values: new object[] { 1, "0001", new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, "202CB962AC59075B964B07152D234B70", 1, true, "mariaalejan1080@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "RoleId", "State", "UserId" },
                values: new object[] { 1, new DateTime(2025, 7, 23, 23, 16, 50, 461, DateTimeKind.Utc).AddTicks(2492), null, 1, true, 1 });

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
                name: "FormModules");

            migrationBuilder.DropTable(
                name: "RoleFormPermissions");

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
