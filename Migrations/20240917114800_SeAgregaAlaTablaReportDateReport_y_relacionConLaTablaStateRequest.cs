using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregaAlaTablaReportDateReport_y_relacionConLaTablaStateRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reports",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.AddColumn<DateOnly>(
                name: "date_report",
                table: "Reports",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "id_state_report",
                table: "Reports",
                type: "int(11)",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_id_state_report",
                table: "Reports",
                column: "id_state_report");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_State_requests_id_state_report",
                table: "Reports",
                column: "id_state_report",
                principalTable: "State_requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_State_requests_id_state_report",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_id_state_report",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "date_report",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "id_state_report",
                table: "Reports");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reports",
                type: "varchar(255)",
                nullable: false,
                collation: "utf8_general_ci",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
