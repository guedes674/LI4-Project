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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(9, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quebra_Cabeca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 130, nullable: false),
                    Imagem = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quebra_Cabeca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Morada = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    ID_Quebra_Cabeca = table.Column<int>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 130, nullable: false),
                    Imagem = table.Column<byte[]>(type: "BLOB", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Preco_Total = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    ID_Utilizador = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_Funcionario = table.Column<int>(type: "INTEGER", nullable: false),
                    Data_Encomenda = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encomenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encomenda_Funcionario_ID_Funcionario",
                        column: x => x.ID_Funcionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ID_Peca = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_Encomenda = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false)
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
                    ID_Encomenda = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_Quebra_Cabeca = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "IX_Encomenda_ID_Funcionario",
                table: "Encomenda",
                column: "ID_Funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Encomenda_ID_Utilizador",
                table: "Encomenda",
                column: "ID_Utilizador");

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
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Utilizador");
        }
    }
}
