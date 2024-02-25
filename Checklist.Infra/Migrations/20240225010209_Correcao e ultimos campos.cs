using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checklist.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Correcaoeultimoscampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckListBody_Executor_ExecutorId",
                table: "CheckListBody");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckListItem_CheckListBody_CheckListBodyId",
                table: "CheckListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckListItem_Pergunta_PerguntaId",
                table: "CheckListItem");

            migrationBuilder.DropTable(
                name: "Executor");

            migrationBuilder.AddColumn<bool>(
                name: "EstaChecado",
                table: "CheckListItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "CheckListItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PassouCheck",
                table: "CheckListItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "CheckListBody",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorCheckList = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckListBody_SupervisorId",
                table: "CheckListBody",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListBody_Usuario_ExecutorId",
                table: "CheckListBody",
                column: "ExecutorId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListBody_Usuario_SupervisorId",
                table: "CheckListBody",
                column: "SupervisorId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListItem_CheckListBody_CheckListBodyId",
                table: "CheckListItem",
                column: "CheckListBodyId",
                principalTable: "CheckListBody",
                principalColumn: "CheckListBodyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListItem_Pergunta_PerguntaId",
                table: "CheckListItem",
                column: "PerguntaId",
                principalTable: "Pergunta",
                principalColumn: "PerguntaId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckListBody_Usuario_ExecutorId",
                table: "CheckListBody");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckListBody_Usuario_SupervisorId",
                table: "CheckListBody");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckListItem_CheckListBody_CheckListBodyId",
                table: "CheckListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckListItem_Pergunta_PerguntaId",
                table: "CheckListItem");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_CheckListBody_SupervisorId",
                table: "CheckListBody");

            migrationBuilder.DropColumn(
                name: "EstaChecado",
                table: "CheckListItem");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "CheckListItem");

            migrationBuilder.DropColumn(
                name: "PassouCheck",
                table: "CheckListItem");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "CheckListBody");

            migrationBuilder.CreateTable(
                name: "Executor",
                columns: table => new
                {
                    ExecutorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executor", x => x.ExecutorId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListBody_Executor_ExecutorId",
                table: "CheckListBody",
                column: "ExecutorId",
                principalTable: "Executor",
                principalColumn: "ExecutorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListItem_CheckListBody_CheckListBodyId",
                table: "CheckListItem",
                column: "CheckListBodyId",
                principalTable: "CheckListBody",
                principalColumn: "CheckListBodyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListItem_Pergunta_PerguntaId",
                table: "CheckListItem",
                column: "PerguntaId",
                principalTable: "Pergunta",
                principalColumn: "PerguntaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
