using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PorterWebApi.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condominios",
                columns: table => new
                {
                    CondominioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    EmailSindico = table.Column<string>(type: "varchar(50)", nullable: false),
                    TelefoneSindico = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominios", x => x.CondominioId);
                });

            migrationBuilder.CreateTable(
                name: "Blocos",
                columns: table => new
                {
                    BlocoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    CondominioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocos", x => x.BlocoId);
                    table.ForeignKey(
                        name: "FK_Blocos_Condominios_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominios",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartamentos",
                columns: table => new
                {
                    ApartamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Andar = table.Column<int>(nullable: false),
                    BlocoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamentos", x => x.ApartamentoId);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Blocos_BlocoId",
                        column: x => x.BlocoId,
                        principalTable: "Blocos",
                        principalColumn: "BlocoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moradores",
                columns: table => new
                {
                    MoradorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(type: "Varchar(100)", nullable: false),
                    CPF = table.Column<string>(type: "Varchar(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "Date", nullable: false),
                    Email = table.Column<string>(type: "Varchar(50)", nullable: true),
                    Telefone = table.Column<string>(type: "Varchar(20)", nullable: true),
                    ApartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moradores", x => x.MoradorId);
                    table.ForeignKey(
                        name: "FK_Moradores_Apartamentos_ApartamentoId",
                        column: x => x.ApartamentoId,
                        principalTable: "Apartamentos",
                        principalColumn: "ApartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_BlocoId",
                table: "Apartamentos",
                column: "BlocoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_Numero_BlocoId",
                table: "Apartamentos",
                columns: new[] { "Numero", "BlocoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blocos_CondominioId",
                table: "Blocos",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocos_Nome_CondominioId",
                table: "Blocos",
                columns: new[] { "Nome", "CondominioId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moradores_ApartamentoId",
                table: "Moradores",
                column: "ApartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Moradores_CPF",
                table: "Moradores",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moradores");

            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "Blocos");

            migrationBuilder.DropTable(
                name: "Condominios");
        }
    }
}
