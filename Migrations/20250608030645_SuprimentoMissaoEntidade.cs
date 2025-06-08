using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gs_drones_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class SuprimentoMissaoEntidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuprimentosMissoes_t_gs_missoes_MissaoId",
                table: "SuprimentosMissoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SuprimentosMissoes_t_gs_suprimentos_SuprimentoId",
                table: "SuprimentosMissoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuprimentosMissoes",
                table: "SuprimentosMissoes");

            migrationBuilder.RenameTable(
                name: "SuprimentosMissoes",
                newName: "t_gs_suprimentos_missao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "t_gs_suprimentos_missao",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SuprimentoId",
                table: "t_gs_suprimentos_missao",
                newName: "suprimento_id");

            migrationBuilder.RenameColumn(
                name: "MissaoId",
                table: "t_gs_suprimentos_missao",
                newName: "missao_id");

            migrationBuilder.RenameIndex(
                name: "IX_SuprimentosMissoes_SuprimentoId",
                table: "t_gs_suprimentos_missao",
                newName: "IX_t_gs_suprimentos_missao_suprimento_id");

            migrationBuilder.RenameIndex(
                name: "IX_SuprimentosMissoes_MissaoId",
                table: "t_gs_suprimentos_missao",
                newName: "IX_t_gs_suprimentos_missao_missao_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_gs_suprimentos_missao",
                table: "t_gs_suprimentos_missao",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_gs_suprimentos_missao_t_gs_missoes_missao_id",
                table: "t_gs_suprimentos_missao",
                column: "missao_id",
                principalTable: "t_gs_missoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_gs_suprimentos_missao_t_gs_suprimentos_suprimento_id",
                table: "t_gs_suprimentos_missao",
                column: "suprimento_id",
                principalTable: "t_gs_suprimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_gs_suprimentos_missao_t_gs_missoes_missao_id",
                table: "t_gs_suprimentos_missao");

            migrationBuilder.DropForeignKey(
                name: "FK_t_gs_suprimentos_missao_t_gs_suprimentos_suprimento_id",
                table: "t_gs_suprimentos_missao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_gs_suprimentos_missao",
                table: "t_gs_suprimentos_missao");

            migrationBuilder.RenameTable(
                name: "t_gs_suprimentos_missao",
                newName: "SuprimentosMissoes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SuprimentosMissoes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "suprimento_id",
                table: "SuprimentosMissoes",
                newName: "SuprimentoId");

            migrationBuilder.RenameColumn(
                name: "missao_id",
                table: "SuprimentosMissoes",
                newName: "MissaoId");

            migrationBuilder.RenameIndex(
                name: "IX_t_gs_suprimentos_missao_suprimento_id",
                table: "SuprimentosMissoes",
                newName: "IX_SuprimentosMissoes_SuprimentoId");

            migrationBuilder.RenameIndex(
                name: "IX_t_gs_suprimentos_missao_missao_id",
                table: "SuprimentosMissoes",
                newName: "IX_SuprimentosMissoes_MissaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuprimentosMissoes",
                table: "SuprimentosMissoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuprimentosMissoes_t_gs_missoes_MissaoId",
                table: "SuprimentosMissoes",
                column: "MissaoId",
                principalTable: "t_gs_missoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuprimentosMissoes_t_gs_suprimentos_SuprimentoId",
                table: "SuprimentosMissoes",
                column: "SuprimentoId",
                principalTable: "t_gs_suprimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
