using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tech_test_payment_api.Migrations
{
    public partial class AgendaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dbvendas",
                columns: table => new
                {
                    IdVenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusVenda = table.Column<int>(type: "int", nullable: false),
                    IdVendedor = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dbvendas", x => x.IdVenda);
                });

            migrationBuilder.CreateTable(
                name: "DbItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendaIdVenda = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbItems_Dbvendas_VendaIdVenda",
                        column: x => x.VendaIdVenda,
                        principalTable: "Dbvendas",
                        principalColumn: "IdVenda");
                });

            migrationBuilder.InsertData(
                table: "Dbvendas",
                columns: new[] { "IdVenda", "Cpf", "Date", "Email", "IdVendedor", "Nome", "StatusVenda", "Telefone" },
                values: new object[] { 1, "555.666.777-88", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Messias@gmail.com", 1, "Messias", 0, "(81)9 8888-9999" });

            migrationBuilder.CreateIndex(
                name: "IX_DbItems_VendaIdVenda",
                table: "DbItems",
                column: "VendaIdVenda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbItems");

            migrationBuilder.DropTable(
                name: "Dbvendas");
        }
    }
}
