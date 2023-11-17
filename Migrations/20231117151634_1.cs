using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORTSocial.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartillas",
                columns: table => new
                {
                    IdCartilla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartillas", x => x.IdCartilla);
                });

            migrationBuilder.CreateTable(
                name: "GruposFamiliares",
                columns: table => new
                {
                    IdGrupoFamiliar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposFamiliares", x => x.IdGrupoFamiliar);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.IdMedico);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    IdPlan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<float>(type: "real", nullable: false),
                    CantFamiliares = table.Column<int>(type: "int", nullable: false),
                    IdCartilla = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.IdPlan);
                    table.ForeignKey(
                        name: "FK_Planes_Cartillas_IdCartilla",
                        column: x => x.IdCartilla,
                        principalTable: "Cartillas",
                        principalColumn: "IdCartilla",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Familiares",
                columns: table => new
                {
                    IdFamiliar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGrupoFamiliar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familiares", x => x.IdFamiliar);
                    table.ForeignKey(
                        name: "FK_Familiares_GruposFamiliares_IdGrupoFamiliar",
                        column: x => x.IdGrupoFamiliar,
                        principalTable: "GruposFamiliares",
                        principalColumn: "IdGrupoFamiliar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartillasMedicos",
                columns: table => new
                {
                    idCartillaMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCartilla = table.Column<int>(type: "int", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartillasMedicos", x => x.idCartillaMedico);
                    table.ForeignKey(
                        name: "FK_CartillasMedicos_Cartillas_IdCartilla",
                        column: x => x.IdCartilla,
                        principalTable: "Cartillas",
                        principalColumn: "IdCartilla",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartillasMedicos_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    IdSocio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPlan = table.Column<int>(type: "int", nullable: false),
                    IdGrupoFamiliar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.IdSocio);
                    table.ForeignKey(
                        name: "FK_Socios_GruposFamiliares_IdGrupoFamiliar",
                        column: x => x.IdGrupoFamiliar,
                        principalTable: "GruposFamiliares",
                        principalColumn: "IdGrupoFamiliar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Socios_Planes_IdPlan",
                        column: x => x.IdPlan,
                        principalTable: "Planes",
                        principalColumn: "IdPlan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurnosMedicos",
                columns: table => new
                {
                    idTurno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdSocio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnosMedicos", x => x.idTurno);
                    table.ForeignKey(
                        name: "FK_TurnosMedicos_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurnosMedicos_Socios_IdSocio",
                        column: x => x.IdSocio,
                        principalTable: "Socios",
                        principalColumn: "IdSocio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartillasMedicos_IdCartilla",
                table: "CartillasMedicos",
                column: "IdCartilla");

            migrationBuilder.CreateIndex(
                name: "IX_CartillasMedicos_IdMedico",
                table: "CartillasMedicos",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Familiares_IdGrupoFamiliar",
                table: "Familiares",
                column: "IdGrupoFamiliar");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_IdCartilla",
                table: "Planes",
                column: "IdCartilla");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_IdGrupoFamiliar",
                table: "Socios",
                column: "IdGrupoFamiliar");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_IdPlan",
                table: "Socios",
                column: "IdPlan");

            migrationBuilder.CreateIndex(
                name: "IX_TurnosMedicos_IdMedico",
                table: "TurnosMedicos",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_TurnosMedicos_IdSocio",
                table: "TurnosMedicos",
                column: "IdSocio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartillasMedicos");

            migrationBuilder.DropTable(
                name: "Familiares");

            migrationBuilder.DropTable(
                name: "TurnosMedicos");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Socios");

            migrationBuilder.DropTable(
                name: "GruposFamiliares");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Cartillas");
        }
    }
}
