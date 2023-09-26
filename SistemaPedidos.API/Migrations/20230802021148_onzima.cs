using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPedidos.API.Migrations
{
    public partial class onzima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPlano = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdFormaPagamento = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdAdesao = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EhPlanoMensal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AdesaoClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Adesao_AdesaoClienteId",
                        column: x => x.AdesaoClienteId,
                        principalTable: "Adesao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_AdesaoClienteId",
                table: "Cliente",
                column: "AdesaoClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
