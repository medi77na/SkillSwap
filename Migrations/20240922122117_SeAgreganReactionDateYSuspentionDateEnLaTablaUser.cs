using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class SeAgreganReactionDateYSuspentionDateEnLaTablaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "created_at");

            migrationBuilder.AddColumn<DateOnly>(
                name: "reactivation_date",
                table: "Users",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "suspension_date",
                table: "Users",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reactivation_date",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "suspension_date",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "createdAt");
        }
    }
}
