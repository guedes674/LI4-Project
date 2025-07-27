using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplicadaMente.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantidadeToPeca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Quebra_Cabeca",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Peca",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Quebra_Cabeca");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Peca");
        }
    }
}
