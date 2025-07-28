using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplicadaMente.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quebra_Cabeca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false),
                    Imagem = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quebra_Cabeca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManualSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false),
                    QuebraCabecaId = table.Column<int>(type: "int", nullable: false),
                    StepNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualSteps_Quebra_Cabeca_QuebraCabecaId",
                        column: x => x.QuebraCabecaId,
                        principalTable: "Quebra_Cabeca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Peca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    ID_Quebra_Cabeca = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false),
                    Imagem = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peca_Quebra_Cabeca_ID_Quebra_Cabeca",
                        column: x => x.ID_Quebra_Cabeca,
                        principalTable: "Quebra_Cabeca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Encomenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Preco_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ID_Utilizador = table.Column<int>(type: "int", nullable: false),
                    Data_Encomenda = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encomenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encomenda_Utilizador_ID_Utilizador",
                        column: x => x.ID_Utilizador,
                        principalTable: "Utilizador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Peca_Encomenda",
                columns: table => new
                {
                    ID_Peca = table.Column<int>(type: "int", nullable: false),
                    ID_Encomenda = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peca_Encomenda", x => new { x.ID_Encomenda, x.ID_Peca });
                    table.ForeignKey(
                        name: "FK_Peca_Encomenda_Encomenda_ID_Encomenda",
                        column: x => x.ID_Encomenda,
                        principalTable: "Encomenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Peca_Encomenda_Peca_ID_Peca",
                        column: x => x.ID_Peca,
                        principalTable: "Peca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quebra_Cabeca_Encomenda",
                columns: table => new
                {
                    ID_Encomenda = table.Column<int>(type: "int", nullable: false),
                    ID_Quebra_Cabeca = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quebra_Cabeca_Encomenda", x => new { x.ID_Encomenda, x.ID_Quebra_Cabeca });
                    table.ForeignKey(
                        name: "FK_Quebra_Cabeca_Encomenda_Encomenda_ID_Encomenda",
                        column: x => x.ID_Encomenda,
                        principalTable: "Encomenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quebra_Cabeca_Encomenda_Quebra_Cabeca_ID_Quebra_Cabeca",
                        column: x => x.ID_Quebra_Cabeca,
                        principalTable: "Quebra_Cabeca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Encomenda_ID_Utilizador",
                table: "Encomenda",
                column: "ID_Utilizador");

            migrationBuilder.CreateIndex(
                name: "IX_ManualSteps_QuebraCabecaId",
                table: "ManualSteps",
                column: "QuebraCabecaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peca_ID_Quebra_Cabeca",
                table: "Peca",
                column: "ID_Quebra_Cabeca");

            migrationBuilder.CreateIndex(
                name: "IX_Peca_Encomenda_ID_Peca",
                table: "Peca_Encomenda",
                column: "ID_Peca");

            migrationBuilder.CreateIndex(
                name: "IX_Quebra_Cabeca_Encomenda_ID_Quebra_Cabeca",
                table: "Quebra_Cabeca_Encomenda",
                column: "ID_Quebra_Cabeca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "ManualSteps");

            migrationBuilder.DropTable(
                name: "Peca_Encomenda");

            migrationBuilder.DropTable(
                name: "Quebra_Cabeca_Encomenda");

            migrationBuilder.DropTable(
                name: "Peca");

            migrationBuilder.DropTable(
                name: "Encomenda");

            migrationBuilder.DropTable(
                name: "Quebra_Cabeca");

            migrationBuilder.DropTable(
                name: "Utilizador");
        }
    }
}
