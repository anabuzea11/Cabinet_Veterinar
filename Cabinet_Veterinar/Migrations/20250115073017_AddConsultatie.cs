using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cabinet_Veterinar.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultatie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultatieID",
                table: "Pacient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Consultatie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Consultatie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnostic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultatie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacient_ConsultatieID",
                table: "Pacient",
                column: "ConsultatieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacient_Consultatie_ConsultatieID",
                table: "Pacient",
                column: "ConsultatieID",
                principalTable: "Consultatie",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacient_Consultatie_ConsultatieID",
                table: "Pacient");

            migrationBuilder.DropTable(
                name: "Consultatie");

            migrationBuilder.DropIndex(
                name: "IX_Pacient_ConsultatieID",
                table: "Pacient");

            migrationBuilder.DropColumn(
                name: "ConsultatieID",
                table: "Pacient");
        }
    }
}
