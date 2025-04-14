using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoTorneiosEsports.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Torneios_TorneioId",
                table: "Equipes");

            migrationBuilder.AlterColumn<int>(
                name: "TorneioId",
                table: "Equipes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Torneios_TorneioId",
                table: "Equipes",
                column: "TorneioId",
                principalTable: "Torneios",
                principalColumn: "TorneioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Torneios_TorneioId",
                table: "Equipes");

            migrationBuilder.AlterColumn<int>(
                name: "TorneioId",
                table: "Equipes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Torneios_TorneioId",
                table: "Equipes",
                column: "TorneioId",
                principalTable: "Torneios",
                principalColumn: "TorneioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
