using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Desafio.ApiPublica.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DevedorId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Multa = table.Column<decimal>(type: "NUMERIC(10,2)", precision: 10, scale: 2, nullable: false),
                    JurosAoMes = table.Column<decimal>(type: "NUMERIC(10,2)", precision: 10, scale: 2, nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divida_Devedor_DevedorId",
                        column: x => x.DevedorId,
                        principalTable: "Devedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parcela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DividaId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    Valor = table.Column<decimal>(type: "NUMERIC(10,2)", precision: 10, scale: 2, nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcela_Divida_DividaId",
                        column: x => x.DividaId,
                        principalTable: "Divida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Divida_DevedorId",
                table: "Divida",
                column: "DevedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Divida_Numero",
                table: "Divida",
                column: "Numero");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_DividaId",
                table: "Parcela",
                column: "DividaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcela");

            migrationBuilder.DropTable(
                name: "Divida");

            migrationBuilder.DropTable(
                name: "Devedor");
        }
    }
}
