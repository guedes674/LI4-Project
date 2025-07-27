using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplicadaMente.Migrations
{
    /// <inheritdoc />
    public partial class AddManualStepFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManualStep_Quebra_Cabeca_QuebraCabecaId",
                table: "ManualStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManualStep",
                table: "ManualStep");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ManualStep");

            migrationBuilder.RenameTable(
                name: "ManualStep",
                newName: "ManualSteps");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ManualSteps",
                newName: "Imagem");

            migrationBuilder.RenameIndex(
                name: "IX_ManualStep_QuebraCabecaId",
                table: "ManualSteps",
                newName: "IX_ManualSteps_QuebraCabecaId");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "ManualSteps",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ManualSteps",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManualSteps",
                table: "ManualSteps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManualSteps_Quebra_Cabeca_QuebraCabecaId",
                table: "ManualSteps",
                column: "QuebraCabecaId",
                principalTable: "Quebra_Cabeca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManualSteps_Quebra_Cabeca_QuebraCabecaId",
                table: "ManualSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManualSteps",
                table: "ManualSteps");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "ManualSteps");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ManualSteps");

            migrationBuilder.RenameTable(
                name: "ManualSteps",
                newName: "ManualStep");

            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "ManualStep",
                newName: "Image");

            migrationBuilder.RenameIndex(
                name: "IX_ManualSteps_QuebraCabecaId",
                table: "ManualStep",
                newName: "IX_ManualStep_QuebraCabecaId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ManualStep",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManualStep",
                table: "ManualStep",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManualStep_Quebra_Cabeca_QuebraCabecaId",
                table: "ManualStep",
                column: "QuebraCabecaId",
                principalTable: "Quebra_Cabeca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
