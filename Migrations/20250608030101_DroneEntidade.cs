using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gs_drones_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class DroneEntidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suprimentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_suprimento = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ds_suprimento = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    peso_kg = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suprimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_gs_drones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_drone = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    tp_drone = table.Column<string>(type: "NVARCHAR2(12)", maxLength: 12, nullable: false),
                    nr_capacidade_kg = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_gs_drones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Missoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_missao = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    dt_inicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    dt_fim = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    st_missao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nr_peso_total = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DroneId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missoes_t_gs_drones_DroneId",
                        column: x => x.DroneId,
                        principalTable: "t_gs_drones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuprimentosMissoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MissaoId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SuprimentoId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    qt_suprimento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuprimentosMissoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuprimentosMissoes_Missoes_MissaoId",
                        column: x => x.MissaoId,
                        principalTable: "Missoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuprimentosMissoes_Suprimentos_SuprimentoId",
                        column: x => x.SuprimentoId,
                        principalTable: "Suprimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Missoes_DroneId",
                table: "Missoes",
                column: "DroneId");

            migrationBuilder.CreateIndex(
                name: "IX_SuprimentosMissoes_MissaoId",
                table: "SuprimentosMissoes",
                column: "MissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SuprimentosMissoes_SuprimentoId",
                table: "SuprimentosMissoes",
                column: "SuprimentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuprimentosMissoes");

            migrationBuilder.DropTable(
                name: "Missoes");

            migrationBuilder.DropTable(
                name: "Suprimentos");

            migrationBuilder.DropTable(
                name: "t_gs_drones");
        }
    }
}
