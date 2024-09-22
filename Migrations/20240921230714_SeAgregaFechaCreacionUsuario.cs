using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregaFechaCreacionUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "created_at",
                table: "Users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Abilities",
                keyColumn: "category",
                keyValue: null,
                column: "category",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "Abilities",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.UpdateData(
                table: "Abilities",
                keyColumn: "abilities",
                keyValue: null,
                column: "abilities",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "abilities",
                table: "Abilities",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.UpdateData(
                table: "State_users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "description", "duration_suspension" },
                values: new object[] { "La cuenta ha sido suspendida", 0 });
        }
    }
}
