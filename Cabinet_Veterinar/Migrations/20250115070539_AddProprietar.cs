using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cabinet_Veterinar.Migrations
{
    /// <inheritdoc />
    public partial class AddProprietar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProprietarID",
                table: "Pacient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Proprietar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietar", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacient_ProprietarID",
                table: "Pacient",
                column: "ProprietarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacient_Proprietar_ProprietarID",
                table: "Pacient",
                column: "ProprietarID",
                principalTable: "Proprietar",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacient_Proprietar_ProprietarID",
                table: "Pacient");

            migrationBuilder.DropTable(
                name: "Proprietar");

            migrationBuilder.DropIndex(
                name: "IX_Pacient_ProprietarID",
                table: "Pacient");

            migrationBuilder.DropColumn(
                name: "ProprietarID",
                table: "Pacient");
        }
    }
}
