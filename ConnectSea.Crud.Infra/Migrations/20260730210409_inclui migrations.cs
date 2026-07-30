using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConnectSea.Crud.Infra.Migrations
{
    /// <inheritdoc />
    public partial class incluimigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "escalas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Navio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Porto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Eta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Etb = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Etd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escalas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "manifestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Navio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PortoOrigem = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PortoDestino = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manifestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "manifesto_escalas",
                columns: table => new
                {
                    ManifestoId = table.Column<int>(type: "integer", nullable: false),
                    EscalaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manifesto_escalas", x => new { x.ManifestoId, x.EscalaId });
                    table.ForeignKey(
                        name: "FK_manifesto_escalas_escalas_EscalaId",
                        column: x => x.EscalaId,
                        principalTable: "escalas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manifesto_escalas_manifestos_ManifestoId",
                        column: x => x.ManifestoId,
                        principalTable: "manifestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_manifesto_escalas_EscalaId",
                table: "manifesto_escalas",
                column: "EscalaId");

            migrationBuilder.CreateIndex(
                name: "IX_manifestos_Numero",
                table: "manifestos",
                column: "Numero",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "manifesto_escalas");

            migrationBuilder.DropTable(
                name: "escalas");

            migrationBuilder.DropTable(
                name: "manifestos");
        }
    }
}
