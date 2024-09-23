using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class New_fields_are_created_for_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password_reset_token",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<DateTime>(
                name: "password_reset_token_expiry",
                table: "Users",
                type: "datetime(6)",
                maxLength: 65,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_reset_token",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "password_reset_token_expiry",
                table: "Users");
        }
    }
}
