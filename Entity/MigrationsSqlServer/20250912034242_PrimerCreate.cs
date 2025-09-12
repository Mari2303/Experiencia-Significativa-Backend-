using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.MigrationsSqlServer
{
    /// <inheritdoc />
    public partial class PrimerCreate : Migration
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
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameRector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caracteristic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerritorialEntity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestsKnow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailInstitucional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Commune = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineThematics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameExperiences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Methodologias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tranfer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Developmenttime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recognition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThemeExperienceArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoordinationTransversalProjects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PedagogicalStrategies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coverage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperiencesCovidPandemic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InstitucionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Institutions_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiences_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlPdf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Evaluations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceGrades_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceGrades_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceLineThematics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    LineThematicId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceLineThematics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceLineThematics_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceLineThematics_LineThematics_LineThematicId",
                        column: x => x.LineThematicId,
                        principalTable: "LineThematics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperiencePopulation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    PopulationGradeId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperiencePopulation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperiencePopulation_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperiencePopulation_PopulationGrade_PopulationGradeId",
                        column: x => x.PopulationGradeId,
                        principalTable: "PopulationGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryExperiences_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryExperiences_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoryExperiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionProblem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnfoqueExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InnovationExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResulsExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SustainabilityExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaphoricalPhrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Testimony = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dissemination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectives_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "verifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    ExperienceId1 = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_verifications_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_verifications_Experiences_ExperienceId1",
                        column: x => x.ExperienceId1,
                        principalTable: "Experiences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCriterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    EvaluationId = table.Column<int>(type: "int", nullable: false),
                    CriteriaId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationCriterias_Criteria_CriteriaId",
                        column: x => x.CriteriaId,
                        principalTable: "Criteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationCriterias_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Criteria",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Name", "State" },
                values: new object[,]
                {
                    { 1, "01", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Pertinencia", true },
                    { 2, "02", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Fundamentación", true },
                    { 3, "03", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Innovación", true },
                    { 4, "04", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Resultados", true },
                    { 5, "05", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Empoderamiento", true },
                    { 6, "06", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Seguimiento y valoración", true },
                    { 7, "07", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Transformación", true },
                    { 8, "08", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Sostenibilidad", true },
                    { 9, "09", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Transferencia", true }
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Icon", "Name", "Order", "Path", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Vista principal del sistema.", "fa-solid fa-house", "Inicio", 1, "dashboard", true },
                    { 2, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Gestión de experiencias significativas.", "fa-solid fa-star", "Experiencia", 2, "experiencias", true },
                    { 3, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Gestión de evaluaciones.", "fa-solid fa-clipboard-check", "Evaluación", 3, "evaluacion", true },
                    { 4, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Gestión de roles del sistema.", "fa-solid fa-users-gear", "Roles", 4, "security/roles", true },
                    { 5, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Gestión de usuarios.", "fa-solid fa-users", "Users", 5, "security/users", true },
                    { 6, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Gestión de personas.", "fa-solid fa-user", "Persons", 6, "security/persons", true },
                    { 7, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Formulario de seguimiento.", "fa-solid fa-building-user", "Seguimiento", 1, "seguimiento", true }
                });

            migrationBuilder.InsertData(
                table: "LineThematics",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Name", "State" },
                values: new object[,]
                {
                    { 1, "01", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Ciencia y Tecnología", true },
                    { 2, "02", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Educación Ambiental", true },
                    { 3, "03", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Interculturalidad Bilingüismo", true },
                    { 4, "04", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Arte, Cultura y Patrimonio", true },
                    { 5, "05", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Habilidades Comunicativas", true },
                    { 6, "06", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Academica Curricular", true },
                    { 7, "07", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Inclusion Diversidad", true },
                    { 8, "08", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Convivencia Escolar (Ciencias Sociales y Políticas)", true },
                    { 9, "09", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Danza, Deporte y Recreación", true }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "El módulo de seguridad gestiona autenticación, roles, permisos y acceso a los formularios del sistema.", "Security", true },
                    { 2, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "El módulo operativo gestiona los formularios funcionales principales del sistema.", "Operational", true }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, "0001", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Allows the user to query, update, and delete records within the system, granting full access to the management of associated data.", "Reading and writing", true },
                    { 2, "0002", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Allows the user to only view records within the system, without permission to perform updates or deletions.", "Reading only", true }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CodeDane", "CreatedAt", "DeletedAt", "DocumentType", "Email", "EmailInstitutional", "FirstLastName", "FirstName", "IdentificationNumber", "MiddleName", "Phone", "SecondLastName", "State" },
                values: new object[,]
                {
                    { 1, "441001004839", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 1, "mariaalejan1080@gmail.com", "mariaa_marinh@soy.sena.com", "MARIN", "MARIA", "1000000000", "ALEJANDRA", 3243652328L, "HENRIQUEZ", true },
                    { 2, "441001004840", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 1, "juan.perez@correo.com", "juan_perez@soy.sena.com", "PEREZ", "JUAN", "2000000000", "CARLOS", 3123456789L, "GOMEZ", true }
                });

            migrationBuilder.InsertData(
                table: "PopulationGrade",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Name", "State" },
                values: new object[,]
                {
                    { 1, "01", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Indigenas", true },
                    { 2, "02", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Afrocolombianos", true },
                    { 3, "03", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Mestizos", true },
                    { 4, "04", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Palenqueros", true },
                    { 5, "05", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Pequeños Productores", true },
                    { 6, "06", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Raizales", true },
                    { 7, "07", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Rom", true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "Path", "State" },
                values: new object[,]
                {
                    { 1, "01", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "", "SUPERADMIN", "dashboard", true },
                    { 2, "0002", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Rol para profesores", "Profesor", "dashboardTeacher", true }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Name", "State" },
                values: new object[,]
                {
                    { 1, "01", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Naciente", true },
                    { 2, "02", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Creciente", true },
                    { 3, "03", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "Inspiradora", true }
                });

            migrationBuilder.InsertData(
                table: "FormModules",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FormId", "ModuleId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 1, 1, true },
                    { 2, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 2, 1, true },
                    { 3, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 3, 1, true },
                    { 4, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 4, 1, true },
                    { 5, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 5, 1, true },
                    { 6, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 6, 1, true },
                    { 7, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 7, 2, true }
                });

            migrationBuilder.InsertData(
                table: "RoleFormPermissions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FormId", "PermissionId", "RoleId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 1, 1, 1, true },
                    { 2, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 2, 1, 1, true },
                    { 3, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 3, 1, 1, true },
                    { 4, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 4, 1, 1, true },
                    { 5, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 5, 1, 1, true },
                    { 6, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 6, 1, 1, true },
                    { 7, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 7, 1, 1, true },
                    { 100, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 1, 2, 2, true },
                    { 101, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 2, 2, 2, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Password", "PersonId", "State", "Username" },
                values: new object[,]
                {
                    { 1, "0001", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "202CB962AC59075B964B07152D234B70", 1, true, "mariaalejan1080@gmail.com" },
                    { 2, "0002", new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, "202CB962AC59075B964B07152D234B70", 2, true, "juan.perez@correo.com" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "RoleId", "State", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 1, true, 1 },
                    { 2, new DateTime(2025, 9, 11, 22, 42, 41, 868, DateTimeKind.Utc).AddTicks(1969), null, 2, true, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ExperienceId",
                table: "Documents",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCriterias_CriteriaId",
                table: "EvaluationCriterias",
                column: "CriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCriterias_EvaluationId",
                table: "EvaluationCriterias",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ExperienceId",
                table: "Evaluations",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StateId",
                table: "Evaluations",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_UserId",
                table: "Evaluations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceGrades_ExperienceId",
                table: "ExperienceGrades",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceGrades_GradeId",
                table: "ExperienceGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceLineThematics_ExperienceId",
                table: "ExperienceLineThematics",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceLineThematics_LineThematicId",
                table: "ExperienceLineThematics",
                column: "LineThematicId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencePopulation_ExperienceId",
                table: "ExperiencePopulation",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencePopulation_PopulationGradeId",
                table: "ExperiencePopulation",
                column: "PopulationGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_InstitucionId",
                table: "Experiences",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_StateId",
                table: "Experiences",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FormModules_FormId",
                table: "FormModules",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormModules_ModuleId",
                table: "FormModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryExperiences_ExperienceId",
                table: "HistoryExperiences",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryExperiences_StateId",
                table: "HistoryExperiences",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryExperiences_UserId",
                table: "HistoryExperiences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_ExperienceId",
                table: "Objectives",
                column: "ExperienceId");

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

            migrationBuilder.CreateIndex(
                name: "IX_verifications_ExperienceId",
                table: "verifications",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_verifications_ExperienceId1",
                table: "verifications",
                column: "ExperienceId1",
                unique: true,
                filter: "[ExperienceId1] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "EvaluationCriterias");

            migrationBuilder.DropTable(
                name: "ExperienceGrades");

            migrationBuilder.DropTable(
                name: "ExperienceLineThematics");

            migrationBuilder.DropTable(
                name: "ExperiencePopulation");

            migrationBuilder.DropTable(
                name: "FormModules");

            migrationBuilder.DropTable(
                name: "HistoryExperiences");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "RoleFormPermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "verifications");

            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "LineThematics");

            migrationBuilder.DropTable(
                name: "PopulationGrade");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
