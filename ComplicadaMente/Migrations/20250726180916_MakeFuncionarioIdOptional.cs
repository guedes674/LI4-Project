using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplicadaMente.Migrations
{
    /// <inheritdoc />
    public partial class MakeFuncionarioIdOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encomenda_Funcionario_ID_Funcionario",
                table: "Encomenda");

            migrationBuilder.DropIndex(
                name: "IX_Encomenda_ID_Funcionario",
                table: "Encomenda");

            migrationBuilder.DropColumn(
                name: "ID_Funcionario",
                table: "Encomenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_Funcionario",
                table: "Encomenda",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Encomenda_ID_Funcionario",
                table: "Encomenda",
                column: "ID_Funcionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Encomenda_Funcionario_ID_Funcionario",
                table: "Encomenda",
                column: "ID_Funcionario",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
