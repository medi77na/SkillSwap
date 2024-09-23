using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class Some_fields_are_updated_for_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "password_reset_token",
                table: "Users",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(175)",
                oldMaxLength: 175,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "password_reset_token",
                table: "Users",
                type: "varchar(175)",
                maxLength: 175,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_general_ci");
        }
    }
}
