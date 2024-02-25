using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checklist.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Executor",
                columns: table => new
                {
                    ExecutorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executor", x => x.ExecutorId);
                });

            migrationBuilder.CreateTable(
                name: "Pergunta",
                columns: table => new
                {
                    PerguntaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Questao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parametro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pergunta", x => x.PerguntaId);
                });

            migrationBuilder.CreateTable(
                name: "CheckListBody",
                columns: table => new
                {
                    CheckListBodyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutorId = table.Column<int>(type: "int", nullable: false),
                    DataInicioExecucao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFimExecucao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListBody", x => x.CheckListBodyId);
                    table.ForeignKey(
                        name: "FK_CheckListBody_Executor_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Executor",
                        principalColumn: "ExecutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckListItem",
                columns: table => new
                {
                    CheckListItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckListBodyId = table.Column<int>(type: "int", nullable: false),
                    PerguntaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListItem", x => x.CheckListItemId);
                    table.ForeignKey(
                        name: "FK_CheckListItem_CheckListBody_CheckListBodyId",
                        column: x => x.CheckListBodyId,
                        principalTable: "CheckListBody",
                        principalColumn: "CheckListBodyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckListItem_Pergunta_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Pergunta",
                        principalColumn: "PerguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckListBody_ExecutorId",
                table: "CheckListBody",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListItem_CheckListBodyId",
                table: "CheckListItem",
                column: "CheckListBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListItem_PerguntaId",
                table: "CheckListItem",
                column: "PerguntaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListItem");

            migrationBuilder.DropTable(
                name: "CheckListBody");

            migrationBuilder.DropTable(
                name: "Pergunta");

            migrationBuilder.DropTable(
                name: "Executor");
        }
    }
}
