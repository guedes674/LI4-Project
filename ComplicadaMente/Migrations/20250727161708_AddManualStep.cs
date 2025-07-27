using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplicadaMente.Migrations
{
    /// <inheritdoc />
    public partial class AddManualStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManualStep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuebraCabecaId = table.Column<int>(type: "INTEGER", nullable: false),
                    StepNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualStep_Quebra_Cabeca_QuebraCabecaId",
                        column: x => x.QuebraCabecaId,
                        principalTable: "Quebra_Cabeca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManualStep_QuebraCabecaId",
                table: "ManualStep",
                column: "QuebraCabecaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManualStep");
        }
    }
}
