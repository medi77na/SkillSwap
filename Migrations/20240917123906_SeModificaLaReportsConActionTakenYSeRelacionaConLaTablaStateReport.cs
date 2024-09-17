using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class SeModificaLaReportsConActionTakenYSeRelacionaConLaTablaStateReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_State_requests_id_state_report",
                table: "Reports");

            migrationBuilder.AlterColumn<int>(
                name: "id_state_report",
                table: "Reports",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AddColumn<string>(
                name: "action_taken",
                table: "Reports",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "State_reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State_reports", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.InsertData(
                table: "State_reports",
                columns: new[] { "Id", "description", "name" },
                values: new object[,]
                {
                    { 1, "El reporte no ha sido solucionado y está esperando revisión o respuesta por parte del administrador.", "Pendiente" },
                    { 2, "El reporte esta siendo revisado por el administrador.", "En proceso" },
                    { 3, "El reporte ha sido revisado y aceptado por el administrador.", "Resuelto" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_State_reports_id_state_report",
                table: "Reports",
                column: "id_state_report",
                principalTable: "State_reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_State_reports_id_state_report",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "State_reports");

            migrationBuilder.DropColumn(
                name: "action_taken",
                table: "Reports");

            migrationBuilder.AlterColumn<int>(
                name: "id_state_report",
                table: "Reports",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_State_requests_id_state_report",
                table: "Reports",
                column: "id_state_report",
                principalTable: "State_requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
