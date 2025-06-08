using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gs_drones_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class SuprimentoEntidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuprimentosMissoes_Suprimentos_SuprimentoId",
                table: "SuprimentosMissoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suprimentos",
                table: "Suprimentos");

            migrationBuilder.RenameTable(
                name: "Suprimentos",
                newName: "t_gs_suprimentos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_gs_suprimentos",
                table: "t_gs_suprimentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuprimentosMissoes_t_gs_suprimentos_SuprimentoId",
                table: "SuprimentosMissoes",
                column: "SuprimentoId",
                principalTable: "t_gs_suprimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuprimentosMissoes_t_gs_suprimentos_SuprimentoId",
                table: "SuprimentosMissoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_gs_suprimentos",
                table: "t_gs_suprimentos");

            migrationBuilder.RenameTable(
                name: "t_gs_suprimentos",
                newName: "Suprimentos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suprimentos",
                table: "Suprimentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuprimentosMissoes_Suprimentos_SuprimentoId",
                table: "SuprimentosMissoes",
                column: "SuprimentoId",
                principalTable: "Suprimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
