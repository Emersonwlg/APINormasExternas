using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Norma.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NormasExternas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Comite = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Idioma = table.Column<string>(type: "varchar(1000)", nullable: false),
                    TipoNorma = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    DataInicioValidade = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormasExternas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NormaId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    CaminhoArquivo = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquivo_NormasExternas_NormaId",
                        column: x => x.NormaId,
                        principalTable: "NormasExternas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivo_NormaId",
                table: "Arquivo",
                column: "NormaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");

            migrationBuilder.DropTable(
                name: "NormasExternas");
        }
    }
}
