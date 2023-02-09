using Microsoft.EntityFrameworkCore.Migrations;
using MVC23.Models;

#nullable disable

namespace MVC23.Migrations
{
    /// <inheritdoc />
    public partial class nuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nommarca = table.Column<string>(name: "Nom_marca", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSerie = table.Column<string>(name: "Nom_Serie", type: "nvarchar(max)", nullable: false),
                    MarcaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Marcas_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "Marcas",
                        principalColumn: "ID",
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VeiculoModelo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoModelo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VeiculoModelo_Series_SerieID",
                        column: x => x.SerieID,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Extra",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoExtra = table.Column<string>(name: "Tipo_Extra",type: "nvarchar(max)", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extra", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "VeiculosExtra",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoID = table.Column<int>(type: "int", nullable: false),
                    ExtraID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculosExtra", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VehiculoModelo_ID",
                        column: x => x.VehiculoID,
                        principalTable: "VeiculoModelo",
                        principalColumn: "ID",
                        onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Extra_ID",
                        column: x => x.ExtraID,
                        principalTable: "Extra",
                        principalColumn: "ID",
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_MarcaID",
                table: "Series",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoModelo_SerieID",
                table: "VeiculoModelo",
                column: "SerieID");
            migrationBuilder.CreateIndex(
                name: "IX_VeiculoID",
                table: "VeiculosExtra",
                column: "VehiculoID");
            migrationBuilder.CreateIndex(
                name: "IX_ExtraID",
                table: "VeiculosExtra",
                column: "ExtraID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeiculoModelo");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
