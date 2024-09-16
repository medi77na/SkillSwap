using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class SeCambiaColumnaUsuarioDelaTablaReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_id_usuario",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "id_usuario",
                table: "Reports",
                newName: "id_user");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_id_usuario",
                table: "Reports",
                newName: "IX_Reports_id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_id_user",
                table: "Reports",
                column: "id_user",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_id_user",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "id_user",
                table: "Reports",
                newName: "id_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_id_user",
                table: "Reports",
                newName: "IX_Reports_id_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_id_usuario",
                table: "Reports",
                column: "id_usuario",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
