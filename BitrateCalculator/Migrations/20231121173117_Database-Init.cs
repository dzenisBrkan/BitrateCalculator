using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitrateCalculator.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transcoder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Device = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcoder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NiC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rx = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tx = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranscoderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NiC_Transcoder_TranscoderId",
                        column: x => x.TranscoderId,
                        principalTable: "Transcoder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NiC_TranscoderId",
                table: "NiC",
                column: "TranscoderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NiC");

            migrationBuilder.DropTable(
                name: "Transcoder");
        }
    }
}
