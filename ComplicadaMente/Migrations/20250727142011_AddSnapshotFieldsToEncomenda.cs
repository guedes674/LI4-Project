using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplicadaMente.Migrations
{
    /// <inheritdoc />
    public partial class AddSnapshotFieldsToEncomenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Quebra_Cabeca_Encomenda",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Quebra_Cabeca_Encomenda",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Quebra_Cabeca_Encomenda",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Peca_Encomenda",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Peca_Encomenda",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Peca_Encomenda",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Quebra_Cabeca_Encomenda");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Quebra_Cabeca_Encomenda");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Quebra_Cabeca_Encomenda");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Peca_Encomenda");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Peca_Encomenda");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Peca_Encomenda");
        }
    }
}
