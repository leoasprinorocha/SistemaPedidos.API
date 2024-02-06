using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPedidos.API.Migrations
{
    public partial class CodigoAdesao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CodigoAdesao",
                table: "Adesao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoAdesao",
                table: "Adesao");
        }
    }
}
