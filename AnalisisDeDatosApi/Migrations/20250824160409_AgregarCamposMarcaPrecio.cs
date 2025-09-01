using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnalisisDeDatosApi.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposMarcaPrecio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "DatosDeVentas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "DatosDeVentas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "DatosDeVentas");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "DatosDeVentas");
        }
    }
}
