using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gs_drones_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class MissaoEntidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missoes_t_gs_drones_DroneId",
                table: "Missoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SuprimentosMissoes_Missoes_MissaoId",
                table: "SuprimentosMissoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Missoes",
                table: "Missoes");

            migrationBuilder.RenameTable(
                name: "Missoes",
                newName: "t_gs_missoes");

            migrationBuilder.RenameColumn(
                name: "DroneId",
                table: "t_gs_missoes",
                newName: "drone_id");

            migrationBuilder.RenameIndex(
                name: "IX_Missoes_DroneId",
                table: "t_gs_missoes",
                newName: "IX_t_gs_missoes_drone_id");

            migrationBuilder.AlterColumn<string>(
                name: "st_missao",
                table: "t_gs_missoes",
                type: "NVARCHAR2(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_gs_missoes",
                table: "t_gs_missoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuprimentosMissoes_t_gs_missoes_MissaoId",
                table: "SuprimentosMissoes",
                column: "MissaoId",
                principalTable: "t_gs_missoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_gs_missoes_t_gs_drones_drone_id",
                table: "t_gs_missoes",
                column: "drone_id",
                principalTable: "t_gs_drones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuprimentosMissoes_t_gs_missoes_MissaoId",
                table: "SuprimentosMissoes");

            migrationBuilder.DropForeignKey(
                name: "FK_t_gs_missoes_t_gs_drones_drone_id",
                table: "t_gs_missoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_gs_missoes",
                table: "t_gs_missoes");

            migrationBuilder.RenameTable(
                name: "t_gs_missoes",
                newName: "Missoes");

            migrationBuilder.RenameColumn(
                name: "drone_id",
                table: "Missoes",
                newName: "DroneId");

            migrationBuilder.RenameIndex(
                name: "IX_t_gs_missoes_drone_id",
                table: "Missoes",
                newName: "IX_Missoes_DroneId");

            migrationBuilder.AlterColumn<int>(
                name: "st_missao",
                table: "Missoes",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(12)",
                oldMaxLength: 12);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Missoes",
                table: "Missoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Missoes_t_gs_drones_DroneId",
                table: "Missoes",
                column: "DroneId",
                principalTable: "t_gs_drones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuprimentosMissoes_Missoes_MissaoId",
                table: "SuprimentosMissoes",
                column: "MissaoId",
                principalTable: "Missoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
