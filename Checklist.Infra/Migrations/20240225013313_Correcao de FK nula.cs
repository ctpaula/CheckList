using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checklist.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaodeFKnula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckListBody_Usuario_SupervisorId",
                table: "CheckListBody");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "CheckListBody",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListBody_Usuario_SupervisorId",
                table: "CheckListBody",
                column: "SupervisorId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckListBody_Usuario_SupervisorId",
                table: "CheckListBody");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "CheckListBody",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListBody_Usuario_SupervisorId",
                table: "CheckListBody",
                column: "SupervisorId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
